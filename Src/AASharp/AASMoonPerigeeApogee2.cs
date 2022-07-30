using System;
using System.Collections.Generic;

namespace AASharp
{
    public class AASMoonPerigeeApogee2
    {
        public enum Algorithm
        {
            MeeusTruncated = 0,
        };
    
        public static List<AASMoonPerigeeApogeeDetails2> Calculate(double StartJD, double EndJD, double StepInterval = 0.007, Algorithm algorithm = Algorithm.MeeusTruncated)
        {
            //What will be the return value
            List<AASMoonPerigeeApogeeDetails2> events = new List<AASMoonPerigeeApogeeDetails2>();

            double JD = StartJD;
            double LastDistance0 = 0;
            double LastDistance1 = 0;

            while (JD < EndJD)
            {
                double MoonDistance = 0;
                switch (algorithm)
                {
                    case Algorithm.MeeusTruncated:
                        MoonDistance = AASMoon.RadiusVector(JD);
                        break;
                    
                    default:
                        throw new Exception($"{algorithm} is not a supported value");
                }

                if ((LastDistance0 != 0) && (LastDistance1 != 0))
                {
                    if ((LastDistance0 > MoonDistance) && (LastDistance0 > LastDistance1))
                    {
                        AASMoonPerigeeApogeeDetails2 @event = new AASMoonPerigeeApogeeDetails2();
                        @event.type = AASMoonPerigeeApogeeDetails2.Type.Apogee;
                        double fraction = 0;
                        @event.Value = AASInterpolate.Extremum(LastDistance1, LastDistance0, MoonDistance, ref fraction);
                        @event.JD = JD - StepInterval + (fraction * StepInterval);
                        events.Add(@event);
                    }
                    else if ((LastDistance0 < MoonDistance) && (LastDistance0 < LastDistance1))
                    {
                        AASMoonPerigeeApogeeDetails2 @event = new AASMoonPerigeeApogeeDetails2();
                        @event.type = AASMoonPerigeeApogeeDetails2.Type.Perigee;
                        double fraction = 0;
                        @event.Value = AASInterpolate.Extremum(LastDistance1, LastDistance0, MoonDistance, ref fraction);
                        @event.JD = JD - StepInterval + (fraction * StepInterval);
                        events.Add(@event);
                    }
                }

                //Prepare for the next loop
                LastDistance1 = LastDistance0;
                LastDistance0 = MoonDistance;
                JD += StepInterval;
            }

            return events;
        }

    }
}