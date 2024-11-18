using System;
using System.Collections.Generic;

namespace AASharp
{
    /// <summary>
    /// This class uses interpolation to calculate the same details as those provided with the existing AASMoonPerigeeApogee class.
    /// </summary>
    public class AASMoonPerigeeApogee2
    {
        public enum Algorithm
        {
            /// <summary>
            /// truncated ELP2000 algorithm
            /// </summary>
            MeeusTruncated = 0,
        };

        /// <param name="StartJD">The Julian Day corresponding to the Dynamical Time for the date when you want to start the calculation for.</param>
        /// <param name="EndJD">The Julian Day corresponding to the Dynamical Time for the date when you want to end the calculation for.</param>
        /// <param name="StepInterval">The step interval in fractions of days to do the calculation for. The default value of 0.007 corresponds to roughly 10 minutes which is a reasonable tradeoff between performance and accuracy.</param>
        /// <param name="algorithm">An enum class representing the algorithm to use for the calculation. Can be MeeusTruncated which represents the truncated ELP2000 algorithm presented in the book, ELP2000 which uses the full ELP2000 algorithm, ELPMPP02Nominal which uses the ELPMPP02 Nominal fit, ELPMPP02LLR which uses the ELPMPP02 Lunar Laser Ranging fit, ELPMPP02DE405 which uses the ELPMPP02 DE405 fit and ELPMPP02DE406 which uses the ELPMPP02 DE406 fit.</param>
        /// <returns>A list of AASMoonPerigeeApogeeDetails2 instances with details.</returns>
        /// <exception cref="Exception"></exception>
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