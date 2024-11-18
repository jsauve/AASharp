namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASEclipticalElements.Calculate and AASEclipticalElements.FK4B1950ToFK5J2000
    /// </summary>
    public class AASEclipticalElementDetails
    {
        /// <summary>
        /// The reduced inclination in degrees.
        /// </summary>
        public double i { get; set; }
        /// <summary>
        /// The reduced argument of perihelion in degrees.
        /// </summary>
        public double w { get; set; }
        /// <summary>
        /// The reduced longitude of the ascending node in degrees
        /// </summary>
        public double omega { get; set; }
    }
}