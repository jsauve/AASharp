namespace AASharp
{
    public struct ELPMPP02PertubationsCoefficient
    {
        public ELPMPP02PertubationsCoefficient(double mS, double mC, int[] mI) 
        {
            m_S = mS;
            m_C = mC;
            m_I = mI;
        }

        public double m_S { get; }
        public double m_C { get; }
        public int[]  m_I { get; }
    };
}