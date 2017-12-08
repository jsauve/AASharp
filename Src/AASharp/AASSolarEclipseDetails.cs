namespace AASharp
{
    public class AASSolarEclipseDetails
    {
        public const uint TOTAL_ECLIPSE         = 0x01;
        public const uint ANNULAR_ECLIPSE       = 0x02;
        public const uint ANNULAR_TOTAL_ECLIPSE = 0x04;
        public const uint CENTRAL_ECLIPSE       = 0x08;
        public const uint PARTIAL_ECLIPSE       = 0x10;
        public const uint NON_CENTRAL_ECLIPSE   = 0x20;
        
        public uint Flags { get; set; }
        public double TimeOfMaximumEclipse { get; set; }
        public double F { get; set; }
        public double u { get; set; }
        public double gamma { get; set; }
        public double GreatestMagnitude { get; set; }
    }
}
