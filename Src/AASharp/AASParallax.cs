using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    public class AASTopocentricEclipticDetails
    {
        public double Lambda;
        public double Beta;
        public double Semidiameter;
    }

    public static class AASParallax
    {
        private readonly static double g_AAParallax_C1 = Math.Sin(AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, 8.794)));

        public static double DistanceToParallax(double Distance)
        {
            double pi = Math.Asin(g_AAParallax_C1 / Distance);
            return AASCoordinateTransformation.RadiansToDegrees(pi);
        }

        public static double ParallaxToDistance(double Parallax)
        {
            return g_AAParallax_C1 / Math.Sin(AASCoordinateTransformation.DegreesToRadians(Parallax));
        }

        public static AAS2DCoordinate Equatorial2TopocentricDelta(double Alpha, double Delta, double Distance, double Longitude, double Latitude, double Height, double JD)
        {
            double RhoSinThetaPrime = AASGlobe.RhoSinThetaPrime(Latitude, Height);
            double RhoCosThetaPrime = AASGlobe.RhoCosThetaPrime(Latitude, Height);

            //Calculate the Sidereal time
            double theta = AASSidereal.ApparentGreenwichSiderealTime(JD);

            //Convert to radians
            Delta = AASCoordinateTransformation.DegreesToRadians(Delta);
            double cosDelta = Math.Cos(Delta);

            //Calculate the Parallax
            double pi = Math.Asin(g_AAParallax_C1 / Distance);

            //Calculate the hour angle
            double H = AASCoordinateTransformation.HoursToRadians(theta - Longitude / 15 - Alpha);
            double cosH = Math.Cos(H);
            double sinH = Math.Sin(H);

            AAS2DCoordinate DeltaTopocentric = new AAS2DCoordinate { X = AASCoordinateTransformation.RadiansToHours(-pi * RhoCosThetaPrime * sinH / cosDelta), Y = AASCoordinateTransformation.RadiansToDegrees(-pi * (RhoSinThetaPrime * cosDelta - RhoCosThetaPrime * cosH * Math.Sin(Delta))) };
            return DeltaTopocentric;
        }

        public static AAS2DCoordinate Equatorial2Topocentric(double Alpha, double Delta, double Distance, double Longitude, double Latitude, double Height, double JD)
        {
            double RhoSinThetaPrime = AASGlobe.RhoSinThetaPrime(Latitude, Height);
            double RhoCosThetaPrime = AASGlobe.RhoCosThetaPrime(Latitude, Height);

            //Calculate the Sidereal time
            double theta = AASSidereal.ApparentGreenwichSiderealTime(JD);

            //Convert to radians
            Delta = AASCoordinateTransformation.DegreesToRadians(Delta);
            double cosDelta = Math.Cos(Delta);

            //Calculate the Parallax
            double pi = Math.Asin(g_AAParallax_C1 / Distance);
            double sinpi = Math.Sin(pi);

            //Calculate the hour angle
            double H = AASCoordinateTransformation.HoursToRadians(theta - Longitude / 15 - Alpha);
            double cosH = Math.Cos(H);
            double sinH = Math.Sin(H);

            //Calculate the adjustment in right ascension
            double DeltaAlpha = Math.Atan2(-RhoCosThetaPrime * sinpi * sinH, cosDelta - RhoCosThetaPrime * sinpi * cosH);

            AAS2DCoordinate Topocentric = new AAS2DCoordinate { X = AASCoordinateTransformation.MapTo0To24Range(Alpha + AASCoordinateTransformation.RadiansToHours(DeltaAlpha)), Y = AASCoordinateTransformation.RadiansToDegrees(Math.Atan2((Math.Sin(Delta) - RhoSinThetaPrime * sinpi) * Math.Cos(DeltaAlpha), cosDelta - RhoCosThetaPrime * sinpi * cosH)) };

            return Topocentric;
        }

        public static AASTopocentricEclipticDetails Ecliptic2Topocentric(double Lambda, double Beta, double Semidiameter, double Distance, double Epsilon, double Latitude, double Height, double JD)
        {
            double S = AASGlobe.RhoSinThetaPrime(Latitude, Height);
            double C = AASGlobe.RhoCosThetaPrime(Latitude, Height);

            //Convert to radians
            Lambda = AASCoordinateTransformation.DegreesToRadians(Lambda);
            Beta = AASCoordinateTransformation.DegreesToRadians(Beta);
            Epsilon = AASCoordinateTransformation.DegreesToRadians(Epsilon);
            Semidiameter = AASCoordinateTransformation.DegreesToRadians(Semidiameter);
            double sine = Math.Sin(Epsilon);
            double cose = Math.Cos(Epsilon);
            double cosBeta = Math.Cos(Beta);
            double sinBeta = Math.Sin(Beta);

            //Calculate the Sidereal time
            double theta = AASSidereal.ApparentGreenwichSiderealTime(JD);
            theta = AASCoordinateTransformation.HoursToRadians(theta);
            double sintheta = Math.Sin(theta);

            //Calculate the Parallax
            double pi = Math.Asin(g_AAParallax_C1 / Distance);
            double sinpi = Math.Sin(pi);

            double N = Math.Cos(Lambda) * cosBeta - C * sinpi * Math.Cos(theta);

            AASTopocentricEclipticDetails Topocentric = new AASTopocentricEclipticDetails { Lambda = Math.Atan2(Math.Sin(Lambda) * cosBeta - sinpi * (S * sine + C * cose * sintheta), N) };
            double cosTopocentricLambda = Math.Cos(Topocentric.Lambda);
            Topocentric.Beta = Math.Atan(cosTopocentricLambda * (sinBeta - sinpi * (S * cose - C * sine * sintheta)) / N);
            Topocentric.Semidiameter = Math.Asin(cosTopocentricLambda * Math.Cos(Topocentric.Beta) * Math.Sin(Semidiameter) / N);

            //Convert back to degrees
            Topocentric.Semidiameter = AASCoordinateTransformation.RadiansToDegrees(Topocentric.Semidiameter);
            Topocentric.Lambda = AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(Topocentric.Lambda));
            Topocentric.Beta = AASCoordinateTransformation.RadiansToDegrees(Topocentric.Beta);

            return Topocentric;
        }
    }
}
