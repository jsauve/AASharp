namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASEclipses.CalculateSolar
    /// </summary>
    public class AASSolarEclipseDetails
    {
        public const uint TOTAL_ECLIPSE         = 0x01;
        public const uint ANNULAR_ECLIPSE       = 0x02;
        public const uint ANNULAR_TOTAL_ECLIPSE = 0x04;
        public const uint CENTRAL_ECLIPSE       = 0x08;
        public const uint PARTIAL_ECLIPSE       = 0x10;
        public const uint NON_CENTRAL_ECLIPSE   = 0x20;
        /// <summary>
        /// A bitmask which indicates the type of solar eclipse which has occurred. See the constant values defined in AASSolarEclopseDetails for more information.
        /// </summary>
        public uint Flags { get; set; }
        /// <summary>
        /// The date in Dynamical time of maximum eclipse.
        /// </summary>
        public double TimeOfMaximumEclipse { get; set; }
        /// <summary>
        /// The moons argument of Latitude in degrees at the time of the eclipse.
        /// </summary>
        public double F { get; set; }
        /// <summary>
        /// The U term for the eclipse.
        /// </summary>
        public double u { get; set; }
        /// <summary>
        /// The gamma term for the eclipse.
        /// </summary>
        public double gamma { get; set; }
        /// <summary>
        /// The greatest magnitude of the eclipse if the eclipse is partial.
        /// </summary>
        public double GreatestMagnitude { get; set; }
    }
}
