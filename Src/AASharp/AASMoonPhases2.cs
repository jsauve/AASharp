using System;
using System.Collections.Generic;

namespace AASharp
{
    /// <summary>
    /// This class uses interpolation to calculate the same details as those provided with the existing AASMoonPhases class.
    /// </summary>
    public static class AASMoonPhases2
    {
        public enum Algorithm
        {
            /// <summary>
            /// the truncated ELP2000 algorithm
            /// </summary>
            MeeusTruncated = 0
        }

        /// <param name="StartJD">The Julian Day corresponding to the Dynamical Time for the date when you want to start the calculation for.</param>
        /// <param name="EndJD">The Julian Day corresponding to the Dynamical Time for the date when you want to end the calculation for.</param>
        /// <param name="StepInterval">The step interval in fractions of days to do the calculation for. The default value of 0.007 corresponds to roughly 10 minutes which is a reasonable tradeoff between performance and accuracy.</param>
        /// <param name="algorithm">An enum class representing the algorithm to use for the calculation. Can be MeeusTruncated which represents the truncated ELP2000 algorithm presented in the book, ELP2000 which uses the full ELP2000 algorithm, ELPMPP02Nominal which uses the ELPMPP02 Nominal fit, ELPMPP02LLR which uses the ELPMPP02 Lunar Laser Ranging fit, ELPMPP02DE405 which uses the ELPMPP02 DE405 fit and ELPMPP02DE406 which uses the ELPMPP02 DE406 fit.</param>
        /// <returns>List of AASMoonPhasesDetails2 instances with the details.</returns>
        /// <exception cref="Exception"></exception>
        public static List<AASMoonPhasesDetails2> Calculate(double StartJD, double EndJD, double StepInterval = 0.007,
            Algorithm algorithm = Algorithm.MeeusTruncated)
        {
            //What will be the return value
            List<AASMoonPhasesDetails2> events = new List<AASMoonPhasesDetails2>();

            double JD = StartJD;
            double LastJD0 = 0;
            double LastExcessApparentGeocentricLongitude = -360;
            while (JD < EndJD)
            {
                double ExcessApparentGeocentricLongitude = 0;
                AAS2DCoordinate MoonPos;
                switch (algorithm)
                {
                    case Algorithm.MeeusTruncated:
                        ExcessApparentGeocentricLongitude = AASCoordinateTransformation.MapTo0To360Range(AASMoon.EclipticLongitude(JD) - AASSun.ApparentEclipticLongitude(JD, false));
                        break;

                    default:
                        throw new Exception($"{algorithm} is not a valid value");
                }

                if (LastExcessApparentGeocentricLongitude != -360)
                {
                    if ((LastExcessApparentGeocentricLongitude > 270) && (ExcessApparentGeocentricLongitude >= 0) && (ExcessApparentGeocentricLongitude < 90))
                    {
                        AASMoonPhasesDetails2 @event = new AASMoonPhasesDetails2();
                        @event.type = AASMoonPhasesDetails2.Type.NewMoon;
                        double fraction = (360 - LastExcessApparentGeocentricLongitude) / (ExcessApparentGeocentricLongitude + (360 - LastExcessApparentGeocentricLongitude));
                        @event.JD = LastJD0 + (fraction* StepInterval);
                        events.Add(@event);
                    }
                     if ((LastExcessApparentGeocentricLongitude< 90) && (ExcessApparentGeocentricLongitude >= 90))
                    {
                        AASMoonPhasesDetails2 @event = new AASMoonPhasesDetails2();
                        @event.type = AASMoonPhasesDetails2.Type.FirstQuarter;
                        double fraction = (90 - LastExcessApparentGeocentricLongitude) / (ExcessApparentGeocentricLongitude - LastExcessApparentGeocentricLongitude);
                        @event.JD = LastJD0 + (fraction* StepInterval);
                        events.Add(@event);
                     }
                     else if ((LastExcessApparentGeocentricLongitude< 180) && (ExcessApparentGeocentricLongitude >= 180))
                    {
                        AASMoonPhasesDetails2 @event = new AASMoonPhasesDetails2();
                        @event.type = AASMoonPhasesDetails2.Type.FullMoon;
                        double fraction = (180 - LastExcessApparentGeocentricLongitude) / (ExcessApparentGeocentricLongitude - LastExcessApparentGeocentricLongitude);
                        @event.JD = LastJD0 + (fraction* StepInterval);
                        events.Add(@event);
                    }
                    else if ((LastExcessApparentGeocentricLongitude< 270) && (ExcessApparentGeocentricLongitude >= 270))
                    {
                        AASMoonPhasesDetails2 @event = new AASMoonPhasesDetails2();
                        @event.type = AASMoonPhasesDetails2.Type.LastQuarter;
                        double fraction = (270 - LastExcessApparentGeocentricLongitude) / (ExcessApparentGeocentricLongitude - LastExcessApparentGeocentricLongitude);
                        @event.JD = LastJD0 + (fraction* StepInterval);
                        events.Add(@event);
                     }
                }
                
                //Prepare for the next loop
                LastExcessApparentGeocentricLongitude = ExcessApparentGeocentricLongitude;
                LastJD0 = JD;
                JD += StepInterval;
            }

            return events;
        }
    }
}