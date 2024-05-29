using System;

namespace AASharp
{
    /// <summary>
    /// This class provides for calculation of Solar and Lunar Eclipses. This refers to Chapter 54 in the book.
    /// </summary>
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
                DeltaJD += -0.4075 * Math.Sin(Mdash) + 0.1721 * E * Math.Sin(M);
            else
                DeltaJD += -0.4065 * Math.Sin(Mdash) + 0.1727 * E * Math.Sin(M);
            
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
            double fgamma = Math.Abs(details.gamma);
            if (fgamma > (1.5433 + details.u))
                return details;

            //We have an eclipse at this time, fill in the details
            if (fgamma < 0.9972)
            {
                if (details.u < 0)
                    details.Flags = AASSolarEclipseDetails.TOTAL_ECLIPSE;
                else if (details.u > 0.0047)
                    details.Flags = AASSolarEclipseDetails.ANNULAR_ECLIPSE;
                else if (details.u >= 0 && details.u <= 0.0047)
                {
                    double w = 0.00464 * Math.Sqrt(1 - (details.gamma * details.gamma));
                    if (details.u < w)
                        details.Flags = AASSolarEclipseDetails.ANNULAR_TOTAL_ECLIPSE;
                    else
                        details.Flags = AASSolarEclipseDetails.ANNULAR_ECLIPSE;
                }

                details.Flags |= AASSolarEclipseDetails.CENTRAL_ECLIPSE;
            }
            else if ((fgamma > 0.9972) && (fgamma < (1.5433 + details.u)))
            {
                if ((fgamma > 0.9972) && (fgamma < (0.9972 + Math.Abs(details.u))))
                {
                    if (details.u < 0)
                        details.Flags = AASSolarEclipseDetails.TOTAL_ECLIPSE;
                    else if (details.u > 0.0047)
                        details.Flags = AASSolarEclipseDetails.ANNULAR_ECLIPSE;
                    else if (details.u >= 0 && details.u <= 0.0047)
                    {
                        double w = 0.00464 * Math.Sqrt(1 - (details.gamma * details.gamma));
                        if (details.u < w)
                            details.Flags = AASSolarEclipseDetails.ANNULAR_TOTAL_ECLIPSE;
                        else
                            details.Flags = AASSolarEclipseDetails.ANNULAR_ECLIPSE;
                    }
                }
                else
                {
                    details.Flags = AASSolarEclipseDetails.PARTIAL_ECLIPSE;
                    details.GreatestMagnitude = (1.5433 + details.u - fgamma) / (0.5461 + (2*details.u));
                }

                details.Flags |= AASSolarEclipseDetails.NON_CENTRAL_ECLIPSE;
            }

            return details;
        }

        /// <param name="k">The same K term as returned from AASMoonPhases.K. For a solar eclipse, this value should be a value without any decimals as a solar eclipse refers to a New Moon.</param>
        /// <returns>A struct containing the following values:
        /// <para>
        /// Flags - A bitmask which indicates the type of solar eclipse which has occurred.See the constant values defined in AASSolarEclopseDetails for more information.
        /// </para>
        /// <para>
        /// TimeOfMaximumEclipse - The date in Dynamical time of maximum eclipse.
        /// </para>
        /// <para>
        /// F - The moons argument of Latitude in degrees at the time of the eclipse.
        /// </para>
        /// <para>
        /// u - The U term for the eclipse.
        /// </para>
        /// <para>
        /// gamma - The gamma term for the eclipse.
        /// </para>
        /// <para>
        /// GreatestMagnitude - The greatest magnitude of the eclipse if the eclipse is partial.
        /// </para>
        /// </returns>
        /// <exception cref="NotSupportedException"></exception>
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

        /// <param name="k">The same K term as returned from AASMoonPhases.K. For a lunar eclipse, this value should be decimal value incremented by 0.5 as a lunar eclipse refers to a Full Moon.</param>
        /// <returns>A struct containing the following values:
        /// <para>
        /// bEclipse - true if a lunar eclipse occurs at this Full Moon.
        /// </para>
        /// <para>
        /// TimeOfMaximumEclipse - The date in Dynamical time of maximum eclipse.
        /// </para>
        /// <para>
        /// F - The moons argument of Latitude in degrees at the time of the eclipse.
        /// </para>
        /// <para>
        /// u - The U term for the eclipse.
        /// </para>
        /// <para>
        /// gamma - The gamma term for the eclipse.
        /// </para>
        /// <para>
        /// PenumbralRadii - The radii of the eclipse for the penumbra in equatorial earth radii.
        /// </para>
        /// <para>
        /// UmbralRadii - The radii of the eclipse for the umbra in equatorial earth radii.
        /// </para>
        /// <para>
        /// PenumbralMagnitude - The magnitude of the eclipse if the eclipse is penumbral.
        /// </para>
        /// <para>
        /// UmbralMagnitude - The magnitude of the eclipse if the eclipse is umbral.
        /// </para>
        /// <para>
        /// PartialPhaseSemiDuration - The semi-duration of the eclipse during the partial phase.
        /// </para>
        /// <para>
        /// TotalPhaseSemiDuration - The semi-duration of the eclipse during the total phase.
        /// </para>
        /// <para>
        /// PartialPhasePenumbralSemiDuration - The semi-duration of the partial phase in the penumbra.
        /// </para>
        /// </returns>
        /// <exception cref="NotSupportedException"></exception>
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
            AASLunarEclipseDetails details = new AASLunarEclipseDetails
            {
                bEclipse = solarDetails.Flags != 0, 
                F = solarDetails.F, 
                gamma = solarDetails.gamma, 
                TimeOfMaximumEclipse = solarDetails.TimeOfMaximumEclipse, 
                u = solarDetails.u
            };

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
