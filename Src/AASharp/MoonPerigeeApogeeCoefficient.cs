namespace AASharp
{
    internal struct MoonPerigeeApogeeCoefficient
    {
        internal MoonPerigeeApogeeCoefficient(int d, int m, int f, double c, double t)
        {
            D = d;
            M = m;
            F = f;
            C = c;
            T = t;
        }

        public int D { get; }
        public int M { get; }
        public int F { get; }
        public double C { get; }
        public double T { get; }
    }
}
