using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    public static class AASRefraction
    {
        public static double AASRefractionRefractionFromApparent(double Altitude, double Pressure, double Temperature)
        {
            //return a constant value from this method if the altitude is below a specific value
            if (Altitude <= -1.6962987799993996)
                Altitude = -1.6962987799993996;

            double value = 1 / (Math.Tan(AASCoordinateTransformation.DegreesToRadians(Altitude + 7.31 / (Altitude + 4.4)))) + 0.0013515;
            value *= (Pressure / 1010 * 283 / (273 + Temperature));
            value /= 60;
            return value;
        }

        public static double AASRefractionRefractionFromTrue(double Altitude, double Pressure, double Temperature)
        {
            //return a constant value from this method if the altitude is below a specific value
            if (Altitude <= -1.9006387000003735)
                Altitude = -1.9006387000003735;

            double value = 1.02 / (Math.Tan(AASCoordinateTransformation.DegreesToRadians(Altitude + 10.3 / (Altitude + 5.11)))) + 0.0019279;
            value *= (Pressure / 1010 * 283 / (273 + Temperature));
            value /= 60;
            return value;
        }
    }
}
