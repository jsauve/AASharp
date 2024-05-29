namespace AASharp
{
    /// <summary>
    /// A class to define the orbital elements used by the AASElliptical.Calculate method.
    /// </summary>
    public class AASEllipticalObjectElements
    {
        /// <summary>
        /// The semi major axis in astronomical units.
        /// </summary>
        public double a { get; set; }
        /// <summary>
        /// The eccentricity of the orbit.
        /// </summary>
        public double e { get; set; }
        /// <summary>
        /// The inclination of the plane of the orbit in degrees.
        /// </summary>
        public double i { get; set; }
        /// <summary>
        /// The argument of the perihelion in degrees.
        /// </summary>
        public double w { get; set; }
        /// <summary>
        /// The longitude of the ascending node in degrees.
        /// </summary>
        public double omega { get; set; }
        /// <summary>
        /// The Julian day for which equatorial coordinates should be calculated for.
        /// </summary>
        public double JDEquinox { get; set; }
        /// <summary>
        /// The Julian date of the time of passage in perihelion.
        /// </summary>
        public double T { get; set; }
    }
}