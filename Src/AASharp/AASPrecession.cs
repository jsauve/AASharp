using System;

namespace AASharp
{
    /// <summary>
    /// This class provides for the calculation of the slow drift that the direction of the rotational axis of the Earth undergoes over time. This refers to Chapter 21 in the book.
    /// </summary>
    public static class AASPrecession
    {
        /// <param name="t">The number of years from the starting epoch, negative in the past and positive in the future.</param>
        /// <param name="Alpha">The right ascension expressed as an hour angle.</param>
        /// <param name="Delta">The declination in degrees.</param>
        /// <param name="PMAlpha">The proper motion in right ascension in arc seconds per year.</param>
        /// <param name="PMDelta">The proper motion in declination in arc seconds per year.</param>
        /// <returns>Returns the converted equatorial coordinates in a AAS2DCoordinate class. The x value in the class corresponds to the right ascension expressed as an hour angle and the y value corresponds to the declination in degrees.</returns>
        public static AAS2DCoordinate AdjustPositionUsingUniformProperMotion(double t, double Alpha, double Delta, double PMAlpha, double PMDelta)
        {
            AAS2DCoordinate value = new AAS2DCoordinate {X = Alpha + (PMAlpha * t / 3600), Y = Delta + (PMDelta * t / 3600)};

            return value;
        }

        /// <param name="r">The stars distance in parsecs.</param>
        /// <param name="DeltaR">The radial velocity  in km/s.</param>
        /// <param name="t">The number of years from the starting epoch, negative in the past and positive in the future.</param>
        /// <param name="Alpha">The right ascension expression as an hour angle.</param>
        /// <param name="Delta">The declination in degrees.</param>
        /// <param name="PMAlpha">The proper motion in right ascension in arc seconds per year.</param>
        /// <param name="PMDelta">The proper motion in declination in arc seconds per year.</param>
        /// <returns>Returns the converted equatorial coordinates in a AAS2DCoordinate class. The x value in the class corresponds to the right ascension expressed as an hour angle and the y value corresponds to the declination in degrees.</returns>
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

            AAS2DCoordinate value = new AAS2DCoordinate();
            value.X = AASCoordinateTransformation.MapTo0To24Range(AASCoordinateTransformation.RadiansToHours(Math.Atan2(y, x)));
            value.Y = AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(z, Math.Sqrt(x * x + y * y)));

            return value;
        }

        /// <param name="Alpha">The right ascension in hours of the object at time JD0.</param>
        /// <param name="Delta">The declination in degrees of the object at time JD0.</param>
        /// <param name="JD0">The date in Dynamical time corresponding to the initial epoch.</param>
        /// <param name="JD">The date in Dynamical time corresponding to the final epoch.</param>
        /// <returns>Returns the precessed equatorial coordinates in a AAS2DCoordinate class. The x value in the class corresponds to the right ascension as an hour angle and the y value corresponds to the declination in degrees.</returns>
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

            double sigma = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, (2306.2181 + 1.39656 * T - 0.000139 * Tsquared) * t + (0.30188 - 0.000344 * T) * tsquared + 0.017998 * tcubed));
            double zeta = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, (2306.2181 + 1.39656 * T - 0.000139 * Tsquared) * t + (1.09468 + 0.000066 * T) * tsquared + 0.018203 * tcubed));
            double phi = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, (2004.3109 - 0.8533 * T - 0.000217 * Tsquared) * t - (0.42665 + 0.000217 * T) * tsquared - 0.041833 * tcubed));
            double A = Math.Cos(Delta) * Math.Sin(Alpha + sigma);
            double B = Math.Cos(phi) * Math.Cos(Delta) * Math.Cos(Alpha + sigma) - Math.Sin(phi) * Math.Sin(Delta);
            double C = Math.Sin(phi) * Math.Cos(Delta) * Math.Cos(Alpha + sigma) + Math.Cos(phi) * Math.Sin(Delta);

            AAS2DCoordinate value = new AAS2DCoordinate();
            value.X = AASCoordinateTransformation.MapTo0To24Range(AASCoordinateTransformation.RadiansToHours(Math.Atan2(A, B) + zeta));
            value.Y = AASCoordinateTransformation.RadiansToDegrees(Math.Asin(C));

            return value;
        }

        /// <param name="Alpha">The right ascension in hours of the object at time JD in the FK4 system.</param>
        /// <param name="Delta">The declination in degrees of the object at time JD in the FK4 system.</param>
        /// <param name="JD0">The date in Dynamical time corresponding to the initial epoch.</param>
        /// <param name="JD">The date in Dynamical time corresponding to the final epoch.</param>
        /// <returns>Returns the converted equatorial coordinates in a AAS2DCoordinate class. The x value in the class corresponds to the equatorial right ascension in the FK5 system as an hour angle and the y value corresponds to the declination in the FK5 system in degrees.</returns>
        public static AAS2DCoordinate PrecessEquatorialFK4(double Alpha, double Delta, double JD0, double JD)
        {
            double T = (JD0 - 2415020.3135) / 36524.2199;
            double t = (JD - JD0) / 36524.2199;
            double tsquared = t * t;
            double tcubed = tsquared * t;

            //Now convert to radians
            Alpha = AASCoordinateTransformation.HoursToRadians(Alpha);
            Delta = AASCoordinateTransformation.DegreesToRadians(Delta);

            double sigma = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, (2304.250 + 1.396 * T) * t + 0.302 * tsquared + 0.018 * tcubed));
            double zeta = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, 0.791 * tsquared + 0.001 * tcubed)) + sigma;
            double phi = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, (2004.682 - 0.853 * T) * t - 0.426 * tsquared - 0.042 * tcubed));
            double A = Math.Cos(Delta) * Math.Sin(Alpha + sigma);
            double B = Math.Cos(phi) * Math.Cos(Delta) * Math.Cos(Alpha + sigma) - Math.Sin(phi) * Math.Sin(Delta);
            double C = Math.Sin(phi) * Math.Cos(Delta) * Math.Cos(Alpha + sigma) + Math.Cos(phi) * Math.Sin(Delta);

            double DeltaAlpha = AASCoordinateTransformation.DMSToDegrees(0, 0, 0.0775 + 0.0850 * T);
            AAS2DCoordinate value = new AAS2DCoordinate();
            value.X = AASCoordinateTransformation.MapTo0To24Range(AASCoordinateTransformation.RadiansToHours(Math.Atan2(A, B) + zeta) + DeltaAlpha);
            value.Y = AASCoordinateTransformation.RadiansToDegrees(Math.Asin(C));

            return value;
        }

        /// <param name="Lambda">The ecliptical longitude in degrees.</param>
        /// <param name="Beta">The ecliptical latitude of the star in degrees.</param>
        /// <param name="JD0">The date in Dynamical time corresponding to the initial epoch.</param>
        /// <param name="JD">The date in Dynamical time corresponding to the final epoch.</param>
        /// <returns>Returns the converted ecliptic coordinates in a AAS2DCoordinate class. The x value in the class corresponds to the ecliptical longitude in degrees and the y value corresponds to the ecliptical latitude in degrees.</returns>
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

            double eta = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, (47.0029 - 0.06603 * T + 0.000598 * Tsquared) * t + (-0.03302 + 0.000598 * T) * tsquared + 0.00006 * tcubed));
            double pi = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, 174.876384 * 3600 + 3289.4789 * T + 0.60622 * Tsquared - (869.8089 + 0.50491 * T) * t + 0.03536 * tsquared));
            double p = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, (5029.0966 + 2.22226 * T - 0.000042 * Tsquared) * t + (1.11113 - 0.000042 * T) * tsquared - 0.000006 * tcubed));
            double A = Math.Cos(eta) * Math.Cos(Beta) * Math.Sin(pi - Lambda) - Math.Sin(eta) * Math.Sin(Beta);
            double B = Math.Cos(Beta) * Math.Cos(pi - Lambda);
            double C = Math.Cos(eta) * Math.Sin(Beta) + Math.Sin(eta) * Math.Cos(Beta) * Math.Sin(pi - Lambda);

            AAS2DCoordinate value = new AAS2DCoordinate();
            value.X = AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(p + pi - Math.Atan2(A, B)));
            value.Y = AASCoordinateTransformation.RadiansToDegrees(Math.Asin(C));

            return value;
        }

        /// <param name="Alpha">The right ascension expressed as an hour angle.</param>
        /// <param name="Delta">The declination in degrees.</param>
        /// <param name="Beta">The ecliptical latitude of the star in degrees.</param>
        /// <param name="PMAlpha">The proper motion in right ascension in arc seconds per year.</param>
        /// <param name="PMDelta">The proper motion of the declination in arc seconds per year.</param>
        /// <param name="Epsilon">The obliquity of the ecliptic in degrees.</param>
        /// <returns>Returns the converted ecliptic proper motions in a AAS2DCoordinate class. The x value in the class corresponds to the proper motion in ecliptical longitude in arc seconds per year and the y value corresponds to the proper motion in ecliptical latitude in arc seconds per year.</returns>
        public static AAS2DCoordinate EquatorialPMToEcliptic(double Alpha, double Delta, double Beta, double PMAlpha, double PMDelta, double Epsilon)
        {
            //Convert to radians
            Epsilon = AASCoordinateTransformation.DegreesToRadians(Epsilon);
            Alpha = AASCoordinateTransformation.HoursToRadians(Alpha);
            Delta = AASCoordinateTransformation.DegreesToRadians(Delta);
            Beta = AASCoordinateTransformation.DegreesToRadians(Beta);

            double cosb = Math.Cos(Beta);
            double sinEpsilon = Math.Sin(Epsilon);

            AAS2DCoordinate value = new AAS2DCoordinate();
            value.X = (PMDelta * sinEpsilon * Math.Cos(Alpha) + PMAlpha * Math.Cos(Delta) * (Math.Cos(Epsilon) * Math.Cos(Delta) + sinEpsilon * Math.Sin(Delta) * Math.Sin(Alpha))) / (cosb * cosb);
            value.Y = (PMDelta * (Math.Cos(Epsilon) * Math.Cos(Delta) + sinEpsilon * Math.Sin(Delta) * Math.Sin(Alpha)) - PMAlpha * sinEpsilon * Math.Cos(Alpha) * Math.Cos(Delta)) / cosb;

            return value;
        }
    }
}
