using System;
using System.Collections.Generic;

namespace AASharp
{
    /// <summary>
    /// This class uses interpolation to calculate the same details as those provided with the existing AASMoonMaxDeclinations class.
    /// </summary>
    public static class AASMoonMaxDeclinations2
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
        /// <returns>An array of AASMoonMaxDeclinationsDetails2 instances with the details.</returns>
        /// <exception cref="Exception"></exception>
        public static List<AASMoonMaxDeclinationsDetails2> Calculate(double StartJD, double EndJD, double StepInterval = 0.007, Algorithm algorithm = Algorithm.MeeusTruncated)
        {
            //What will be the return value
            List<AASMoonMaxDeclinationsDetails2> events = new List<AASMoonMaxDeclinationsDetails2>();

            double JD = StartJD;
            double LastLatitude0 = -90;
            double LastLatitude1 = -90;
            double LastRA0 = 0;
            double LastRA1 = 0;

            while (JD < EndJD)
            {
                double MoonLong = 0;
                double MoonLat = 0;
                switch (algorithm)
                {
                    case Algorithm.MeeusTruncated:
                        MoonLong = AASMoon.EclipticLongitude(JD);
                        MoonLat = AASMoon.EclipticLatitude(JD);
                        break;

                    default:
                        throw new Exception($"{algorithm} is not a valid value");
                }

                AAS2DCoordinate Equatorial =
                    AASCoordinateTransformation.Ecliptic2Equatorial(MoonLong, MoonLat, AASNutation.TrueObliquityOfEcliptic(JD));

                //Precess the coordinates if required
                if (algorithm != Algorithm.MeeusTruncated)
                    Equatorial = AASPrecession.PrecessEquatorial(Equatorial.X, Equatorial.Y, 2451545, JD);

                if ((LastLatitude0 != -90) && (LastLatitude1 != -90))
                {
                    double tempRA = Equatorial.X;
                    double tempLastRA1 = LastRA1;
                    double tempLastRA0 = LastRA0;
                    AASRiseTransitSet.CorrectRAValuesForInterpolation(ref tempLastRA1, ref tempLastRA0, ref tempRA);
                    if ((LastLatitude0 > Equatorial.Y) && (LastLatitude0 > LastLatitude1))
                    {
                        AASMoonMaxDeclinationsDetails2 @event = new AASMoonMaxDeclinationsDetails2();
                        @event.type = AASMoonMaxDeclinationsDetails2.Type.MaxNorthernDeclination;
                        double fraction = 0;
                        @event.Declination = AASInterpolate.Extremum(LastLatitude1, LastLatitude0, Equatorial.Y, ref fraction);
                        @event.RA = AASCoordinateTransformation.MapTo0To24Range(
                            AASInterpolate.Interpolate(fraction, tempLastRA1, tempLastRA0, tempRA));
                        @event.JD = JD - StepInterval + (fraction * StepInterval);
                        events.Add(@event);
                    }
                    else if ((LastLatitude0 < Equatorial.Y) && (LastLatitude0 < LastLatitude1))
                    {
                        AASMoonMaxDeclinationsDetails2 @event = new AASMoonMaxDeclinationsDetails2();
                        @event.type = AASMoonMaxDeclinationsDetails2.Type.MaxSouthernDeclination;
                        double fraction = 0;
                        @event.Declination = AASInterpolate.Extremum(LastLatitude1, LastLatitude0, Equatorial.Y, ref fraction);
                        @event.RA = AASCoordinateTransformation.MapTo0To24Range(
                            AASInterpolate.Interpolate(fraction, tempLastRA1, tempLastRA0, tempRA));
                        @event.JD = JD - StepInterval + (fraction * StepInterval);
                        events.Add(@event);
                    }
                }

                //Prepare for the next loop
                LastLatitude1 = LastLatitude0;
                LastLatitude0 = Equatorial.Y;
                LastRA1 = LastRA0;
                LastRA0 = Equatorial.X;
                JD += StepInterval;
            }

            return events;
        }
    }
}