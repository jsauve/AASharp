using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    public class CAAPhysicalMarsDetails
    {
        public double DE;
        public double DS;
        public double w;
        public double P;
        public double X;
        public double k;
        public double q;
        public double d;
    }

    //Member variables


    public static class AASPhysicalMars
    {
        public static CAAPhysicalMarsDetails Calculate(double JD)
        {
            //What will be the return value
            CAAPhysicalMarsDetails details = new CAAPhysicalMarsDetails();

            //Step 1
            double T = (JD - 2451545) / 36525;
            double Lambda0 = 352.9065 + 1.17330 * T;
            double Lambda0rad = AASCoordinateTransformation.DegreesToRadians(Lambda0);
            double Beta0 = 63.2818 - 0.00394 * T;
            double Beta0rad = AASCoordinateTransformation.DegreesToRadians(Beta0);

            //Step 2
            double l0 = AASEarth.EclipticLongitude(JD);
            double l0rad = AASCoordinateTransformation.DegreesToRadians(l0);
            double b0 = AASEarth.EclipticLatitude(JD);
            double b0rad = AASCoordinateTransformation.DegreesToRadians(b0);
            double R = AASEarth.RadiusVector(JD);

            double PreviousLightTravelTime = 0;
            double LightTravelTime = 0;
            double x = 0;
            double y = 0;
            double z = 0;
            bool bIterate = true;
            double DELTA = 0;
            double l = 0;
            double lrad = 0;
            double b = 0;
            double r = 0;
            while (bIterate)
            {
                double JD2 = JD - LightTravelTime;

                //Step 3
                l = AASMars.EclipticLongitude(JD2);
                lrad = AASCoordinateTransformation.DegreesToRadians(l);
                b = AASMars.EclipticLatitude(JD2);
                double brad = AASCoordinateTransformation.DegreesToRadians(b);
                r = AASMars.RadiusVector(JD2);

                //Step 4
                x = r * Math.Cos(brad) * Math.Cos(lrad) - R * Math.Cos(l0rad);
                y = r * Math.Cos(brad) * Math.Sin(lrad) - R * Math.Sin(l0rad);
                z = r * Math.Sin(brad) - R * Math.Sin(b0rad);
                DELTA = Math.Sqrt(x * x + y * y + z * z);
                LightTravelTime = AASElliptical.DistanceToLightTime(DELTA);

                //Prepare for the next loop around
                bIterate = (Math.Abs(LightTravelTime - PreviousLightTravelTime) > 2E-6); //2E-6 correponds to 0.17 of a second
                if (bIterate)
                    PreviousLightTravelTime = LightTravelTime;
            }

            //Step 5
            double lambdarad = Math.Atan2(y, x);
            double lambda = AASCoordinateTransformation.RadiansToDegrees(lambdarad);
            double betarad = Math.Atan2(z, Math.Sqrt(x * x + y * y));
            double beta = AASCoordinateTransformation.RadiansToDegrees(betarad);

            //Step 6
            details.DE = AASCoordinateTransformation.RadiansToDegrees(Math.Asin(-Math.Sin(Beta0rad) * Math.Sin(betarad) - Math.Cos(Beta0rad) * Math.Cos(betarad) * Math.Cos(Lambda0rad - lambdarad)));

            //Step 7
            double N = 49.5581 + 0.7721 * T;
            double Nrad = AASCoordinateTransformation.DegreesToRadians(N);

            double ldash = l - 0.00697 / r;
            double ldashrad = AASCoordinateTransformation.DegreesToRadians(ldash);
            double bdash = b - 0.000225 * (Math.Cos(lrad - Nrad) / r);
            double bdashrad = AASCoordinateTransformation.DegreesToRadians(bdash);

            //Step 8
            details.DS = AASCoordinateTransformation.RadiansToDegrees(Math.Asin(-Math.Sin(Beta0rad) * Math.Sin(bdashrad) - Math.Cos(Beta0rad) * Math.Cos(bdashrad) * Math.Cos(Lambda0rad - ldashrad)));

            //Step 9
            double W = AASCoordinateTransformation.MapTo0To360Range(11.504 + 350.89200025 * (JD - LightTravelTime - 2433282.5));

            //Step 10
            double e0 = AASNutation.MeanObliquityOfEcliptic(JD);
            double e0rad = AASCoordinateTransformation.DegreesToRadians(e0);
            AAS2DCoordinate PoleEquatorial = AASCoordinateTransformation.Ecliptic2Equatorial(Lambda0, Beta0, e0);
            double alpha0rad = AASCoordinateTransformation.HoursToRadians(PoleEquatorial.X);
            double delta0rad = AASCoordinateTransformation.DegreesToRadians(PoleEquatorial.Y);

            //Step 11
            double u = y * Math.Cos(e0rad) - z * Math.Sin(e0rad);
            double v = y * Math.Sin(e0rad) + z * Math.Cos(e0rad);
            double alpharad = Math.Atan2(u, x);
            double alpha = AASCoordinateTransformation.RadiansToHours(alpharad);
            double deltarad = Math.Atan2(v, Math.Sqrt(x * x + u * u));
            double delta = AASCoordinateTransformation.RadiansToDegrees(deltarad);
            double xi = Math.Atan2(Math.Sin(delta0rad) * Math.Cos(deltarad) * Math.Cos(alpha0rad - alpharad) - Math.Sin(deltarad) * Math.Cos(delta0rad), Math.Cos(deltarad) * Math.Sin(alpha0rad - alpharad));

            //Step 12
            details.w = AASCoordinateTransformation.MapTo0To360Range(W - AASCoordinateTransformation.RadiansToDegrees(xi));

            //Step 13
            double NutationInLongitude = AASNutation.NutationInLongitude(JD);
            double NutationInObliquity = AASNutation.NutationInObliquity(JD);

            //Step 14
            lambda += 0.005693 * Math.Cos(l0rad - lambdarad) / Math.Cos(betarad);
            beta += 0.005693 * Math.Sin(l0rad - lambdarad) * Math.Sin(betarad);

            //Step 15
            Lambda0 += NutationInLongitude / 3600;
            lambda += NutationInLongitude / 3600;
            e0 += NutationInObliquity / 3600;

            //Step 16
            AAS2DCoordinate ApparentPoleEquatorial = AASCoordinateTransformation.Ecliptic2Equatorial(Lambda0, Beta0, e0);
            double alpha0dash = AASCoordinateTransformation.HoursToRadians(ApparentPoleEquatorial.X);
            double delta0dash = AASCoordinateTransformation.DegreesToRadians(ApparentPoleEquatorial.Y);
            AAS2DCoordinate ApparentMars = AASCoordinateTransformation.Ecliptic2Equatorial(lambda, beta, e0);
            double alphadash = AASCoordinateTransformation.HoursToRadians(ApparentMars.X);
            double deltadash = AASCoordinateTransformation.DegreesToRadians(ApparentMars.Y);

            //Step 17
            details.P = AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(Math.Cos(delta0dash) * Math.Sin(alpha0dash - alphadash), Math.Sin(delta0dash) * Math.Cos(deltadash) - Math.Cos(delta0dash) * Math.Sin(deltadash) * Math.Cos(alpha0dash - alphadash))));

            //Step 18
            double SunLambda = AASSun.GeometricEclipticLongitude(JD);
            double SunBeta = AASSun.GeometricEclipticLatitude(JD);
            AAS2DCoordinate SunEquatorial = AASCoordinateTransformation.Ecliptic2Equatorial(SunLambda, SunBeta, e0);
            details.X = AASMoonIlluminatedFraction.PositionAngle(SunEquatorial.X, SunEquatorial.Y, alpha, delta);

            //Step 19
            details.d = 9.36 / DELTA;
            details.k = AASIlluminatedFraction.IlluminatedFraction(r, R, DELTA);
            details.q = (1 - details.k) * details.d;

            return details;
        }
    }
}
