using System;
using System.Collections.Generic;

namespace AASharp
{
    public static class AASMoonMaxDeclinations2
    {
        public enum Algorithm
        {
            MeeusTruncated = 0,
        };

        public static List<AASMoonMaxDeclinationsDetails2> Calculate(double StartJD, double EndJD, double StepInterval = 0.007, Algorithm algorithm = Algorithm.MeeusTruncated)
        {
            //What will be the return value
            List<AASMoonMaxDeclinationsDetails2> events = new List<AASMoonMaxDeclinationsDetails2>();

            double JD = StartJD;
            double LastJD0 = 0;
            double LastJD1 = 0;
            double LastLatitude0 = -90;
            double LastLatitude1 = -90;
            double LastRA0 = 0;
            double LastRA1 = 0;
            double pDerivative = 0;

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
                LastJD0 = JD;
                LastJD1 = LastJD0;
                JD += StepInterval;
            }

            return events;
        }
    }
}