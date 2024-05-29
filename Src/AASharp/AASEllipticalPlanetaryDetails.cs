namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASElliptical.Calculate method.
    /// </summary>
    public class AASEllipticalPlanetaryDetails
    {
        /// <summary>
        /// The apparent geocentric ecliptical longitude in degrees of the object.
        /// </summary>
        public double ApparentGeocentricLongitude { get; set; }
        /// <summary>
        /// The apparent geocentric ecliptical latitude in degrees of the object.
        /// </summary>
        public double ApparentGeocentricLatitude { get; set; }
        /// <summary>
        /// The apparent distance in astronomical units between the object and the Earth.
        /// </summary>
        public double ApparentGeocentricDistance { get; set; }
        /// <summary>
        /// The apparent light travel time in days.
        /// </summary>
        public double ApparentLightTime { get; set; }
        /// <summary>
        /// The apparent right ascension of the planet as an hour angle.
        /// </summary>
        public double ApparentGeocentricRA { get; set; }
        /// <summary>
        /// The apparent declination of the planet in degrees.
        /// </summary>
        public double ApparentGeocentricDeclination { get; set; }
    }
}