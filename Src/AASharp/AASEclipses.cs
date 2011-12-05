using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public static class AASEclipses
    {
        private static AASSolarEclipseDetails Calculate(double k, ref double Mdash)
        {
            //Are we looking for a solar or lunar eclipse
            double intp = 0;
            bool bSolarEclipse = (AASMath.modF(k, ref intp) == 0);

            //What will be the return value
            AASSolarEclipseDetails details = new AASSolarEclipseDetails();

            //convert from K to T
            double T = k / 1236.85;
            double T2 = T * T;
            double T3 = T2 * T;
            double T4 = T3 * T;

            double E = 1 - 0.002516 * T - 0.0000074 * T2;

            double M = AASCoordinateTransformation.MapTo0To360Range(2.5534 + 29.10535670 * k - 0.0000014 * T2 - 0.00000011 * T3);
            M = AASCoordinateTransformation.DegreesToRadians(M);

            Mdash = AASCoordinateTransformation.MapTo0To360Range(201.5643 + 385.81693528 * k + 0.0107582 * T2 + 0.00001238 * T3 - 0.000000058 * T4);
            Mdash = AASCoordinateTransformation.DegreesToRadians(Mdash);

            double omega = AASCoordinateTransformation.MapTo0To360Range(124.7746 - 1.56375588 * k + 0.0020672 * T2 + 0.00000215 * T3);
            omega = AASCoordinateTransformation.DegreesToRadians(omega);

            double F = AASCoordinateTransformation.MapTo0To360Range(160.7108 + 390.67050284 * k - 0.0016118 * T2 - 0.00000227 * T3 + 0.00000001 * T4);
            details.F = F;
            double Fdash = F - 0.02665 * Math.Sin(omega);

            F = AASCoordinateTransformation.DegreesToRadians(F);
            Fdash = AASCoordinateTransformation.DegreesToRadians(Fdash);

            //Do the first check to see if we have an eclipse
            if (Math.Abs(Math.Sin(F)) > 0.36)
                return details;

            double A1 = AASCoordinateTransformation.MapTo0To360Range(299.77 + 0.107408 * k - 0.009173 * T2);
            A1 = AASCoordinateTransformation.DegreesToRadians(A1);

            details.TimeOfMaximumEclipse = AASMoonPhases.MeanPhase(k);

            double DeltaJD = 0;
            if (bSolarEclipse)
                DeltaJD += -0.4075 * Math.Sin(Mdash) +
                0.1721 * E * Math.Sin(M);
            else
                DeltaJD += -0.4065 * Math.Sin(Mdash) +
                0.1727 * E * Math.Sin(M);
            DeltaJD += 0.0161 * Math.Sin(2 * Mdash) +
            -0.0097 * Math.Sin(2 * Fdash) +
            0.0073 * E * Math.Sin(Mdash - M) +
            -0.0050 * E * Math.Sin(Mdash + M) +
            -0.0023 * Math.Sin(Mdash - 2 * Fdash) +
            0.0021 * E * Math.Sin(2 * M) +
            0.0012 * Math.Sin(Mdash + 2 * Fdash) +
            0.0006 * E * Math.Sin(2 * Mdash + M) +
            -0.0004 * Math.Sin(3 * Mdash) +
            -0.0003 * E * Math.Sin(M + 2 * Fdash) +
            0.0003 * Math.Sin(A1) +
            -0.0002 * E * Math.Sin(M - 2 * Fdash) +
            -0.0002 * E * Math.Sin(2 * Mdash - M) +
            -0.0002 * Math.Sin(omega);

            details.TimeOfMaximumEclipse += DeltaJD;

            double P = 0.2070 * E * Math.Sin(M) +
            0.0024 * E * Math.Sin(2 * M) +
            -0.0392 * Math.Sin(Mdash) +
            0.0116 * Math.Sin(2 * Mdash) +
            -0.0073 * E * Math.Sin(Mdash + M) +
            0.0067 * E * Math.Sin(Mdash - M) +
            0.0118 * Math.Sin(2 * Fdash);

            double Q = 5.2207 +
            -0.0048 * E * Math.Cos(M) +
            0.0020 * E * Math.Cos(2 * M) +
            -0.3299 * Math.Cos(Mdash) +
            -0.0060 * E * Math.Cos(Mdash + M) +
            0.0041 * E * Math.Cos(Mdash - M);

            double W = Math.Abs(Math.Cos(Fdash));

            details.gamma = (P * Math.Cos(Fdash) + Q * Math.Sin(Fdash)) * (1 - 0.0048 * W);

            details.u = 0.0059 +
            0.0046 * E * Math.Cos(M) +
            -0.0182 * Math.Cos(Mdash) +
            0.0004 * Math.Cos(2 * Mdash) +
            -0.0005 * Math.Cos(M + Mdash);

            //Check to see if the eclipse is visible from the Earth's surface
            if (Math.Abs(details.gamma) > (1.5433 + details.u))
                return details;

            //We have an eclipse at this time
            details.bEclipse = true;

            //In the case of a partial eclipse, calculate its magnitude
            double fgamma = Math.Abs(details.gamma);
            if (((fgamma > 0.9972) && (fgamma < 1.5433 + details.u)))
                details.GreatestMagnitude = (1.5433 + details.u - fgamma) / (0.5461 + 2 * details.u);

            return details;
        }

        public static AASSolarEclipseDetails CalculateSolar(double k)
        {
#if DEBUG
            double intp = 0;
            bool bSolarEclipse = (AASMath.modF(k, ref intp) == 0);
            if (!bSolarEclipse) throw new NotSupportedException("bSolarEclipse must be true for the operation to complete successfully.");
#endif

            double Mdash = 0;
            return Calculate(k, ref Mdash);
        }


        public static AASLunarEclipseDetails CalculateLunar(double k)
        {
#if DEBUG
            double intp = 0;
            bool bSolarEclipse = (AASMath.modF(k, ref intp) == 0);
            if (bSolarEclipse) throw new NotSupportedException("bSolarEclipse must be false for the operation to complete successfully.");
#endif

            double Mdash = 0;
            AASSolarEclipseDetails solarDetails = Calculate(k, ref Mdash);

            //What will be the return value
            AASLunarEclipseDetails details = new AASLunarEclipseDetails { bEclipse = solarDetails.bEclipse, F = solarDetails.F, gamma = solarDetails.gamma, TimeOfMaximumEclipse = solarDetails.TimeOfMaximumEclipse, u = solarDetails.u };

            if (details.bEclipse)
            {
                details.PenumbralRadii = 1.2848 + details.u;
                details.UmbralRadii = 0.7403 - details.u;
                double fgamma = Math.Abs(details.gamma);
                details.PenumbralMagnitude = (1.5573 + details.u - fgamma) / 0.5450;
                details.UmbralMagnitude = (1.0128 - details.u - fgamma) / 0.5450;

                double p = 1.0128 - details.u;
                double t = 0.4678 - details.u;
                double n = 0.5458 + 0.0400 * Math.Cos(Mdash);

                double gamma2 = details.gamma * details.gamma;
                double p2 = p * p;
                if (p2 >= gamma2)
                    details.PartialPhaseSemiDuration = 60 / n * Math.Sqrt(p2 - gamma2);

                double t2 = t * t;
                if (t2 >= gamma2)
                    details.TotalPhaseSemiDuration = 60 / n * Math.Sqrt(t2 - gamma2);

                double h = 1.5573 + details.u;
                double h2 = h * h;
                if (h2 >= gamma2)
                    details.PartialPhasePenumbraSemiDuration = 60 / n * Math.Sqrt(h2 - gamma2);
            }

            return details;
        }
    }
}
