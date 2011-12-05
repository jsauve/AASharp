using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public static class AASNutation
    {
        internal static NutationCoefficient[] g_NutationCoefficients =
        {
        new NutationCoefficient(  0,  0,  0,  0,  1, -171996,  -174.2,  92025,     8.9    ),
        new NutationCoefficient( -2,  0,  0,  2,  2,  -13187,    -1.6,   5736,    -3.1    ),
        new NutationCoefficient(  0,  0,  0,  2,  2,   -2274,    -0.2,    977,    -0.5    ),
        new NutationCoefficient(  0,  0,  0,  0,  2,    2062,     0.2,   -895,     0.5    ),
        new NutationCoefficient(  0,  1,  0,  0,  0,    1426,    -3.4,     54,    -0.1    ),
        new NutationCoefficient(  0,  0,  1,  0,  0,     712,     0.1,     -7,       0    ),
        new NutationCoefficient( -2,  1,  0,  2,  2,    -517,     1.2,    224,    -0.6    ),
        new NutationCoefficient(  0,  0,  0,  2,  1,    -386,    -0.4,    200,       0    ),
        new NutationCoefficient(  0,  0,  1,  2,  2,    -301,       0,    129,    -0.1    ),
        new NutationCoefficient( -2, -1,  0,  2,  2,     217,    -0.5,    -95,     0.3    ),
        new NutationCoefficient( -2,  0,  1,  0,  0,    -158,       0,      0,       0    ),
        new NutationCoefficient( -2,  0,  0,  2,  1,     129,     0.1,    -70,       0    ),
        new NutationCoefficient(  0,  0, -1,  2,  2,     123,       0,    -53,       0    ),
        new NutationCoefficient(  2,  0,  0,  0,  0,      63,       0,      0,       0    ),
        new NutationCoefficient(  0,  0,  1,  0,  1,      63,     0.1,    -33,       0    ),
        new NutationCoefficient(  2,  0, -1,  2,  2,     -59,       0,     26,       0    ),
        new NutationCoefficient(  0,  0, -1,  0,  1,     -58,    -0.1,     32,       0    ),
        new NutationCoefficient(  0,  0,  1,  2,  1,     -51,       0,     27,       0    ),
        new NutationCoefficient( -2,  0,  2,  0,  0,      48,       0,      0,       0    ),
        new NutationCoefficient(  0,  0, -2,  2,  1,      46,       0,    -24,       0    ),
        new NutationCoefficient(  2,  0,  0,  2,  2,     -38,       0,     16,       0    ),
        new NutationCoefficient(  0,  0,  2,  2,  2,     -31,       0,     13,       0    ),
        new NutationCoefficient(  0,  0,  2,  0,  0,      29,       0,      0,       0    ),
        new NutationCoefficient( -2,  0,  1,  2,  2,      29,       0,    -12,       0    ),
        new NutationCoefficient(  0,  0,  0,  2,  0,      26,       0,      0,       0    ),
        new NutationCoefficient( -2,  0,  0,  2,  0,     -22,       0,      0,       0    ),
        new NutationCoefficient(  0,  0, -1,  2,  1,      21,       0,    -10,       0    ),
        new NutationCoefficient(  0,  2,  0,  0,  0,      17,    -0.1,      0,       0    ),
        new NutationCoefficient(  2,  0, -1,  0,  1,      16,       0,     -8,       0    ),
        new NutationCoefficient( -2,  2,  0,  2,  2,     -16,     0.1,      7,       0    ),
        new NutationCoefficient(  0,  1,  0,  0,  1,     -15,       0,      9,       0    ),
        new NutationCoefficient( -2,  0,  1,  0,  1,     -13,       0,      7,       0    ),
        new NutationCoefficient(  0, -1,  0,  0,  1,     -12,       0,      6,       0    ),
        new NutationCoefficient(  0,  0,  2, -2,  0,      11,       0,      0,       0    ),
        new NutationCoefficient(  2,  0, -1,  2,  1,     -10,       0,      5,       0    ),
        new NutationCoefficient(  2,  0,  1,  2,  2,     -8,        0,      3,       0    ),
        new NutationCoefficient(  0,  1,  0,  2,  2,      7,        0,     -3,       0    ),
        new NutationCoefficient( -2,  1,  1,  0,  0,     -7,        0,      0,       0    ),
        new NutationCoefficient(  0, -1,  0,  2,  2,     -7,        0,      3,       0    ),
        new NutationCoefficient(  2,  0,  0,  2,  1,     -7,        0,      3,       0    ),
        new NutationCoefficient(  2,  0,  1,  0,  0,      6,        0,      0,       0    ),
        new NutationCoefficient( -2,  0,  2,  2,  2,      6,        0,     -3,       0    ),
        new NutationCoefficient( -2,  0,  1,  2,  1,      6,        0,     -3,       0    ),
        new NutationCoefficient(  2,  0, -2,  0,  1,     -6,        0,      3,       0    ),
        new NutationCoefficient(  2,  0,  0,  0,  1,     -6,        0,      3,       0    ),
        new NutationCoefficient(  0, -1,  1,  0,  0,      5,        0,      0,       0    ),
        new NutationCoefficient( -2, -1,  0,  2,  1,     -5,        0,      3,       0    ),
        new NutationCoefficient( -2,  0,  0,  0,  1,     -5,        0,      3,       0    ),
        new NutationCoefficient(  0,  0,  2,  2,  1,     -5,        0,      3,       0    ),
        new NutationCoefficient( -2,  0,  2,  0,  1,      4,        0,      0,       0    ),
        new NutationCoefficient( -2,  1,  0,  2,  1,      4,        0,      0,       0    ),
        new NutationCoefficient(  0,  0,  1, -2,  0,      4,        0,      0,       0    ),
        new NutationCoefficient( -1,  0,  1,  0,  0,     -4,        0,      0,       0    ),
        new NutationCoefficient( -2,  1,  0,  0,  0,     -4,        0,      0,       0    ),
        new NutationCoefficient(  1,  0,  0,  0,  0,     -4,        0,      0,       0    ),
        new NutationCoefficient(  0,  0,  1,  2,  0,      3,        0,      0,       0    ),
        new NutationCoefficient(  0,  0, -2,  2,  2,     -3,        0,      0,       0    ),
        new NutationCoefficient( -1, -1,  1,  0,  0,     -3,        0,      0,       0    ),
        new NutationCoefficient(  0,  1,  1,  0,  0,     -3,        0,      0,       0    ),
        new NutationCoefficient(  0, -1,  1,  2,  2,     -3,        0,      0,       0    ),
        new NutationCoefficient(  2, -1, -1,  2,  2,     -3,        0,      0,       0    ),
        new NutationCoefficient(  0,  0,  3,  2,  2,     -3,        0,      0,       0    ),
        new NutationCoefficient(  2, -1,  0,  2,  2,     -3,        0,      0,       0    ) };

        public static double NutationInLongitude(double JD)
        {
            double T = (JD - 2451545) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;

            double D = 297.85036 + 445267.111480 * T - 0.0019142 * Tsquared + Tcubed / 189474;
            D = AASCoordinateTransformation.MapTo0To360Range(D);

            double M = 357.52772 + 35999.050340 * T - 0.0001603 * Tsquared - Tcubed / 300000;
            M = AASCoordinateTransformation.MapTo0To360Range(M);

            double Mprime = 134.96298 + 477198.867398 * T + 0.0086972 * Tsquared + Tcubed / 56250;
            Mprime = AASCoordinateTransformation.MapTo0To360Range(Mprime);

            double F = 93.27191 + 483202.017538 * T - 0.0036825 * Tsquared + Tcubed / 327270;
            F = AASCoordinateTransformation.MapTo0To360Range(F);

            double omega = 125.04452 - 1934.136261 * T + 0.0020708 * Tsquared + Tcubed / 450000;
            omega = AASCoordinateTransformation.MapTo0To360Range(omega);

            int nCoefficients = g_NutationCoefficients.Length;
            double value = 0;
            for (int i = 0; i < nCoefficients; i++)
            {
                double argument = g_NutationCoefficients[i].D * D + g_NutationCoefficients[i].M * M +
                g_NutationCoefficients[i].Mprime * Mprime + g_NutationCoefficients[i].F * F +
                g_NutationCoefficients[i].Omega * omega;
                double radargument = AASCoordinateTransformation.DegreesToRadians(argument);
                value += (g_NutationCoefficients[i].SinCoeff1 + g_NutationCoefficients[i].SinCoeff2 * T) * Math.Sin(radargument) * 0.0001;
            }

            return value;
        }

        public static double NutationInObliquity(double JD)
        {
            double T = (JD - 2451545) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;

            double D = 297.85036 + 445267.111480 * T - 0.0019142 * Tsquared + Tcubed / 189474;
            D = AASCoordinateTransformation.MapTo0To360Range(D);

            double M = 357.52772 + 35999.050340 * T - 0.0001603 * Tsquared - Tcubed / 300000;
            M = AASCoordinateTransformation.MapTo0To360Range(M);

            double Mprime = 134.96298 + 477198.867398 * T + 0.0086972 * Tsquared + Tcubed / 56250;
            Mprime = AASCoordinateTransformation.MapTo0To360Range(Mprime);

            double F = 93.27191 + 483202.017538 * T - 0.0036825 * Tsquared + Tcubed / 327270;
            F = AASCoordinateTransformation.MapTo0To360Range(F);

            double omega = 125.04452 - 1934.136261 * T + 0.0020708 * Tsquared + Tcubed / 450000;
            omega = AASCoordinateTransformation.MapTo0To360Range(omega);

            int nCoefficients = g_NutationCoefficients.Length;
            double value = 0;
            for (int i = 0; i < nCoefficients; i++)
            {
                double argument = g_NutationCoefficients[i].D * D + g_NutationCoefficients[i].M * M +
                g_NutationCoefficients[i].Mprime * Mprime + g_NutationCoefficients[i].F * F +
                g_NutationCoefficients[i].Omega * omega;
                double radargument = AASCoordinateTransformation.DegreesToRadians(argument);
                value += (g_NutationCoefficients[i].CosCoeff1 + g_NutationCoefficients[i].CosCoeff2 * T) * Math.Cos(radargument) * 0.0001;
            }

            return value;
        }

        public static double MeanObliquityOfEcliptic(double JD)
        {
            double U = (JD - 2451545) / 3652500;
            double Usquared = U * U;
            double Ucubed = Usquared * U;
            double U4 = Ucubed * U;
            double U5 = U4 * U;
            double U6 = U5 * U;
            double U7 = U6 * U;
            double U8 = U7 * U;
            double U9 = U8 * U;
            double U10 = U9 * U;


            return AASCoordinateTransformation.DMSToDegrees(23, 26, 21.448) - AASCoordinateTransformation.DMSToDegrees(0, 0, 4680.93) * U
            - AASCoordinateTransformation.DMSToDegrees(0, 0, 1.55) * Usquared
            + AASCoordinateTransformation.DMSToDegrees(0, 0, 1999.25) * Ucubed
            - AASCoordinateTransformation.DMSToDegrees(0, 0, 51.38) * U4
            - AASCoordinateTransformation.DMSToDegrees(0, 0, 249.67) * U5
            - AASCoordinateTransformation.DMSToDegrees(0, 0, 39.05) * U6
            + AASCoordinateTransformation.DMSToDegrees(0, 0, 7.12) * U7
            + AASCoordinateTransformation.DMSToDegrees(0, 0, 27.87) * U8
            + AASCoordinateTransformation.DMSToDegrees(0, 0, 5.79) * U9
            + AASCoordinateTransformation.DMSToDegrees(0, 0, 2.45) * U10;
        }

        public static double TrueObliquityOfEcliptic(double JD)
        {
            return MeanObliquityOfEcliptic(JD) + AASCoordinateTransformation.DMSToDegrees(0, 0, NutationInObliquity(JD));
        }

        public static double NutationInRightAscension(double Alpha, double Delta, double Obliquity, double NutationInLongitude, double NutationInObliquity)
        {
            //Convert to radians
            Alpha = AASCoordinateTransformation.HoursToRadians(Alpha);
            Delta = AASCoordinateTransformation.DegreesToRadians(Delta);
            Obliquity = AASCoordinateTransformation.DegreesToRadians(Obliquity);

            return (Math.Cos(Obliquity) + Math.Sin(Obliquity) * Math.Sin(Alpha) * Math.Tan(Delta)) * NutationInLongitude - Math.Cos(Alpha) * Math.Tan(Delta) * NutationInObliquity;
        }

        public static double NutationInDeclination(double Alpha, double Obliquity, double NutationInLongitude, double NutationInObliquity)
        {
            //Convert to radians
            Alpha = AASCoordinateTransformation.HoursToRadians(Alpha);
            Obliquity = AASCoordinateTransformation.DegreesToRadians(Obliquity);

            return Math.Sin(Obliquity) * Math.Cos(Alpha) * NutationInLongitude + Math.Sin(Alpha) * NutationInObliquity;
        }
    }

    internal struct NutationCoefficient
    {
        internal NutationCoefficient(
        int d,
        int m,
        int mPrime,
        int f,
        int omega,
        int sinCoeff1,
        double sinCoeff2,
        int cosCoeff1,
        double cosCoeff2)
        {
            _D = d;
            _M = m;
            _Mprime = mPrime;
            _F = f;
            _Omega = omega;
            _SinCoeff1 = sinCoeff1;
            _SinCoeff2 = sinCoeff2;
            _CosCoeff1 = cosCoeff1;
            _CosCoeff2 = cosCoeff2;
        }

        private readonly int _D;
        public int D
        {
            get
            {
                return _D;
            }
        }
        private readonly int _M;
        public int M
        {
            get
            {
                return _M;
            }
        }
        private readonly int _Mprime;
        public int Mprime
        {
            get
            {
                return _Mprime;
            }
        }
        private readonly int _F;
        public int F
        {
            get
            {
                return _F;
            }
        }
        private readonly int _Omega;
        public int Omega
        {
            get
            {
                return _Omega;
            }
        }
        private readonly int _SinCoeff1;
        public int SinCoeff1
        {
            get
            {
                return _SinCoeff1;
            }
        }
        private readonly double _SinCoeff2;
        public double SinCoeff2
        {
            get
            {
                return _SinCoeff2;
            }
        }
        private readonly int _CosCoeff1;
        public int CosCoeff1
        {
            get
            {
                return _CosCoeff1;
            }
        }
        private readonly double _CosCoeff2;
        public double CosCoeff2
        {
            get
            {
                return _CosCoeff2;
            }
        }
    }
}
