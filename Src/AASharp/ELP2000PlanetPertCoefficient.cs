namespace AASharp
{
    internal struct ELP2000PlanetPertCoefficient
    {
        public ELP2000PlanetPertCoefficient(int[] mIp, double mTheta, double mO, double mP)
        {
            m_ip = mIp;
            m_theta = mTheta;
            m_O = mO;
            m_P = mP;
        }

        public int[]    m_ip { get; }
        public double m_theta { get; }
        public double m_O { get; }
        public double m_P { get; }
    };
}