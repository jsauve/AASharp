namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASPhysicalMoon.CalculateSelenographicPositionOfSun method.
    /// </summary>
    public class AASSelenographicMoonDetails
    {
        /// <summary>
        /// The longitude in degrees of the sub solar point.
        /// </summary>
        public double l0 { get; set; }
        /// <summary>
        /// The latitude in degrees of the sub solar point.
        /// </summary>
        public double b0 { get; set; }
        /// <summary>
        /// The selenographic colongitude of the sun.
        /// </summary>
        public double c0 { get; set; }
    }
}