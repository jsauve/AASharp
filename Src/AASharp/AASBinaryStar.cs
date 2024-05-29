using System;

namespace AASharp
{
    /// <summary>
    /// This class provides for calculation of the position of a Binary Star system. This refers to Chapter 57 in the book.
    /// </summary>
    public static class AASBinaryStar
    {
        /// <param name="t">The time given in years and decimals to perform the calculation for.</param>
        /// <param name="P">The period of revolution expressed in mean solar years.</param>
        /// <param name="T">The time of periastron passage given in years and decimals.</param>
        /// <param name="e">Eccentricity of the true orbit.</param>
        /// <param name="a">The semi major axis expressed in seconds of a degree.</param>
        /// <param name="i">The inclination of the plane of the true orbit in degrees to the plane at right angles to the line of sight.</param>
        /// <param name="omega">The position angle of the ascending node in degrees.</param>
        /// <param name="w">The longitude of the periastron in degrees.</param>
        /// <returns>A class containing
        /// <para>
        /// r - The radius vector of the secondary star in arc seconds of a degree.
        /// </para>
        /// <para>
        /// Theta - The apparent position angle of the secondary star in degrees.
        /// </para>
        /// <para>
        /// Rho - The angular separation between the two stars in arc seconds of a degree.
        /// </para>
        /// <para>
        /// x - The x cartesian coordinate value of the secondary star in arc seconds of a degree.
        /// </para>
        /// <para>
        /// y - The y cartesian coordinate value of the secondary star in arc seconds of a degree.
        /// </para>
        /// </returns>
        public static AASBinaryStarDetails Calculate(double t, double P, double T, double e, double a, double i, double omega, double w)
        {
            double n = 360 / P;
            double M = AASCoordinateTransformation.MapTo0To360Range(n * (t - T));
            double E = AASKepler.Calculate(M, e);
            E = AASCoordinateTransformation.DegreesToRadians(E);
            i = AASCoordinateTransformation.DegreesToRadians(i);
            w = AASCoordinateTransformation.DegreesToRadians(w);
            omega = AASCoordinateTransformation.DegreesToRadians(omega);

            AASBinaryStarDetails details = new AASBinaryStarDetails { r = a * (1 - e * Math.Cos(E)) };

            double v = Math.Atan(Math.Sqrt((1 + e) / (1 - e)) * Math.Tan(E / 2)) * 2;
            details.Theta = Math.Atan2(Math.Sin(v + w) * Math.Cos(i), Math.Cos(v + w)) + omega;
            details.Theta = AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(details.Theta));

            double sinvw = Math.Sin(v + w);
            double cosvw = Math.Cos(v + w);
            double cosi = Math.Cos(i);
            details.Rho = details.r * Math.Sqrt((sinvw * sinvw * cosi * cosi) + (cosvw * cosvw));

            return details;
        }

        /// <param name="e">Eccentricity of the true orbit.</param>
        /// <param name="i">The inclination of the plane of the true orbit in degrees to the plane at right angles to the line of sight.</param>
        /// <param name="w">The longitude of the periastron in degrees.</param>
        /// <returns>The apparent eccentricity of the binary star orbit</returns>
        public static double ApparentEccentricity(double e, double i, double w)
        {
            i = AASCoordinateTransformation.DegreesToRadians(i);
            w = AASCoordinateTransformation.DegreesToRadians(w);

            double cosi = Math.Cos(i);
            double cosw = Math.Cos(w);
            double sinw = Math.Sin(w);
            double esquared = e * e;
            double A = (1 - esquared * cosw * cosw) * cosi * cosi;
            double B = esquared * sinw * cosw * cosi;
            double C = 1 - esquared * sinw * sinw;
            double D = (A - C) * (A - C) + 4 * B * B;

            double sqrtD = Math.Sqrt(D);
            return Math.Sqrt(2 * sqrtD / (A + C + sqrtD));
        }
    }
}
