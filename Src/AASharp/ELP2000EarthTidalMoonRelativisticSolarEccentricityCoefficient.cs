namespace AASharp
{
    internal struct ELP2000EarthTidalMoonRelativisticSolarEccentricityCoefficient
    {
        public ELP2000EarthTidalMoonRelativisticSolarEccentricityCoefficient(int mIz, int[] mI, double mO, double mA, double mP)
        {
            m_IZ = mIz;
            m_I = mI;
            m_O = mO;
            m_A = mA;
            m_P = mP;
        }

        public int    m_IZ { get; }
        public int[]  m_I { get; }
        public double m_O { get; }
        public double m_A { get; }
        public double m_P { get; }
    };
}