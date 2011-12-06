using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public static class AASStellarMagnitudes
    {
        public static double CombinedMagnitude(double m1, double m2)
        {
            double x = 0.4 * (m2 - m1);
            return m2 - 2.5 * Math.Log10(Math.Pow(10.0, x) + 1);
        }

        public static double CombinedMagnitude(int Magnitudes, double[] pMagnitudes)
        {
            double value = 0;
            for (int i = 0; i < Magnitudes; i++)
                value += Math.Pow(10.0, -0.4 * pMagnitudes[i]);

            return -2.5 * Math.Log10(value);
        }

        public static double BrightnessRatio(double m1, double m2)
        {
            double x = 0.4 * (m2 - m1);
            return Math.Pow(10.0, x);
        }

        public static double MagnitudeDifference(double brightnessRatio)
        {
            return 2.5 * Math.Log10(brightnessRatio);
        }
    }
}
