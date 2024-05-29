namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASNodes.PassageThroXXXNode methods.
    /// </summary>
    public class AASNodeObjectDetails
    {
        /// <summary>
        /// The date in Dynamical time to when the body moves thro the ascending node.
        /// </summary>
        public double t { get; set; }
        /// <summary>
        /// The radius vector in astronomical units.
        /// </summary>
        public double radius { get; set; }
    }
}