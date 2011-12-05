using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public class AASPhysicalSunDetails
    {
        public double P;
        public double B0;
        public double L0;
    }

    public static class AASPhysicalSun
    {
        public static AASPhysicalSunDetails Calculate(double JD)
        {
            double theta = AASCoordinateTransformation.MapTo0To360Range((JD - 2398220) * 360 / 25.38);
            double I = 7.25;
            double K = 73.6667 + 1.3958333 * (JD - 2396758) / 36525;

            //Calculate the apparent longitude of the sun (excluding the effect of nutation)
            double L = AASEarth.EclipticLongitude(JD);
            double R = AASEarth.RadiusVector(JD);
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

            double eta = Math.Atan(Math.Tan(SunLong - K) * Math.Cos(I));
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
