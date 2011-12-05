using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public class AASSaturnRingDetails
    {
        public double B;
        public double Bdash;
        public double P;
        public double a;
        public double b;
        public double DeltaU;
    }

    public static class AASSaturnRings
    {
        public static AASSaturnRingDetails Calculate(double JD)
        {
            //What will be the return value
            AASSaturnRingDetails details = new AASSaturnRingDetails();

            double T = (JD - 2451545) / 36525;
            double T2 = T * T;

            //Step 1. Calculate the inclination of the plane of the ring and the longitude of the ascending node referred to the ecliptic and mean equinox of the date
            double i = 28.075216 - 0.012998 * T + 0.000004 * T2;
            double irad = AASCoordinateTransformation.DegreesToRadians(i);
            double omega = 169.508470 + 1.394681 * T + 0.000412 * T2;
            double omegarad = AASCoordinateTransformation.DegreesToRadians(omega);

            //Step 2. Calculate the heliocentric longitude, latitude and radius vector of the Earth in the FK5 system
            double l0 = AASEarth.EclipticLongitude(JD);
            double b0 = AASEarth.EclipticLatitude(JD);
            l0 += AASFK5.CorrectionInLongitude(l0, b0, JD);
            double l0rad = AASCoordinateTransformation.DegreesToRadians(l0);
            b0 += AASFK5.CorrectionInLatitude(l0, JD);
            double b0rad = AASCoordinateTransformation.DegreesToRadians(b0);
            double R = AASEarth.RadiusVector(JD);

            //Step 3. Calculate the corresponding coordinates l,b,r for Saturn but for the instance t-lightraveltime
            double DELTA = 9;
            double PreviousEarthLightTravelTime = 0;
            double EarthLightTravelTime = AASElliptical.DistanceToLightTime(DELTA);
            double JD1 = JD - EarthLightTravelTime;
            bool bIterate = true;
            double x = 0;
            double y = 0;
            double z = 0;
            double l = 0;
            double b = 0;
            double r = 0;
            while (bIterate)
            {
                //Calculate the position of Saturn
                l = AASSaturn.EclipticLongitude(JD1);
                b = AASSaturn.EclipticLatitude(JD1);
                l += AASFK5.CorrectionInLongitude(l, b, JD1);
                b += AASFK5.CorrectionInLatitude(l, JD1);

                double lrad = AASCoordinateTransformation.DegreesToRadians(l);
                double brad = AASCoordinateTransformation.DegreesToRadians(b);
                r = AASSaturn.RadiusVector(JD1);

                //Step 4
                x = r * Math.Cos(brad) * Math.Cos(lrad) - R * Math.Cos(l0rad);
                y = r * Math.Cos(brad) * Math.Sin(lrad) - R * Math.Sin(l0rad);
                z = r * Math.Sin(brad) - R * Math.Sin(b0rad);
                DELTA = Math.Sqrt(x * x + y * y + z * z);
                EarthLightTravelTime = AASElliptical.DistanceToLightTime(DELTA);

                //Prepare for the next loop around
                bIterate = (Math.Abs(EarthLightTravelTime - PreviousEarthLightTravelTime) > 2E-6); //2E-6 corresponds to 0.17 of a second
                if (bIterate)
                {
                    JD1 = JD - EarthLightTravelTime;
                    PreviousEarthLightTravelTime = EarthLightTravelTime;
                }
            }

            //Step 5. Calculate Saturn's geocentric Longitude and Latitude
            double lambda = Math.Atan2(y, x);
            double beta = Math.Atan2(z, Math.Sqrt(x * x + y * y));

            //Step 6. Calculate B, a and b
            details.B = Math.Asin(Math.Sin(irad) * Math.Cos(beta) * Math.Sin(lambda - omegarad) - Math.Cos(irad) * Math.Sin(beta));
            details.a = 375.35 / DELTA;
            details.b = details.a * Math.Sin(Math.Abs(details.B));
            details.B = AASCoordinateTransformation.RadiansToDegrees(details.B);

            //Step 7. Calculate the longitude of the ascending node of Saturn's orbit
            double N = 113.6655 + 0.8771 * T;
            double Nrad = AASCoordinateTransformation.DegreesToRadians(N);
            double ldash = l - 0.01759 / r;
            double ldashrad = AASCoordinateTransformation.DegreesToRadians(ldash);
            double bdash = b - 0.000764 * Math.Cos(ldashrad - Nrad) / r;
            double bdashrad = AASCoordinateTransformation.DegreesToRadians(bdash);

            //Step 8. Calculate Bdash
            details.Bdash = AASCoordinateTransformation.RadiansToDegrees(Math.Asin(Math.Sin(irad) * Math.Cos(bdashrad) * Math.Sin(ldashrad - omegarad) - Math.Cos(irad) * Math.Sin(bdashrad)));

            //Step 9. Calculate DeltaU
            double U1 = Math.Atan2(Math.Sin(irad) * Math.Sin(bdashrad) + Math.Cos(irad) * Math.Cos(bdashrad) * Math.Sin(ldashrad - omegarad), Math.Cos(bdashrad) * Math.Cos(ldashrad - omegarad));
            double U2 = Math.Atan2(Math.Sin(irad) * Math.Sin(beta) + Math.Cos(irad) * Math.Cos(beta) * Math.Sin(lambda - omegarad), Math.Cos(beta) * Math.Cos(lambda - omegarad));
            details.DeltaU = AASCoordinateTransformation.RadiansToDegrees(Math.Abs(U1 - U2));

            //Step 10. Calculate the Nutations 
            double Obliquity = AASNutation.TrueObliquityOfEcliptic(JD);
            double NutationInLongitude = AASNutation.NutationInLongitude(JD);

            //Step 11. Calculate the Ecliptical longitude and latitude of the northern pole of the ring plane
            double lambda0 = omega - 90;
            double beta0 = 90 - i;

            //Step 12. Correct lambda and beta for the aberration of Saturn
            lambda += AASCoordinateTransformation.DegreesToRadians(0.005693 * Math.Cos(l0rad - lambda) / Math.Cos(beta));
            beta += AASCoordinateTransformation.DegreesToRadians(0.005693 * Math.Sin(l0rad - lambda) * Math.Sin(beta));

            //Step 13. Add nutation in longitude to lambda0 and lambda
            //double NLrad = AASCoordinateTransformation.DegreesToRadians(NutationInLongitude/3600);
            lambda = AASCoordinateTransformation.RadiansToDegrees(lambda);
            lambda += NutationInLongitude / 3600;
            lambda = AASCoordinateTransformation.MapTo0To360Range(lambda);
            lambda0 += NutationInLongitude / 3600;
            lambda0 = AASCoordinateTransformation.MapTo0To360Range(lambda0);

            //Step 14. Convert to equatorial coordinates
            beta = AASCoordinateTransformation.RadiansToDegrees(beta);
            AAS2DCoordinate GeocentricEclipticSaturn = AASCoordinateTransformation.Ecliptic2Equatorial(lambda, beta, Obliquity);
            double alpha = AASCoordinateTransformation.HoursToRadians(GeocentricEclipticSaturn.X);
            double delta = AASCoordinateTransformation.DegreesToRadians(GeocentricEclipticSaturn.Y);
            AAS2DCoordinate GeocentricEclipticNorthPole = AASCoordinateTransformation.Ecliptic2Equatorial(lambda0, beta0, Obliquity);
            double alpha0 = AASCoordinateTransformation.HoursToRadians(GeocentricEclipticNorthPole.X);
            double delta0 = AASCoordinateTransformation.DegreesToRadians(GeocentricEclipticNorthPole.Y);

            //Step 15. Calculate the Position angle
            details.P = AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(Math.Cos(delta0) * Math.Sin(alpha0 - alpha), Math.Sin(delta0) * Math.Cos(delta) - Math.Cos(delta0) * Math.Sin(delta) * Math.Cos(alpha0 - alpha)));

            return details;
        }
    }
}
