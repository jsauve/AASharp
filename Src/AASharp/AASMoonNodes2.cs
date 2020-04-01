using System;
using System.Collections.Generic;

namespace AASharp
{
    public static class AASMoonNodes2
    {
        public enum Algorithm
        {
            MeeusTruncated = 0,
        };

        public static List<AASMoonNodesDetails2> Calculate(double StartJD, double EndJD, double StepInterval = 0.007, Algorithm algorithm = Algorithm.MeeusTruncated)
        {
            //What will be the return value
            List<AASMoonNodesDetails2> events = new List<AASMoonNodesDetails2>();

            double JD = StartJD;
            double LastJD0 = 0;
            double LastLatitude0 = -90;
            while (JD < EndJD)
            {
                double MoonLatitude = 0;
                double pDerivative = 0;

                switch (algorithm)
                {
                    case Algorithm.MeeusTruncated:
                        MoonLatitude = AASMoon.EclipticLatitude(JD);
                        break;
                    
                    default:
                        throw new Exception($"{algorithm} is not a valid value");
                }

                if (LastLatitude0 != -90)
                {
                    if ((LastLatitude0 < 0) && (MoonLatitude >= 0))
                    {
                        AASMoonNodesDetails2 @event = new AASMoonNodesDetails2();
                        @event.type = AASMoonNodesDetails2.Type.Ascending;
                        double fraction = (0 - LastLatitude0) / (MoonLatitude - LastLatitude0);
                        @event.JD = LastJD0 + (fraction * StepInterval);
                        events.Add(@event);
                    }
                    else if ((LastLatitude0 > 0) && (MoonLatitude <= 0))
                    {
                        AASMoonNodesDetails2 @event = new AASMoonNodesDetails2();
                        @event.type = AASMoonNodesDetails2.Type.Descending;
                        double fraction = (0 - LastLatitude0) / (MoonLatitude - LastLatitude0);
                        @event.JD = LastJD0 + (fraction * StepInterval);
                        events.Add(@event);
                    }
                }

                //Prepare for the next loop
                LastLatitude0 = MoonLatitude;
                LastJD0 = JD;
                JD += StepInterval;
            }

            return events;
        }
    }
}