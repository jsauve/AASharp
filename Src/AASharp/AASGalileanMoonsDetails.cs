namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASGalileanMoons.Calculate method.
    /// It returns separate details for the moons Io, Europa, Ganymede, Callisto.
    /// </summary>
    public class AASGalileanMoonsDetails
    {
        public AASGalileanMoonsDetails()
        {
            Satellite1 = new AASGalileanMoonDetail();
            Satellite2 = new AASGalileanMoonDetail();
            Satellite3 = new AASGalileanMoonDetail();
            Satellite4 = new AASGalileanMoonDetail();
        }

        /// <summary>
        /// Details of the moon Io
        /// </summary>
        public AASGalileanMoonDetail Satellite1 { get; set; }
        /// <summary>
        /// Details of the moon Europa
        /// </summary>
        public AASGalileanMoonDetail Satellite2 { get; set; }
        /// <summary>
        /// Details of the moon Ganymede
        /// </summary>
        public AASGalileanMoonDetail Satellite3 { get; set; }
        /// <summary>
        /// Details of the moon Callisto
        /// </summary>
        public AASGalileanMoonDetail Satellite4 { get; set; }
    }
}
