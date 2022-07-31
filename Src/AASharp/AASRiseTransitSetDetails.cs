namespace AASharp
{
    public class AASRiseTransitSetDetails
    {
        public bool bRiseValid { get; set; }
        public double Rise { get; set; }
        public bool bTransitValid { get; set; }
        public bool bTransitAboveHorizon { get; set; }
        public double Transit { get; set; }
        public bool bSetValid { get; set; }
        public double Set { get; set; }
    }
}