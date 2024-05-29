using System;

namespace AASharp
{
    /// <summary>
    /// This class provides for calculation of the Equation of Time. This refers to Chapter 28 in the book.
    /// </summary>
    public static class AASEquationOfTime
    {
        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <param name="bHighPrecision">If true then use the full VSOP87 theory instead of the truncated version as provided in Meeus's book.</param>
        /// <returns>the equation of time in decimal minutes.</returns>
        public static double Calculate(double JD, bool bHighPrecision)
        {
            double rho = (JD - 2451545) / 365250;
            double rhosquared = rho * rho;
            double rhocubed = rhosquared * rho;
            double rho4 = rhocubed * rho;
            double rho5 = rho4 * rho;

            //Calculate the Suns mean longitude
            double L0 = AASCoordinateTransformation.MapTo0To360Range(280.4664567 + 360007.6982779 * rho + 0.03032028 * rhosquared +
            rhocubed / 49931 - rho4 / 15300 - rho5 / 2000000);

            //Calculate the Suns apparent right ascension
            double SunLong = AASSun.ApparentEclipticLongitude(JD, bHighPrecision);
            double SunLat = AASSun.ApparentEclipticLatitude(JD, bHighPrecision);
            double epsilon = AASNutation.TrueObliquityOfEcliptic(JD);
            AAS2DCoordinate Equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(SunLong, SunLat, epsilon);

            epsilon = AASCoordinateTransformation.DegreesToRadians(epsilon);
            double E = L0 - 0.0057183 - Equatorial.X * 15 + AASCoordinateTransformation.DMSToDegrees(0, 0, AASNutation.NutationInLongitude(JD)) * Math.Cos(epsilon);
            if (E > 180)
                E = -(360 - E);
            E *= 4; //Convert to minutes of time

            return E;
        }
    }
}
