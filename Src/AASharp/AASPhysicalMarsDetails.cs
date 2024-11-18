namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASPhysicalMars.Calculate method.
    /// </summary>
    public class AASPhysicalMarsDetails
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
        /// The aerographic longitude in degrees of the central meridian as seen from Earth.
        /// </summary>
        public double w { get; set; }
        /// <summary>
        /// The geocentric position angle of Mars' northern rotational pole in degrees.
        /// </summary>
        public double P { get; set; }
        /// <summary>
        /// The position angle in degrees of the mid-point of the illuminated limb.
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// The illuminated fraction of the planet's disk.
        /// </summary>
        public double k { get; set; }
        /// <summary>
        /// The defect of illumination.
        /// </summary>
        public double q { get; set; }
        /// <summary>
        /// The apparent diameter of Mars in arc seconds.
        /// </summary>
        public double d { get; set; }
    }
}