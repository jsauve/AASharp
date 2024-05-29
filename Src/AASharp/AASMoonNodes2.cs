using System;
using System.Collections.Generic;

namespace AASharp
{
    /// <summary>
    /// This class uses interpolation to calculate the same details as those provided with the existing AASMoonNodes class.
    /// </summary>
    public static class AASMoonNodes2
    {
        public enum Algorithm
        {
            /// <summary>
            /// the truncated ELP2000 algorithm
            /// </summary>
            MeeusTruncated = 0,
        };

        /// <param name="StartJD">The Julian Day corresponding to the Dynamical Time for the date when you want to start the calculation for.</param>
        /// <param name="EndJD">The Julian Day corresponding to the Dynamical Time for the date when you want to end the calculation for.</param>
        /// <param name="StepInterval">The step interval in fractions of days to do the calculation for. The default value of 0.007 corresponds to roughly 10 minutes which is a reasonable tradeoff between performance and accuracy.</param>
        /// <param name="algorithm">An enum class representing the algorithm to use for the calculation. Can be MeeusTruncated which represents the truncated ELP2000 algorithm presented in the book, ELP2000 which uses the full ELP2000 algorithm, ELPMPP02Nominal which uses the ELPMPP02 Nominal fit, ELPMPP02LLR which uses the ELPMPP02 Lunar Laser Ranging fit, ELPMPP02DE405 which uses the ELPMPP02 DE405 fit and ELPMPP02DE406 which uses the ELPMPP02 DE406 fit.</param>
        /// <returns>An array of AASMoonNodesDetails2 instances with the details.</returns>
        /// <exception cref="Exception"></exception>
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