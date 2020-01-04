using System;
using System.Collections.Generic;

namespace AASharp
{
    public static class AASMoonMaxDeclinations2
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

        public static List<AASMoonMaxDeclinationsDetails2> Calculate(double StartJD, double EndJD, double StepInterval, Algorithm algorithm)
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

                    case Algorithm.ELP2000:
                        MoonLong = AASELP2000.EclipticLongitude(JD);
                        MoonLat = AASELP2000.EclipticLatitude(JD);
                        break;
                    
                    case Algorithm.ELPMPP02Nominal:
                        
                        MoonLong = AASELPMPP02.EclipticLongitude(JD, AASELPMPP02.Correction.Nominal, ref pDerivative);
                        MoonLat = AASELPMPP02.EclipticLatitude(JD, AASELPMPP02.Correction.Nominal, ref pDerivative);
                        break;

                    case Algorithm.ELPMPP02LLR:
                        MoonLong = AASELPMPP02.EclipticLongitude(JD, AASELPMPP02.Correction.LLR, ref pDerivative);
                        MoonLat = AASELPMPP02.EclipticLatitude(JD, AASELPMPP02.Correction.LLR, ref pDerivative);
                        break;

                    case Algorithm.ELPMPP02DE405:
                        MoonLong = AASELPMPP02.EclipticLongitude(JD, AASELPMPP02.Correction.DE405, ref pDerivative);
                        MoonLat = AASELPMPP02.EclipticLatitude(JD, AASELPMPP02.Correction.DE405, ref pDerivative);
                        break;

                    case Algorithm.ELPMPP02DE406:
                        MoonLong = AASELPMPP02.EclipticLongitude(JD, AASELPMPP02.Correction.DE406, ref pDerivative);
                        MoonLat = AASELPMPP02.EclipticLatitude(JD, AASELPMPP02.Correction.DE406, ref pDerivative);
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