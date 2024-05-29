namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASPhysicalSun.Calculate method.
    /// </summary>
    public class AASPhysicalSunDetails
    {
        /// <summary>
        /// The position angle in degrees of the northern extremity of the axis of rotation.
        /// </summary>
        public double P { get; set; }
        /// <summary>
        /// The heliographic latitude in degrees of the centre of the solar disk.
        /// </summary>
        public double B0 { get; set; }
        /// <summary>
        /// The heliographic longitude in degrees of the centre of the solar disk.
        /// </summary>
        public double L0 { get; set; }
    }
}