namespace AASharp
{
    internal struct MoonCoefficient1
    {
        internal MoonCoefficient1(int d, int m, int mDash, int f)
        {
            D = d;
            M = m;
            Mdash = mDash;
            F = f;
        }

        public int D { get; }
        public int M { get; }
        public int Mdash { get; }
        public int F { get; }
    }
}
