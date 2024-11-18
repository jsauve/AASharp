namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASSaturnMoons.Calculate method.
    /// </summary>
    public class AASSaturnMoonsDetails
    {
        public AASSaturnMoonsDetails()
        {
            Satellite1 = new AASSaturnMoonDetail();
            Satellite2 = new AASSaturnMoonDetail();
            Satellite3 = new AASSaturnMoonDetail();
            Satellite4 = new AASSaturnMoonDetail();
            Satellite5 = new AASSaturnMoonDetail();
            Satellite6 = new AASSaturnMoonDetail();
            Satellite7 = new AASSaturnMoonDetail();
            Satellite8 = new AASSaturnMoonDetail();
        }

        /// <summary>
        /// Mimas
        /// </summary>
        public AASSaturnMoonDetail Satellite1 { get; set; }
        /// <summary>
        /// Enceladus
        /// </summary>
        public AASSaturnMoonDetail Satellite2 { get; set; }
        /// <summary>
        /// Tethys
        /// </summary>
        public AASSaturnMoonDetail Satellite3 { get; set; }
        /// <summary>
        /// Dione
        /// </summary>
        public AASSaturnMoonDetail Satellite4 { get; set; }
        /// <summary>
        /// Rhea
        /// </summary>
        public AASSaturnMoonDetail Satellite5 { get; set; }
        /// <summary>
        /// Titan
        /// </summary>
        public AASSaturnMoonDetail Satellite6 { get; set; }
        /// <summary>
        /// Hyperion
        /// </summary>
        public AASSaturnMoonDetail Satellite7 { get; set; }
        /// <summary>
        /// Iapetus
        /// </summary>
        public AASSaturnMoonDetail Satellite8 { get; set; }
    }
}