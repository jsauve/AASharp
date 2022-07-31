namespace AASharp
{
    internal struct NutationCoefficient
    {
        internal NutationCoefficient(
            int d,
            int m,
            int mPrime,
            int f,
            int omega,
            int sinCoeff1,
            double sinCoeff2,
            int cosCoeff1,
            double cosCoeff2)
        {
            D = d;
            M = m;
            Mprime = mPrime;
            F = f;
            Omega = omega;
            SinCoeff1 = sinCoeff1;
            SinCoeff2 = sinCoeff2;
            CosCoeff1 = cosCoeff1;
            CosCoeff2 = cosCoeff2;
        }
        

        public int D { get; }
        public int M { get; }
        public int Mprime { get; }
        public int F { get; }
        public int Omega { get; }
        public int SinCoeff1 { get; }
        public double SinCoeff2 { get; }
        public int CosCoeff1 { get; }
        public double CosCoeff2 { get; }
    }
}