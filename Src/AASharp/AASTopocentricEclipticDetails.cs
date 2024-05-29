namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASParallax.Ecliptic2Topocentric method.
    /// </summary>
    public class AASTopocentricEclipticDetails
    {
        /// <summary>
        /// The topocentric ecliptical longitude in degrees.
        /// </summary>
        public double Lambda { get; set; }
        /// <summary>
        /// The topocentric ecliptical latitude in degrees.
        /// </summary>
        public double Beta { get; set; }
        /// <summary>
        /// The topocentric semi diameter in degrees.
        /// </summary>
        public double Semidiameter { get; set; }
    }
}