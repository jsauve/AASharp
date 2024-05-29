namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by the AASSaturnRings.Calculate method.
    /// </summary>
    public class AASSaturnRingDetails
    {
        /// <summary>
        /// The Saturnicentric latitude in degrees of the Earth referred to the plane of the ring.
        /// </summary>
        public double B { get; set; }
        /// <summary>
        /// The Saturnicentric latitude in degrees of the Sun referred to the plane of the ring.
        /// </summary>
        public double Bdash { get; set; }
        /// <summary>
        /// The geocentric position angle of the Northern semi minor axis of the apparent ellipse of the ring.
        /// </summary>
        public double P { get; set; }
        /// <summary>
        /// The major axis of the outer edge of the outer ring in arc seconds.
        /// </summary>
        public double a { get; set; }
        /// <summary>
        /// The minor axis of the outer edge of the outer ring in arc seconds.
        /// </summary>
        public double b { get; set; }
        /// <summary>
        /// The difference in degrees between the Saturnicentric longitudes of the Sun and the Earth, measured in the plane of the ring. This quantity is required for the calculation of Saturn's magnitude.
        /// </summary>
        public double DeltaU { get; set; }
        /// <summary>
        /// The Saturnicentric longitude of the Sun in degrees.
        /// </summary>
        public double U1 { get; set; }
        /// <summary>
        /// The Saturnicentic longitude of the Earth in degrees.
        /// </summary>
        public double U2 { get; set; }
    }
}