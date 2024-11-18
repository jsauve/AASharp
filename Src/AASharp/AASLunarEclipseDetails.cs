namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASEclipses.CalculateLunar
    /// </summary>
    public class AASLunarEclipseDetails
    {
        /// <summary>
        /// true if a lunar eclipse occurs at this Full Moon.
        /// </summary>
        public bool bEclipse { get; set; }
        /// <summary>
        /// The moons argument of Latitude in degrees at the time of the eclipse.
        /// </summary>
        public double F { get; set; }
        /// <summary>
        /// The gamma term for the eclipse.
        /// </summary>
        public double gamma { get; set; }
        /// <summary>
        /// The semi-duration of the partial phase in the penumbra.
        /// </summary>
        public double PartialPhasePenumbraSemiDuration { get; set; }
        /// <summary>
        /// The semi-duration of the eclipse during the partial phase.
        /// </summary>
        public double PartialPhaseSemiDuration { get; set; }
        /// <summary>
        /// The magnitude of the eclipse if the eclipse is penumbral.
        /// </summary>
        public double PenumbralMagnitude { get; set; }
        /// <summary>
        /// The radii of the eclipse for the penumbra in equatorial earth radii.
        /// </summary>
        public double PenumbralRadii { get; set; }
        /// <summary>
        /// The date in Dynamical time of maximum eclipse.
        /// </summary>
        public double TimeOfMaximumEclipse { get; set; }
        /// <summary>
        /// The semi-duration of the eclipse during the total phase.
        /// </summary>
        public double TotalPhaseSemiDuration { get; set; }
        /// <summary>
        /// The U term for the eclipse.
        /// </summary>
        public double u { get; set; }
        /// <summary>
        /// The magnitude of the eclipse if the eclipse is umbral.
        /// </summary>
        public double UmbralMagnitude { get; set; }
        /// <summary>
        /// The radii of the eclipse for the umbra in equatorial earth radii.
        /// </summary>
        public double UmbralRadii { get; set; }
    }
}
