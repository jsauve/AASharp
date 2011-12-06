using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    public static class AASMoonPhases
    {
        public static double K(double Year)
        {
            return 12.3685 * (Year - 2000);
        }

        public static double MeanPhase(double k)
        {
            //convert from K to T
            double T = k / 1236.85;
            double T2 = T * T;
            double T3 = T2 * T;
            double T4 = T3 * T;

            return 2451550.09766 + 29.530588861 * k + 0.00015437 * T2 - 0.000000150 * T3 + 0.00000000073 * T4;
        }

        public static double TruePhase(double k)
        {
            //What will be the return value
            double JD = MeanPhase(k);

            //convert from K to T
            double T = k / 1236.85;
            double T2 = T * T;
            double T3 = T2 * T;
            double T4 = T3 * T;

            double E = 1 - 0.002516 * T - 0.0000074 * T2;
            double E2 = E * E;

            double M = AASCoordinateTransformation.MapTo0To360Range(2.5534 + 29.10535670 * k - 0.0000014 * T2 - 0.00000011 * T3);
            M = AASCoordinateTransformation.DegreesToRadians(M);
            double Mdash = AASCoordinateTransformation.MapTo0To360Range(201.5643 + 385.81693528 * k + 0.0107582 * T2 + 0.00001238 * T3 - 0.000000058 * T4);
            Mdash = AASCoordinateTransformation.DegreesToRadians(Mdash);
            double F = AASCoordinateTransformation.MapTo0To360Range(160.7108 + 390.67050284 * k - 0.0016118 * T2 - 0.00000227 * T3 + 0.000000011 * T4);
            F = AASCoordinateTransformation.DegreesToRadians(F);
            double omega = AASCoordinateTransformation.MapTo0To360Range(124.7746 - 1.56375588 * k + 0.0020672 * T2 + 0.00000215 * T3);
            omega = AASCoordinateTransformation.DegreesToRadians(omega);
            double A1 = AASCoordinateTransformation.MapTo0To360Range(299.77 + 0.107408 * k - 0.009173 * T2);
            A1 = AASCoordinateTransformation.DegreesToRadians(A1);
            double A2 = AASCoordinateTransformation.MapTo0To360Range(251.88 + 0.016321 * k);
            A2 = AASCoordinateTransformation.DegreesToRadians(A2);
            double A3 = AASCoordinateTransformation.MapTo0To360Range(251.83 + 26.651886 * k);
            A3 = AASCoordinateTransformation.DegreesToRadians(A3);
            double A4 = AASCoordinateTransformation.MapTo0To360Range(349.42 + 36.412478 * k);
            A4 = AASCoordinateTransformation.DegreesToRadians(A4);
            double A5 = AASCoordinateTransformation.MapTo0To360Range(84.66 + 18.206239 * k);
            A5 = AASCoordinateTransformation.DegreesToRadians(A5);
            double A6 = AASCoordinateTransformation.MapTo0To360Range(141.74 + 53.303771 * k);
            A6 = AASCoordinateTransformation.DegreesToRadians(A6);
            double A7 = AASCoordinateTransformation.MapTo0To360Range(207.14 + 2.453732 * k);
            A7 = AASCoordinateTransformation.DegreesToRadians(A7);
            double A8 = AASCoordinateTransformation.MapTo0To360Range(154.84 + 7.306860 * k);
            A8 = AASCoordinateTransformation.DegreesToRadians(A8);
            double A9 = AASCoordinateTransformation.MapTo0To360Range(34.52 + 27.261239 * k);
            A9 = AASCoordinateTransformation.DegreesToRadians(A9);
            double A10 = AASCoordinateTransformation.MapTo0To360Range(207.19 + 0.121824 * k);
            A10 = AASCoordinateTransformation.DegreesToRadians(A10);
            double A11 = AASCoordinateTransformation.MapTo0To360Range(291.34 + 1.844379 * k);
            A11 = AASCoordinateTransformation.DegreesToRadians(A11);
            double A12 = AASCoordinateTransformation.MapTo0To360Range(161.72 + 24.198154 * k);
            A12 = AASCoordinateTransformation.DegreesToRadians(A12);
            double A13 = AASCoordinateTransformation.MapTo0To360Range(239.56 + 25.513099 * k);
            A13 = AASCoordinateTransformation.DegreesToRadians(A13);
            double A14 = AASCoordinateTransformation.MapTo0To360Range(331.55 + 3.592518 * k);
            A14 = AASCoordinateTransformation.DegreesToRadians(A14);

            //convert to radians
            double kint = 0;
            double kfrac = AASMath.modF(k, ref kint);
            if (kfrac < 0)
                kfrac = 1 + kfrac;
            if (kfrac == 0) //New Moon
            {
                double DeltaJD = -0.40720 * Math.Sin(Mdash) +
                0.17241 * E * Math.Sin(M) +
                0.01608 * Math.Sin(2 * Mdash) +
                0.01039 * Math.Sin(2 * F) +
                0.00739 * E * Math.Sin(Mdash - M) +
                -0.00514 * E * Math.Sin(Mdash + M) +
                0.00208 * E2 * Math.Sin(2 * M) +
                -0.00111 * Math.Sin(Mdash - 2 * F) +
                -0.00057 * Math.Sin(Mdash + 2 * F) +
                0.00056 * E * Math.Sin(2 * Mdash + M) +
                -0.00042 * Math.Sin(3 * Mdash) +
                0.00042 * E * Math.Sin(M + 2 * F) +
                0.00038 * E * Math.Sin(M - 2 * F) +
                -0.00024 * E * Math.Sin(2 * Mdash - M) +
                -0.00017 * Math.Sin(omega) +
                -0.00007 * Math.Sin(Mdash + 2 * M) +
                0.00004 * Math.Sin(2 * Mdash - 2 * F) +
                0.00004 * Math.Sin(3 * M) +
                0.00003 * Math.Sin(Mdash + M - 2 * F) +
                0.00003 * Math.Sin(2 * Mdash + 2 * F) +
                -0.00003 * Math.Sin(Mdash + M + 2 * F) +
                0.00003 * Math.Sin(Mdash - M + 2 * F) +
                -0.00002 * Math.Sin(Mdash - M - 2 * F) +
                -0.00002 * Math.Sin(3 * Mdash + M) +
                0.00002 * Math.Sin(4 * Mdash);
                JD += DeltaJD;
            }
            else
                if ((kfrac == 0.25) || (kfrac == 0.75)) //First Quarter or Last Quarter
                {
                    double DeltaJD = -0.62801 * Math.Sin(Mdash) +
                    0.17172 * E * Math.Sin(M) +
                    -0.01183 * E * Math.Sin(Mdash + M) +
                    0.00862 * Math.Sin(2 * Mdash) +
                    0.00804 * Math.Sin(2 * F) +
                    0.00454 * E * Math.Sin(Mdash - M) +
                    0.00204 * E2 * Math.Sin(2 * M) +
                    -0.00180 * Math.Sin(Mdash - 2 * F) +
                    -0.00070 * Math.Sin(Mdash + 2 * F) +
                    -0.00040 * Math.Sin(3 * Mdash) +
                    -0.00034 * E * Math.Sin(2 * Mdash - M) +
                    0.00032 * E * Math.Sin(M + 2 * F) +
                    0.00032 * E * Math.Sin(M - 2 * F) +
                    -0.00028 * E2 * Math.Sin(Mdash + 2 * M) +
                    0.00027 * E * Math.Sin(2 * Mdash + M) +
                    -0.00017 * Math.Sin(omega) +
                    -0.00005 * Math.Sin(Mdash - M - 2 * F) +
                    0.00004 * Math.Sin(2 * Mdash + 2 * F) +
                    -0.00004 * Math.Sin(Mdash + M + 2 * F) +
                    0.00004 * Math.Sin(Mdash - 2 * M) +
                    0.00003 * Math.Sin(Mdash + M - 2 * F) +
                    0.00003 * Math.Sin(3 * M) +
                    0.00002 * Math.Sin(2 * Mdash - 2 * F) +
                    0.00002 * Math.Sin(Mdash - M + 2 * F) +
                    -0.00002 * Math.Sin(3 * Mdash + M);
                    JD += DeltaJD;

                    double W = 0.00306 - 0.00038 * E * Math.Cos(M) + 0.00026 * Math.Cos(Mdash) - 0.00002 * Math.Cos(Mdash - M) + 0.00002 * Math.Cos(Mdash + M) + 0.00002 * Math.Cos(2 * F);
                    if (kfrac == 0.25)
                        //First quarter
                        JD += W;
                    else
                        JD -= W;
                }
                else
                    if (kfrac == 0.5) //Full Moon
                    {
                        double DeltaJD = -0.40614 * Math.Sin(Mdash) +
                        0.17302 * E * Math.Sin(M) +
                        0.01614 * Math.Sin(2 * Mdash) +
                        0.01043 * Math.Sin(2 * F) +
                        0.00734 * E * Math.Sin(Mdash - M) +
                        -0.00514 * E * Math.Sin(Mdash + M) +
                        0.00209 * E2 * Math.Sin(2 * M) +
                        -0.00111 * Math.Sin(Mdash - 2 * F) +
                        -0.00057 * Math.Sin(Mdash + 2 * F) +
                        0.00056 * E * Math.Sin(2 * Mdash + M) +
                        -0.00042 * Math.Sin(3 * Mdash) +
                        0.00042 * E * Math.Sin(M + 2 * F) +
                        0.00038 * E * Math.Sin(M - 2 * F) +
                        -0.00024 * E * Math.Sin(2 * Mdash - M) +
                        -0.00017 * Math.Sin(omega) +
                        -0.00007 * Math.Sin(Mdash + 2 * M) +
                        0.00004 * Math.Sin(2 * Mdash - 2 * F) +
                        0.00004 * Math.Sin(3 * M) +
                        0.00003 * Math.Sin(Mdash + M - 2 * F) +
                        0.00003 * Math.Sin(2 * Mdash + 2 * F) +
                        -0.00003 * Math.Sin(Mdash + M + 2 * F) +
                        0.00003 * Math.Sin(Mdash - M + 2 * F) +
                        -0.00002 * Math.Sin(Mdash - M - 2 * F) +
                        -0.00002 * Math.Sin(3 * Mdash + M) +
                        0.00002 * Math.Sin(4 * Mdash);
                        JD += DeltaJD;
                    }
                    else
                    {
                        throw new NotSupportedException("The calculated lunar angular distance is invalid.");
                    }

            //Additional corrections for all phases
            double DeltaJD2 = 0.000325 * Math.Sin(A1) +
            0.000165 * Math.Sin(A2) +
            0.000164 * Math.Sin(A3) +
            0.000126 * Math.Sin(A4) +
            0.000110 * Math.Sin(A5) +
            0.000062 * Math.Sin(A6) +
            0.000060 * Math.Sin(A7) +
            0.000056 * Math.Sin(A8) +
            0.000047 * Math.Sin(A9) +
            0.000042 * Math.Sin(A10) +
            0.000040 * Math.Sin(A11) +
            0.000037 * Math.Sin(A12) +
            0.000035 * Math.Sin(A13) +
            0.000023 * Math.Sin(A14);
            JD += DeltaJD2;

            return JD;
        }
    }
}
