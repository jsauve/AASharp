namespace AASharp
{
    internal struct VSOP87Coefficient2
    {
        internal VSOP87Coefficient2(VSOP87Coefficient[] vsop87Coefficient, double nCoefficientsSize)
        {
            pCoefficients = vsop87Coefficient;
            this.nCoefficientsSize = nCoefficientsSize;
        }

        public VSOP87Coefficient[] pCoefficients { get; }
        public double nCoefficientsSize { get; }
    }
}