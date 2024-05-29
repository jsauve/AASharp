using System;

namespace AASharp
{
    /// <summary>
    /// This class provides for calculation of various physical parameters related to the Sun. This refers to Chapter 29 in the book.
    /// </summary>
    public static class AASPhysicalSun
    {
        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <param name="bHighPrecision">If true then use the full VSOP87 theory instead of the truncated version as provided in Meeus's book.</param>
        /// <returns>An instance of AASPhysicalSunDetails class with the details.</returns>
        public static AASPhysicalSunDetails Calculate(double JD, bool bHighPrecision)
        {
            double theta = AASCoordinateTransformation.MapTo0To360Range((JD - 2398220) * 360 / 25.38);
            double I = 7.25;
            double K = 73.6667 + 1.3958333 * (JD - 2396758) / 36525;

            //Calculate the apparent longitude of the sun (excluding the effect of nutation)
            double L = AASEarth.EclipticLongitude(JD, bHighPrecision);
            double R = AASEarth.RadiusVector(JD, bHighPrecision);
            double SunLong = L + 180 - AASCoordinateTransformation.DMSToDegrees(0, 0, 20.4898 / R);

            double epsilon = AASNutation.TrueObliquityOfEcliptic(JD);

            //Convert to radians
            epsilon = AASCoordinateTransformation.DegreesToRadians(epsilon);
            SunLong = AASCoordinateTransformation.DegreesToRadians(SunLong);
            K = AASCoordinateTransformation.DegreesToRadians(K);
            I = AASCoordinateTransformation.DegreesToRadians(I);
            theta = AASCoordinateTransformation.DegreesToRadians(theta);

            double x = Math.Atan(-Math.Cos(SunLong) * Math.Tan(epsilon));
            double y = Math.Atan(-Math.Cos(SunLong - K) * Math.Tan(I));

            AASPhysicalSunDetails details = new AASPhysicalSunDetails();
            details.P = AASCoordinateTransformation.RadiansToDegrees(x + y);
            details.B0 = AASCoordinateTransformation.RadiansToDegrees(Math.Asin(Math.Sin(SunLong - K) * Math.Sin(I)));
            double SunLongMinusK = SunLong - K;
            double eta = Math.Atan2(-Math.Sin(SunLongMinusK) * Math.Cos(I), -Math.Cos(SunLongMinusK));
            details.L0 = AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(eta - theta));

            return details;
        }

        public static double TimeOfStartOfRotation(long C)
        {
            double JED = 2398140.2270 + 27.2752316 * C;

            double M = AASCoordinateTransformation.MapTo0To360Range(281.96 + 26.882476 * C);
            M = AASCoordinateTransformation.DegreesToRadians(M);

            JED += (0.1454 * Math.Sin(M) - 0.0085 * Math.Sin(2 * M) - 0.0141 * Math.Cos(2 * M));

            return JED;
        }
    }
}
