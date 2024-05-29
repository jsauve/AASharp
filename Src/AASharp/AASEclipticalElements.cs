using System;

namespace AASharp
{
    /// <summary>
    /// This class provides the algorithms which map ecliptical elements from one equinox to another. This refers to Chapter 24 in the book.
    /// </summary>
    public static class AASEclipticalElements {
        /// <param name="i0">The inclination in degrees to reduce.</param>
        /// <param name="w0">The argument of perihelion in degrees to reduce.</param>
        /// <param name="omega0">The longitude of the ascending node in degrees to reduce.</param>
        /// <param name="JD0">The initial epoch in Dynamical time to calculate for.</param>
        /// <param name="JD">The epoch in Dynamical time to reduce the elements to.</param>
        /// <returns>A struct containing the following values:
        /// <para>
        /// i - The reduced inclination in degrees.
        /// </para>
        /// <para>
        /// w - The reduced argument of perihelion in degrees.
        /// </para>
        /// <para>
        /// omega - The reduced longitude of the ascending node in degrees
        /// </para>
        /// </returns>
        public static AASEclipticalElementDetails Calculate(double i0, double w0, double omega0, double JD0, double JD)
        {
            double T = (JD0 - 2451545.0) / 36525;
            double Tsquared = T * T;
            double t = (JD - JD0) / 36525;
            double tsquared = t * t;
            double tcubed = tsquared * t;

            //Now convert to radians
            double i0rad = AASCoordinateTransformation.DegreesToRadians(i0);
            double omega0rad = AASCoordinateTransformation.DegreesToRadians(omega0);

            double eta = (47.0029 - 0.06603 * T + 0.000598 * Tsquared) * t + (-0.03302 + 0.000598 * T) * tsquared + 0.00006 * tcubed;
            eta = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, eta));

            double pi = 174.876384 * 3600 + 3289.4789 * T + 0.60622 * Tsquared - (869.8089 + 0.50491 * T) * t + 0.03536 * tsquared;
            pi = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, pi));

            double p = (5029.0966 + 2.22226 * T - 0.000042 * Tsquared) * t + (1.11113 - 0.000042 * T) * tsquared - 0.000006 * tcubed;
            p = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, p));

            double sini0rad = Math.Sin(i0rad);
            double cosi0rad = Math.Cos(i0rad);
            double sinomega0rad_pi = Math.Sin(omega0rad - pi);
            double cosomega0rad_pi = Math.Cos(omega0rad - pi);
            double sineta = Math.Sin(eta);
            double coseta = Math.Cos(eta);
            double A = sini0rad * sinomega0rad_pi;
            double B = -sineta * cosi0rad + coseta * sini0rad * cosomega0rad_pi;
            double irad = Math.Asin(Math.Sqrt(A * A + B * B));

            AASEclipticalElementDetails details = new AASEclipticalElementDetails();

            details.i = AASCoordinateTransformation.RadiansToDegrees(irad);
            double cosi = cosi0rad * coseta + sini0rad * sineta * cosomega0rad_pi;
            if (cosi < 0)
                details.i = 180 - details.i;

            double phi = pi + p;
            details.omega = AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(A, B) + phi));

            A = -sineta * sinomega0rad_pi;
            B = sini0rad * coseta - cosi0rad * sineta * cosomega0rad_pi;
            double deltaw = AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(A, B));
            details.w = AASCoordinateTransformation.MapTo0To360Range(w0 + deltaw);

            return details;
        }

        /// <param name="i0">The inclination in degrees to reduce.</param>
        /// <param name="w0">The argument of perihelion in degrees to reduce.</param>
        /// <param name="omega0">The longitude of the ascending node in degrees to reduce.</param>
        /// <returns>A struct containing the following values:
        /// <para>
        /// i - The reduced inclination in degrees.
        /// </para>
        /// <para>
        /// w - The reduced argument of perihelion in degrees.
        /// </para>
        /// <para>
        /// omega - The reduced longitude of the ascending node in degrees
        /// </para>
        /// </returns>
        public static AASEclipticalElementDetails FK4B1950ToFK5J2000(double i0, double w0, double omega0)
        {
            //convert to radians
            double L = AASCoordinateTransformation.DegreesToRadians(5.19856209);
            double J = AASCoordinateTransformation.DegreesToRadians(0.00651966);
            double i0rad = AASCoordinateTransformation.DegreesToRadians(i0);
            double omega0rad = AASCoordinateTransformation.DegreesToRadians(omega0);
            double sini0rad = Math.Sin(i0rad);
            double cosi0rad = Math.Cos(i0rad);

            //Calculate some values used later
            double cosJ = Math.Cos(J);
            double sinJ = Math.Sin(J);
            double W = L + omega0rad;
            double cosW = Math.Cos(W);
            double sinW = Math.Sin(W);
            double A = sinJ * sinW;
            double B = sini0rad * cosJ + cosi0rad * sinJ * cosW;

            //Calculate the values 
            AASEclipticalElementDetails details = new AASEclipticalElementDetails();
            details.i = AASCoordinateTransformation.RadiansToDegrees(Math.Asin(Math.Sqrt(A * A + B * B)));
            double cosi = cosi0rad * cosJ - sini0rad * sinJ * cosW;
            if (cosi < 0)
                details.i = 180 - details.i;

            details.w = AASCoordinateTransformation.MapTo0To360Range(w0 + AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(A, B)));
            details.omega = AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(sini0rad * sinW, cosi0rad * sinJ + sini0rad * cosJ * cosW)) - 4.50001688);

            return details;
        }
    }
}
