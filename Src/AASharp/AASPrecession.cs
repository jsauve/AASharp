using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public static class AASPrecession
    {
        public static AAS2DCoordinate AdjustPositionUsingUniformProperMotion(double t, double Alpha, double Delta, double PMAlpha, double PMDelta)
        {
            AAS2DCoordinate value = new AAS2DCoordinate { X = Alpha + (PMAlpha * t / 3600), Y = Delta + (PMDelta * t / 3600) };

            return value;
        }

        public static AAS2DCoordinate AdjustPositionUsingMotionInSpace(double r, double DeltaR, double t, double Alpha, double Delta, double PMAlpha, double PMDelta)
        {
            //Convert DeltaR from km/s to Parsecs / Year
            DeltaR /= 977792;

            //Convert from seconds of time to Radians / Year
            PMAlpha /= 13751;

            //Convert from seconds of arc to Radians / Year
            PMDelta /= 206265;

            //Now convert to radians
            Alpha = AASCoordinateTransformation.HoursToRadians(Alpha);
            Delta = AASCoordinateTransformation.DegreesToRadians(Delta);

            double x = r * Math.Cos(Delta) * Math.Cos(Alpha);
            double y = r * Math.Cos(Delta) * Math.Sin(Alpha);
            double z = r * Math.Sin(Delta);

            double DeltaX = x / r * DeltaR - z * PMDelta * Math.Cos(Alpha) - y * PMAlpha;
            double DeltaY = y / r * DeltaR - z * PMDelta * Math.Sin(Alpha) + x * PMAlpha;
            double DeltaZ = z / r * DeltaR + r * PMDelta * Math.Cos(Delta);

            x += t * DeltaX;
            y += t * DeltaY;
            z += t * DeltaZ;

            AAS2DCoordinate value = new AAS2DCoordinate { X = AASCoordinateTransformation.RadiansToHours(Math.Atan2(y, x)) };
            if (value.X < 0)
                value.X += 24;

            value.Y = AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(z, Math.Sqrt(x * x + y * y)));

            return value;
        }

        public static AAS2DCoordinate PrecessEquatorial(double Alpha, double Delta, double JD0, double JD)
        {
            double T = (JD0 - 2451545.0) / 36525;
            double Tsquared = T * T;
            double t = (JD - JD0) / 36525;
            double tsquared = t * t;
            double tcubed = tsquared * t;

            //Now convert to radians
            Alpha = AASCoordinateTransformation.HoursToRadians(Alpha);
            Delta = AASCoordinateTransformation.DegreesToRadians(Delta);

            double sigma = (2306.2181 + 1.39656 * T - 0.000139 * Tsquared) * t + (0.30188 - 0.0000344 * T) * tsquared + 0.017988 * tcubed;
            sigma = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, sigma));

            double zeta = (2306.2181 + 1.39656 * T - 0.000138 * Tsquared) * t + (1.09468 + 0.000066 * T) * tsquared + 0.018203 * tcubed;
            zeta = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, zeta));

            double phi = (2004.3109 - 0.8533 * T - 0.000217 * Tsquared) * t - (0.42665 + 0.000217 * T) * tsquared - 0.041833 * tcubed;
            phi = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, phi));

            double A = Math.Cos(Delta) * Math.Sin(Alpha + sigma);
            double B = Math.Cos(phi) * Math.Cos(Delta) * Math.Cos(Alpha + sigma) - Math.Sin(phi) * Math.Sin(Delta);
            double C = Math.Sin(phi) * Math.Cos(Delta) * Math.Cos(Alpha + sigma) + Math.Cos(phi) * Math.Sin(Delta);

            AAS2DCoordinate value = new AAS2DCoordinate { X = AASCoordinateTransformation.RadiansToHours(Math.Atan2(A, B) + zeta) };
            if (value.X < 0)
                value.X += 24;
            value.Y = AASCoordinateTransformation.RadiansToDegrees(Math.Asin(C));

            return value;
        }

        public static AAS2DCoordinate PrecessEquatorialFK4(double Alpha, double Delta, double JD0, double JD)
        {
            double T = (JD0 - 2415020.3135) / 36524.2199;
            double t = (JD - JD0) / 36524.2199;
            double tsquared = t * t;
            double tcubed = tsquared * t;

            //Now convert to radians
            Alpha = AASCoordinateTransformation.HoursToRadians(Alpha);
            Delta = AASCoordinateTransformation.DegreesToRadians(Delta);

            double sigma = (2304.250 + 1.396 * T) * t + 0.302 * tsquared + 0.018 * tcubed;
            sigma = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, sigma));

            double zeta = 0.791 * tsquared + 0.001 * tcubed;
            zeta = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, zeta));
            zeta += sigma;

            double phi = (2004.682 - 0.853 * T) * t - 0.426 * tsquared - 0.042 * tcubed;
            phi = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, phi));

            double A = Math.Cos(Delta) * Math.Sin(Alpha + sigma);
            double B = Math.Cos(phi) * Math.Cos(Delta) * Math.Cos(Alpha + sigma) - Math.Sin(phi) * Math.Sin(Delta);
            double C = Math.Sin(phi) * Math.Cos(Delta) * Math.Cos(Alpha + sigma) + Math.Cos(phi) * Math.Sin(Delta);

            AAS2DCoordinate value = new AAS2DCoordinate { X = AASCoordinateTransformation.RadiansToHours(Math.Atan2(A, B) + zeta) };
            if (value.X < 0)
                value.X += 24;
            value.Y = AASCoordinateTransformation.RadiansToDegrees(Math.Asin(C));

            return value;
        }

        public static AAS2DCoordinate PrecessEcliptic(double Lambda, double Beta, double JD0, double JD)
        {
            double T = (JD0 - 2451545.0) / 36525;
            double Tsquared = T * T;
            double t = (JD - JD0) / 36525;
            double tsquared = t * t;
            double tcubed = tsquared * t;

            //Now convert to radians
            Lambda = AASCoordinateTransformation.DegreesToRadians(Lambda);
            Beta = AASCoordinateTransformation.DegreesToRadians(Beta);

            double eta = (47.0029 - 0.06603 * T + 0.000598 * Tsquared) * t + (-0.03302 + 0.000598 * T) * tsquared + 0.00006 * tcubed;
            eta = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, eta));

            double pi = 174.876384 * 3600 + 3289.4789 * T + 0.60622 * Tsquared - (869.8089 + 0.50491 * T) * t + 0.03536 * tsquared;
            pi = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, pi));

            double p = (5029.0966 + 2.22226 * T - 0.000042 * Tsquared) * t + (1.11113 - 0.000042 * T) * tsquared - 0.000006 * tcubed;
            p = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, p));

            double A = Math.Cos(eta) * Math.Cos(Beta) * Math.Sin(pi - Lambda) - Math.Sin(eta) * Math.Sin(Beta);
            double B = Math.Cos(Beta) * Math.Cos(pi - Lambda);
            double C = Math.Cos(eta) * Math.Sin(Beta) + Math.Sin(eta) * Math.Cos(Beta) * Math.Sin(pi - Lambda);

            AAS2DCoordinate value = new AAS2DCoordinate { X = AASCoordinateTransformation.RadiansToDegrees(p + pi - Math.Atan2(A, B)) };
            if (value.X < 0)
                value.X += 360;
            value.Y = AASCoordinateTransformation.RadiansToDegrees(Math.Asin(C));

            return value;
        }

        public static AAS2DCoordinate EquatorialPMToEcliptic(double Alpha, double Delta, double Beta, double PMAlpha, double PMDelta, double Epsilon)
        {
            //Convert to radians
            Epsilon = AASCoordinateTransformation.DegreesToRadians(Epsilon);
            Alpha = AASCoordinateTransformation.HoursToRadians(Alpha);
            Delta = AASCoordinateTransformation.DegreesToRadians(Delta);
            Beta = AASCoordinateTransformation.DegreesToRadians(Beta);

            double cosb = Math.Cos(Beta);
            double sinEpsilon = Math.Sin(Epsilon);

            AAS2DCoordinate value = new AAS2DCoordinate { X = (PMDelta * sinEpsilon * Math.Cos(Alpha) + PMAlpha * Math.Cos(Delta) * (Math.Cos(Epsilon) * Math.Cos(Delta) + sinEpsilon * Math.Sin(Delta) * Math.Sin(Alpha))) / (cosb * cosb), Y = (PMDelta * (Math.Cos(Epsilon) * Math.Cos(Delta) + sinEpsilon * Math.Sin(Delta) * Math.Sin(Alpha)) - PMAlpha * sinEpsilon * Math.Cos(Alpha) * Math.Cos(Delta)) / cosb };

            return value;
        }
    }
}
