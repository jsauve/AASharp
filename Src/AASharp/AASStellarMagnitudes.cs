using System;

namespace AASharp
{
    /// <summary>
    /// This class provides for calculation of the combined magnitude of two stars. This refers to Chapter 56 in the book.
    /// </summary>
    public static class AASStellarMagnitudes
    {
        /// <param name="m1">The magnitude of the first star.</param>
        /// <param name="m2">The magnitude of the second star.</param>
        /// <returns>the combined magnitude of two stars.</returns>
        public static double CombinedMagnitude(double m1, double m2)
        {
            double x = 0.4 * (m2 - m1);
            return m2 - 2.5 * Math.Log10(Math.Pow(10.0, x) + 1);
        }

        /// <param name="Magnitudes">The number of magnitudes to combine from "pMagnitudes".</param>
        /// <param name="pMagnitudes">The sum of all the star magnitudes.</param>
        /// <returns>the combined magnitude of more that two stars.</returns>
        public static double CombinedMagnitude(int Magnitudes, double[] pMagnitudes)
        {
            double value = 0;
            for (int i = 0; i < Magnitudes; i++)
                value += Math.Pow(10.0, -0.4 * pMagnitudes[i]);

            return -2.5 * Math.Log10(value);
        }

        /// <param name="m1">The magnitude of the first star.</param>
        /// <param name="m2">The magnitude of the second star.</param>
        /// <returns>the ratio of the apparent luminosities of the two stars.</returns>
        public static double BrightnessRatio(double m1, double m2)
        {
            double x = 0.4 * (m2 - m1);
            return Math.Pow(10.0, x);
        }

        /// <param name="brightnessRatio">The ratio of the apparent luminosities of the two stars.</param>
        /// <returns>the difference in magnitude between the stars.</returns>
        public static double MagnitudeDifference(double brightnessRatio)
        {
            return 2.5 * Math.Log10(brightnessRatio);
        }
    }
}
