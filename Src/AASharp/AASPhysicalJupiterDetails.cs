namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASPhysicalJupiter.Calculate method.
    /// </summary>
    public class AASPhysicalJupiterDetails
    {
        /// <summary>
        /// The planetocentric declination in degrees of the Earth.
        /// </summary>
        public double DE { get; set; }
        /// <summary>
        /// The planetocentric declination in degrees of the Sun.
        /// </summary>
        public double DS { get; set; }
        /// <summary>
        /// The geometric longitude in degrees of the central meridian for System 1.
        /// </summary>
        public double Geometricw1 { get; set; }
        /// <summary>
        /// The geometric longitude in degrees of the central meridian for System 2.
        /// </summary>
        public double Geometricw2 { get; set; }
        /// <summary>
        /// The apparent longitude in degrees of the central meridian for System 1.
        /// </summary>
        public double Apparentw1 { get; set; }
        /// <summary>
        /// The geometric longitude in degrees of the central meridian for System 2.
        /// </summary>
        public double Apparentw2 { get; set; }
        /// <summary>
        /// The position angle of Jupiter's northern rotational pole in degrees.
        /// </summary>
        public double P { get; set; }
    }
}