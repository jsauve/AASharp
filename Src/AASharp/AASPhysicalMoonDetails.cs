namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASPhysicalMoon.CalculateGeocentric and AASPhysicalMoon.CalculateTopocentric methods.
    /// </summary>
    public class AASPhysicalMoonDetails
    {
        /// <summary>
        /// The optical libration in longitude in degrees.
        /// </summary>
        public double ldash { get; set; }
        /// <summary>
        /// The optical libration in latitude in degrees.
        /// </summary>
        public double bdash { get; set; }
        /// <summary>
        /// The physical libration in longitude in degrees.
        /// </summary>
        public double ldash2 { get; set; }
        /// <summary>
        /// The physical libration in latitude in degrees.
        /// </summary>
        public double bdash2 { get; set; }
        /// <summary>
        /// The total libration in longitude in degrees.
        /// </summary>
        public double l { get; set; }
        /// <summary>
        /// The total libration in latitude in degrees.
        /// </summary>
        public double b { get; set; }
        /// <summary>
        /// The position angle in degrees of the Moon's axis of rotation.
        /// </summary>
        public double P { get; set; }
    }
}