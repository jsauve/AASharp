namespace AASharp
{
    public struct ELPMPP02Pertubations
    {
        public ELPMPP02Pertubations(ELPMPP02PertubationsCoefficient[] mpTable, int mnTableSize)
        {
            m_pTable = mpTable;
            m_nTableSize = mnTableSize; 
        }

        public ELPMPP02PertubationsCoefficient[] m_pTable { get; }
        public int m_nTableSize { get; }
    };
}