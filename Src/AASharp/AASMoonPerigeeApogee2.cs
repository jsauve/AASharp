using System;
using System.Collections.Generic;

namespace AASharp
{
    public class AASMoonPerigeeApogee2
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
    
        List<AASMoonPerigeeApogeeDetails2> Calculate(double StartJD, double EndJD, double StepInterval, Algorithm algorithm)
        {
            //What will be the return value
            List<AASMoonPerigeeApogeeDetails2> events = new List<AASMoonPerigeeApogeeDetails2>();

            double JD = StartJD;
            double LastJD0 = 0;
            double LastJD1 = 0;
            double LastDistance0 = 0;
            double LastDistance1 = 0;
            double pDerivative = 0;

            while (JD < EndJD)
            {
                double MoonDistance = 0;
                switch (algorithm)
                {
                    case Algorithm.MeeusTruncated:
      
                        MoonDistance = AASMoon.RadiusVector(JD);
                        break;
      
                    case Algorithm.ELP2000:
      
                        MoonDistance = AASELP2000.RadiusVector(JD);
                        break;


                    case Algorithm.ELPMPP02Nominal:
                        MoonDistance = AASELPMPP02.RadiusVector(JD, AASELPMPP02.Correction.Nominal, ref pDerivative);
                        break;
      
                    case Algorithm.ELPMPP02LLR:
      
                        MoonDistance = AASELPMPP02.RadiusVector(JD, AASELPMPP02.Correction.LLR, ref pDerivative);
                        break;
      
                    case Algorithm.ELPMPP02DE405:
      
                        MoonDistance = AASELPMPP02.RadiusVector(JD, AASELPMPP02.Correction.DE405, ref pDerivative);
                        break;
      
                    case Algorithm.ELPMPP02DE406:
      
                        MoonDistance = AASELPMPP02.RadiusVector(JD, AASELPMPP02.Correction.DE406, ref pDerivative);
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
                LastJD0 = JD;
                LastJD1 = LastJD0;
                JD += StepInterval;
            }

            return events;
        }

    }
}