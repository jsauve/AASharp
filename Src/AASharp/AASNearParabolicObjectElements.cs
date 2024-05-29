namespace AASharp
{
    /// <summary>
    /// An instance of this class as a parameter is required by the AASNearParabolic.Calculate method. 
    /// </summary>
    public class AASNearParabolicObjectElements
    {
        /// <summary>
        /// The perihelion distance in astronomical units.
        /// </summary>
        public double q { get; set; }
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
        /// The Julian Date for which equatorial coordinates should be calculated for.
        /// </summary>
        public double JDEquinox { get; set; }
        /// <summary>
        /// The Julian date of the time of passage in perihelion.
        /// </summary>
        public double T { get; set; }
        /// <summary>
        /// Eccentricity of the orbit
        /// </summary>
        public double e { get; set; }
    }
}