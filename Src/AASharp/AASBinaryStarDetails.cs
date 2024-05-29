namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASBinaryStar.Calculate method.
    /// </summary>
    public class AASBinaryStarDetails
    {
        /// <summary>
        /// The radius vector of the secondary star in arc seconds of a degree.
        /// </summary>
        public double r { get; set; }
        /// <summary>
        /// The angular separation between the two stars in arc seconds of a degree.
        /// </summary>
        public double Rho { get; set; }
        /// <summary>
        /// The apparent position angle of the secondary star in degrees.
        /// </summary>
        public double Theta { get; set; }
    }
}
