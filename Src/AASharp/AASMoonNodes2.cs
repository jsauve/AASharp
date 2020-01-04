using System;
using System.Collections.Generic;

namespace AASharp
{
    public static class AASMoonNodes2
    {
        public enum Algorithm
        {
            MeeusTruncated = 0,
            ELP2000 = 1,
            ELPMPP02Nominal = 2,
            ELPMPP02LLR = 3,
            ELPMPP02DE405 = 4,
            ELPMPP02DE406 = 5
        };

        public static List<AASMoonNodesDetails2> Calculate(double StartJD, double EndJD, double StepInterval, Algorithm algorithm)
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
                    {
                        MoonLatitude = AASMoon.EclipticLatitude(JD);
                        break;
                    }
                    case Algorithm.ELP2000:
                        MoonLatitude = AASELP2000.EclipticLatitude(JD);
                        break;


                    case Algorithm.ELPMPP02Nominal:
                        
                        MoonLatitude = AASELPMPP02.EclipticLatitude(JD, AASELPMPP02.Correction.Nominal, ref pDerivative);
                        break;

                    case Algorithm.ELPMPP02LLR:
                        MoonLatitude = AASELPMPP02.EclipticLatitude(JD, AASELPMPP02.Correction.LLR, ref pDerivative);
                        break;

                    case Algorithm.ELPMPP02DE405:
                        MoonLatitude = AASELPMPP02.EclipticLatitude(JD, AASELPMPP02.Correction.DE405, ref pDerivative);
                        break;

                    case Algorithm.ELPMPP02DE406:
                        MoonLatitude = AASELPMPP02.EclipticLatitude(JD, AASELPMPP02.Correction.DE406, ref pDerivative);
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