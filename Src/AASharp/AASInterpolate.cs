using System;

namespace AASharp
{
    /// <summary>
    /// This class provides the algorithms for interpolation. This refers to Chapter 3 in the book.
    /// </summary>
    public static class AASInterpolate
    {
        /// <summary>
        /// Interpolates a function from 3 points.
        /// </summary>
        /// <param name="n">The interpolating factor.</param>
        /// <param name="Y1">The first Y value to interpolate from.</param>
        /// <param name="Y2">The second Y value to interpolate from.</param>
        /// <param name="Y3">The third Y value to interpolate from.</param>
        /// <returns>The interpolated Y value.</returns>
        public static double Interpolate(double n, double Y1, double Y2, double Y3)
        {
            double a = Y2 - Y1;
            double b = Y3 - Y2;
            double c = Y1 + Y3 - 2 * Y2;

            return Y2 + n / 2 * (a + b + n * c);
        }

        /// <summary>
        /// Interpolates a function from 5 points.
        /// </summary>
        /// <param name="n">The interpolating factor.</param>
        /// <param name="Y1">The first Y value to interpolate from.</param>
        /// <param name="Y2">The second Y value to interpolate from.</param>
        /// <param name="Y3">The third Y value to interpolate from.</param>
        /// <param name="Y4">The fourth Y value to interpolate from.</param>
        /// <param name="Y5">The fifth Y value to interpolate from.</param>
        /// <returns>The interpolated Y value.</returns>
        public static double Interpolate(double n, double Y1, double Y2, double Y3, double Y4, double Y5)
        {
            double A = Y2 - Y1;
            double B = Y3 - Y2;
            double C = Y4 - Y3;
            double D = Y5 - Y4;
            double E = B - A;
            double F = C - B;
            double G = D - C;
            double H = F - E;
            double J = G - F;
            double K = J - H;

            double N2 = n * n;
            double N3 = N2 * n;
            double N4 = N3 * n;

            return Y3 + n * ((B + C) / 2 - (H + J) / 12) + N2 * (F / 2 - K / 24) + N3 * ((H + J) / 12) + N4 * (K / 24);
        }

        /// <summary>
        /// Interpolates a function to the middle location where 4 evenly spaced values are provided.
        /// </summary>
        /// <param name="Y1">The first Y value to interpolate from.</param>
        /// <param name="Y2">The second Y value to interpolate from.</param>
        /// <param name="Y3">The third Y value to interpolate from.</param>
        /// <param name="Y4">The fourth Y value to interpolate from.</param>
        /// <returns>The interpolated Y value.</returns>
        public static double InterpolateToHalves(double Y1, double Y2, double Y3, double Y4)
        {
            return (9 * (Y2 + Y3) - Y1 - Y4) / 16;
        }

        /// <summary>
        /// Interpolates a function using Lagrange's formula where an arbitrary number of values are provided.
        /// </summary>
        /// <param name="X">The X value to interpolate for.</param>
        /// <param name="n">The size of the pX and pY arrays.</param>
        /// <param name="pX">Pointer to the array of X coordinates to interpolate from.</param>
        /// <param name="pY">Pointer to the array of Y coordinates to interpolate from.</param>
        /// <returns>The interpolated Y value.</returns>
        public static double LagrangeInterpolate(double X, int n, double[] pX, double[] pY)
        {
            double V = 0;

            for (int i = 1; i <= n; i++)
            {
                double C = 1;
                for (int j = 1; j <= n; j++)
                {
                    if (j != i)
                        C = C * (X - pX[j - 1]) / (pX[i - 1] - pX[j - 1]);
                }
                V += C * pY[i - 1];
            }

            return V;
        }

        /// <summary>
        /// Interpolates a function to determine where the function reaches an extremum.
        /// </summary>
        /// <param name="Y1">The first Y value to interpolate from.</param>
        /// <param name="Y2">The second Y value to interpolate from.</param>
        /// <param name="Y3">The third Y value to interpolate from.</param>
        /// <param name="nm">Upon return will contain the corresponding value of the argument X where the extremum is reached.</param>
        /// <returns>The extreme Y value.</returns>
        public static double Extremum(double Y1, double Y2, double Y3, ref double nm)
        {
            double a = Y2 - Y1;
            double b = Y3 - Y2;
            double c = Y1 + Y3 - 2 * Y2;

            double ab = a + b;

            nm = -ab / (2 * c);
            return (Y2 - ((ab * ab) / (8 * c)));
        }

        /// <summary>
        /// Interpolates a function to determine where the function reaches an extremum.
        /// </summary>
        /// <param name="Y1">The first Y value to interpolate from.</param>
        /// <param name="Y2">The second Y value to interpolate from.</param>
        /// <param name="Y3">The third Y value to interpolate from.</param>
        /// <param name="Y4">The fourth Y value to interpolate from.</param>
        /// <param name="Y5">The fifth Y value to interpolate from.</param>
        /// <param name="nm">Upon return will contain the corresponding value of the argument X where the extremum is reached.</param>
        /// <returns>The extreme Y value.</returns>
        public static double Extremum(double Y1, double Y2, double Y3, double Y4, double Y5, ref double nm)
        {
            double A = Y2 - Y1;
            double B = Y3 - Y2;
            double C = Y4 - Y3;
            double D = Y5 - Y4;
            double E = B - A;
            double F = C - B;
            double G = D - C;
            double H = F - E;
            double J = G - F;
            double K = J - H;

            bool bRecalc = true;
            double nmprev = 0;
            nm = nmprev;
            while (bRecalc)
            {
                double NMprev2 = nmprev * nmprev;
                double NMprev3 = NMprev2 * nmprev;
                nm = (6 * B + 6 * C - H - J + 3 * NMprev2 * (H + J) + 2 * NMprev3 * K) / (K - 12 * F);

                bRecalc = (Math.Abs(nm - nmprev) > 1E-12);
                if (bRecalc)
                    nmprev = nm;
            }

            return Interpolate(nm, Y1, Y2, Y3, Y4, Y5);
        }

        /// <summary>
        /// Finds where a function reaches zero when the function is "almost a straight line".
        /// </summary>
        /// <param name="Y1">The first Y value to interpolate from.</param>
        /// <param name="Y2">The second Y value to interpolate from.</param>
        /// <param name="Y3">The third Y value to interpolate from.</param>
        /// <returns>The value of the argument X for which the function y becomes zero.</returns>
        public static double Zero(double Y1, double Y2, double Y3)
        {
            double a = Y2 - Y1;
            double b = Y3 - Y2;
            double c = Y1 + Y3 - 2 * Y2;

            bool bRecalc = true;
            double n0prev = 0;
            double n0 = n0prev;
            while (bRecalc)
            {
                n0 = -2 * Y2 / (a + b + c * n0prev);

                bRecalc = (Math.Abs(n0 - n0prev) > 1E-12);
                if (bRecalc)
                    n0prev = n0;
            }

            return n0;
        }

        /// <summary>
        /// Finds where a function reaches zero when the function is "almost a straight line".
        /// </summary>
        /// <param name="Y1">The first Y value to interpolate from.</param>
        /// <param name="Y2">The second Y value to interpolate from.</param>
        /// <param name="Y3">The third Y value to interpolate from.</param>
        /// <param name="Y4">The fourth Y value to interpolate from.</param>
        /// <param name="Y5">The fifth Y value to interpolate from.</param>
        /// <returns>The value of the argument X for which the function y becomes zero.</returns>
        public static double Zero(double Y1, double Y2, double Y3, double Y4, double Y5)
        {
            double A = Y2 - Y1;
            double B = Y3 - Y2;
            double C = Y4 - Y3;
            double D = Y5 - Y4;
            double E = B - A;
            double F = C - B;
            double G = D - C;
            double H = F - E;
            double J = G - F;
            double K = J - H;

            bool bRecalc = true;
            double n0prev = 0;
            double n0 = n0prev;
            while (bRecalc)
            {
                double n0prev2 = n0prev * n0prev;
                double n0prev3 = n0prev2 * n0prev;
                double n0prev4 = n0prev3 * n0prev;

                n0 = (-24 * Y3 + n0prev2 * (K - 12 * F) - 2 * n0prev3 * (H + J) - n0prev4 * K) / (2 * (6 * B + 6 * C - H - J));

                bRecalc = (Math.Abs(n0 - n0prev) > 1E-12);
                if (bRecalc)
                    n0prev = n0;
            }

            return n0;
        }

        /// <summary>
        /// Finds where a function reaches zero when the curvature of the function is important.
        /// </summary>
        /// <param name="Y1">The first Y value to interpolate from.</param>
        /// <param name="Y2">The second Y value to interpolate from.</param>
        /// <param name="Y3">The third Y value to interpolate from.</param>
        /// <returns>The value of the argument X for which the function y becomes zero.</returns>
        public static double Zero2(double Y1, double Y2, double Y3)
        {
            double a = Y2 - Y1;
            double b = Y3 - Y2;
            double c = Y1 + Y3 - 2 * Y2;

            bool bRecalc = true;
            double n0prev = 0;
            double n0 = n0prev;
            while (bRecalc)
            {
                double deltan0 = -(2 * Y2 + n0prev * (a + b + c * n0prev)) / (a + b + 2 * c * n0prev);
                n0 = n0prev + deltan0;

                bRecalc = (Math.Abs(deltan0) > 1E-12);
                if (bRecalc)
                    n0prev = n0;
            }

            return n0;
        }

        /// <summary>
        /// Finds where a function reaches zero when the curvature of the function is important.
        /// </summary>
        /// <param name="Y1">The first Y value to interpolate from.</param>
        /// <param name="Y2">The second Y value to interpolate from.</param>
        /// <param name="Y3">The third Y value to interpolate from.</param>
        /// <param name="Y4">The fourth Y value to interpolate from.</param>
        /// <param name="Y5">The fifth Y value to interpolate from.</param>
        /// <returns>The value of the argument X for which the function y becomes zero.</returns>
        public static double Zero2(double Y1, double Y2, double Y3, double Y4, double Y5)
        {
            double A = Y2 - Y1;
            double B = Y3 - Y2;
            double C = Y4 - Y3;
            double D = Y5 - Y4;
            double E = B - A;
            double F = C - B;
            double G = D - C;
            double H = F - E;
            double J = G - F;
            double K = J - H;
            double M = K / 24;
            double N = (H + J) / 12;
            double P = F / 2 - M;
            double Q = (B + C) / 2 - N;

            bool bRecalc = true;
            double n0prev = 0;
            double n0 = n0prev;
            while (bRecalc)
            {
                double n0prev2 = n0prev * n0prev;
                double n0prev3 = n0prev2 * n0prev;
                double n0prev4 = n0prev3 * n0prev;

                double deltan0 = -(M * n0prev4 + N * n0prev3 + P * n0prev2 + Q * n0prev + Y3) / (4 * M * n0prev3 + 3 * N * n0prev2 + 2 * P * n0prev + Q);
                n0 = n0prev + deltan0;

                bRecalc = (Math.Abs(deltan0) > 1E-12);
                if (bRecalc)
                    n0prev = n0;
            }

            return n0;
        }
    }
}
