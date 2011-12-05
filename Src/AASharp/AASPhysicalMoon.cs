using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public class AASPhysicalMoonDetails
    {
        public AASPhysicalMoonDetails()
        {
        }

        public double ldash;
        public double bdash;
        public double ldash2;
        public double bdash2;
        public double l;
        public double b;
        public double P;
    }

    public class AASSelenographicMoonDetails
    {
        public AASSelenographicMoonDetails()
        {
        }

        public double l0;
        public double b0;
        public double c0;
    }

    public static class AASPhysicalMoon
    {
        public static void CalculateOpticalLibration(double JD, double Lambda, double Beta, ref double ldash, ref double bdash, ref double ldash2, ref double bdash2, ref double epsilon, ref double omega, ref double DeltaU, ref double sigma, ref double I, ref double rho)
        {
            //Calculate the initial quantities
            double Lambdarad = AASCoordinateTransformation.DegreesToRadians(Lambda);
            double Betarad = AASCoordinateTransformation.DegreesToRadians(Beta);
            I = AASCoordinateTransformation.DegreesToRadians(1.54242);
            DeltaU = AASCoordinateTransformation.DegreesToRadians(AASNutation.NutationInLongitude(JD) / 3600);
            double F = AASCoordinateTransformation.DegreesToRadians(AASMoon.ArgumentOfLatitude(JD));
            omega = AASCoordinateTransformation.DegreesToRadians(AASMoon.MeanLongitudeAscendingNode(JD));
            epsilon = AASNutation.MeanObliquityOfEcliptic(JD) + AASNutation.NutationInObliquity(JD) / 3600;

            //Calculate the optical librations
            double W = Lambdarad - DeltaU / 3600 - omega;
            double A = Math.Atan2(Math.Sin(W) * Math.Cos(Betarad) * Math.Cos(I) - Math.Sin(Betarad) * Math.Sin(I), Math.Cos(W) * Math.Cos(Betarad));
            ldash = AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(A) - AASCoordinateTransformation.RadiansToDegrees(F));
            if (ldash > 180)
                ldash -= 360;
            bdash = Math.Asin(-Math.Sin(W) * Math.Cos(Betarad) * Math.Sin(I) - Math.Sin(Betarad) * Math.Cos(I));

            //Calculate the physical librations
            double T = (JD - 2451545.0) / 36525;
            double K1 = 119.75 + 131.849 * T;
            K1 = AASCoordinateTransformation.DegreesToRadians(K1);
            double K2 = 72.56 + 20.186 * T;
            K2 = AASCoordinateTransformation.DegreesToRadians(K2);

            double M = AASEarth.SunMeanAnomaly(JD);
            M = AASCoordinateTransformation.DegreesToRadians(M);
            double Mdash = AASMoon.MeanAnomaly(JD);
            Mdash = AASCoordinateTransformation.DegreesToRadians(Mdash);
            double D = AASMoon.MeanElongation(JD);
            D = AASCoordinateTransformation.DegreesToRadians(D);
            double E = AASEarth.Eccentricity(JD);

            rho = -0.02752 * Math.Cos(Mdash) +
            -0.02245 * Math.Sin(F) +
            0.00684 * Math.Cos(Mdash - 2 * F) +
            -0.00293 * Math.Cos(2 * F) +
            -0.00085 * Math.Cos(2 * F - 2 * D) +
            -0.00054 * Math.Cos(Mdash - 2 * D) +
            -0.00020 * Math.Sin(Mdash + F) +
            -0.00020 * Math.Cos(Mdash + 2 * F) +
            -0.00020 * Math.Cos(Mdash - F) +
            0.00014 * Math.Cos(Mdash + 2 * F - 2 * D);

            sigma = -0.02816 * Math.Sin(Mdash) +
            0.02244 * Math.Cos(F) +
            -0.00682 * Math.Sin(Mdash - 2 * F) +
            -0.00279 * Math.Sin(2 * F) +
            -0.00083 * Math.Sin(2 * F - 2 * D) +
            0.00069 * Math.Sin(Mdash - 2 * D) +
            0.00040 * Math.Cos(Mdash + F) +
            -0.00025 * Math.Sin(2 * Mdash) +
            -0.00023 * Math.Sin(Mdash + 2 * F) +
            0.00020 * Math.Cos(Mdash - F) +
            0.00019 * Math.Sin(Mdash - F) +
            0.00013 * Math.Sin(Mdash + 2 * F - 2 * D) +
            -0.00010 * Math.Cos(Mdash - 3 * F);

            double tau = 0.02520 * E * Math.Sin(M) +
            0.00473 * Math.Sin(2 * Mdash - 2 * F) +
            -0.00467 * Math.Sin(Mdash) +
            0.00396 * Math.Sin(K1) +
            0.00276 * Math.Sin(2 * Mdash - 2 * D) +
            0.00196 * Math.Sin(omega) +
            -0.00183 * Math.Cos(Mdash - F) +
            0.00115 * Math.Sin(Mdash - 2 * D) +
            -0.00096 * Math.Sin(Mdash - D) +
            0.00046 * Math.Sin(2 * F - 2 * D) +
            -0.00039 * Math.Sin(Mdash - F) +
            -0.00032 * Math.Sin(Mdash - M - D) +
            0.00027 * Math.Sin(2 * Mdash - M - 2 * D) +
            0.00023 * Math.Sin(K2) +
            -0.00014 * Math.Sin(2 * D) +
            0.00014 * Math.Cos(2 * Mdash - 2 * F) +
            -0.00012 * Math.Sin(Mdash - 2 * F) +
            -0.00012 * Math.Sin(2 * Mdash) +
            0.00011 * Math.Sin(2 * Mdash - 2 * M - 2 * D);

            ldash2 = -tau + (rho * Math.Cos(A) + sigma * Math.Sin(A)) * Math.Tan(bdash);
            bdash = AASCoordinateTransformation.RadiansToDegrees(bdash);
            bdash2 = sigma * Math.Cos(A) - rho * Math.Sin(A);
        }

        public static AASPhysicalMoonDetails CalculateHelper(double JD, ref double Lambda, ref double Beta, ref double epsilon, ref AAS2DCoordinate Equatorial)
        {
            //What will be the return value
            AASPhysicalMoonDetails details = new AASPhysicalMoonDetails();

            //Calculate the initial quantities
            Lambda = AASMoon.EclipticLongitude(JD);
            Beta = AASMoon.EclipticLatitude(JD);

            //Calculate the optical libration
            double omega = 0;
            double DeltaU = 0;
            double sigma = 0;
            double I = 0;
            double rho = 0;
            CalculateOpticalLibration(JD, Lambda, Beta, ref details.ldash, ref details.bdash, ref details.ldash2, ref details.bdash2, ref epsilon, ref omega, ref DeltaU, ref sigma, ref I, ref rho);
            double epsilonrad = AASCoordinateTransformation.DegreesToRadians(epsilon);

            //Calculate the total libration
            details.l = details.ldash + details.ldash2;
            details.b = details.bdash + details.bdash2;
            double b = AASCoordinateTransformation.DegreesToRadians(details.b);

            //Calculate the position angle
            double V = omega + DeltaU + AASCoordinateTransformation.DegreesToRadians(sigma) / Math.Sin(I);
            double I_rho = I + AASCoordinateTransformation.DegreesToRadians(rho);
            double X = Math.Sin(I_rho) * Math.Sin(V);
            double Y = Math.Sin(I_rho) * Math.Cos(V) * Math.Cos(epsilonrad) - Math.Cos(I_rho) * Math.Sin(epsilonrad);
            double w = Math.Atan2(X, Y);

            Equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(Lambda, Beta, epsilon);
            double Alpha = AASCoordinateTransformation.HoursToRadians(Equatorial.X);

            details.P = AASCoordinateTransformation.RadiansToDegrees(Math.Asin(Math.Sqrt(X * X + Y * Y) * Math.Cos(Alpha - w) / (Math.Cos(b))));

            return details;
        }

        public static AASPhysicalMoonDetails CalculateGeocentric(double JD)
        {
            double Lambda = 0;
            double Beta = 0;
            double epsilon = 0;
            AAS2DCoordinate Equatorial = new AAS2DCoordinate();
            return CalculateHelper(JD, ref Lambda, ref Beta, ref epsilon, ref Equatorial);
        }

        public static AASPhysicalMoonDetails CalculateTopocentric(double JD, double Longitude, double Latitude)
        {
            //First convert to radians
            Longitude = AASCoordinateTransformation.DegreesToRadians(Longitude);
            Latitude = AASCoordinateTransformation.DegreesToRadians(Latitude);

            double Lambda = 0;
            double Beta = 0;
            double epsilon = 0;
            AAS2DCoordinate Equatorial = new AAS2DCoordinate();
            AASPhysicalMoonDetails details = CalculateHelper(JD, ref Lambda, ref Beta, ref epsilon, ref Equatorial);

            double R = AASMoon.RadiusVector(JD);
            double pi = AASMoon.RadiusVectorToHorizontalParallax(R);
            double Alpha = AASCoordinateTransformation.HoursToRadians(Equatorial.X);
            double Delta = AASCoordinateTransformation.DegreesToRadians(Equatorial.Y);

            double AST = AASSidereal.ApparentGreenwichSiderealTime(JD);
            double H = AASCoordinateTransformation.HoursToRadians(AST) - Longitude - Alpha;

            double Q = Math.Atan2(Math.Cos(Latitude) * Math.Sin(H), Math.Cos(Delta) * Math.Sin(Latitude) - Math.Sin(Delta) * Math.Cos(Latitude) * Math.Cos(H));
            double Z = Math.Acos(Math.Sin(Delta) * Math.Sin(Latitude) + Math.Cos(Delta) * Math.Cos(Latitude) * Math.Cos(H));
            double pidash = pi * (Math.Sin(Z) + 0.0084 * Math.Sin(2 * Z));

            double Prad = AASCoordinateTransformation.DegreesToRadians(details.P);

            double DeltaL = -pidash * Math.Sin(Q - Prad) / Math.Cos(AASCoordinateTransformation.DegreesToRadians(details.b));
            details.l += DeltaL;
            double DeltaB = pidash * Math.Cos(Q - Prad);
            details.b += DeltaB;
            double DeltaP = DeltaL * Math.Sin(AASCoordinateTransformation.DegreesToRadians(details.b)) - pidash * Math.Sin(Q) * Math.Tan(Delta);
            details.P += DeltaP;

            return details;
        }

        public static AASSelenographicMoonDetails CalculateSelenographicPositionOfSun(double JD)
        {
            double R = AASEarth.RadiusVector(JD) * 149597970;
            double Delta = AASMoon.RadiusVector(JD);
            double lambda0 = AASSun.ApparentEclipticLongitude(JD);
            double lambda = AASMoon.EclipticLongitude(JD);
            double beta = AASMoon.EclipticLatitude(JD);

            double lambdah = AASCoordinateTransformation.MapTo0To360Range(lambda0 + 180 + Delta / R * 57.296 * Math.Cos(AASCoordinateTransformation.DegreesToRadians(beta)) * Math.Sin(AASCoordinateTransformation.DegreesToRadians(lambda0 - lambda)));
            double betah = Delta / R * beta;

            //What will be the return value
            AASSelenographicMoonDetails details = new AASSelenographicMoonDetails();

            //Calculate the optical libration
            double omega = 0;
            double DeltaU = 0;
            double sigma = 0;
            double I = 0;
            double rho = 0;
            double ldash0 = 0;
            double bdash0 = 0;
            double ldash20 = 0;
            double bdash20 = 0;
            double epsilon = 0;
            CalculateOpticalLibration(JD, lambdah, betah, ref ldash0, ref bdash0, ref ldash20, ref bdash20, ref epsilon, ref omega, ref DeltaU, ref sigma, ref I, ref rho);

            details.l0 = ldash0 + ldash20;
            details.b0 = bdash0 + bdash20;
            details.c0 = AASCoordinateTransformation.MapTo0To360Range(450 - details.l0);
            return details;
        }

        public static double AltitudeOfSun(double JD, double Longitude, double Latitude)
        {
            //Calculate the selenographic details
            AASSelenographicMoonDetails selenographicDetails = CalculateSelenographicPositionOfSun(JD);

            //convert to radians
            Latitude = AASCoordinateTransformation.DegreesToRadians(Latitude);
            Longitude = AASCoordinateTransformation.DegreesToRadians(Longitude);
            selenographicDetails.b0 = AASCoordinateTransformation.DegreesToRadians(selenographicDetails.b0);
            selenographicDetails.c0 = AASCoordinateTransformation.DegreesToRadians(selenographicDetails.c0);

            return AASCoordinateTransformation.RadiansToDegrees(Math.Asin(Math.Sin(selenographicDetails.b0) * Math.Sin(Latitude) + Math.Cos(selenographicDetails.b0) * Math.Cos(Latitude) * Math.Sin(selenographicDetails.c0 + Longitude)));
        }

        public static double SunriseSunsetHelper(double JD, double Longitude, double Latitude, bool bSunrise)
        {
            double JDResult = JD;
            double Latituderad = AASCoordinateTransformation.DegreesToRadians(Latitude);
            double h;
            do
            {
                h = AltitudeOfSun(JDResult, Longitude, Latitude);
                double DeltaJD = h / (12.19075 * Math.Cos(Latituderad));
                if (bSunrise)
                    JDResult -= DeltaJD;
                else
                    JDResult += DeltaJD;
            }
            while (Math.Abs(h) > 0.001);

            return JDResult;
        }

        public static double TimeOfSunrise(double JD, double Longitude, double Latitude)
        {
            return SunriseSunsetHelper(JD, Longitude, Latitude, true);
        }

        public static double TimeOfSunset(double JD, double Longitude, double Latitude)
        {
            return SunriseSunsetHelper(JD, Longitude, Latitude, false);
        }
    }
}
