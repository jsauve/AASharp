namespace AASharp
{
    public struct ELP2000MainProblemCoefficient
    {
        public ELP2000MainProblemCoefficient(int[] m_I, double m_A, double[] m_B) 
        {
            this.m_I = m_I;
            this.m_A = m_A;
            this.m_B = m_B;
        }

        public int[] m_I { get; }
        public double m_A {get; }
        public double[] m_B {get; }
    }
}