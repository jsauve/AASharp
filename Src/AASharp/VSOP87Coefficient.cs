namespace AASharp
{
    internal struct VSOP87Coefficient
    {
        internal VSOP87Coefficient(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double A { get; }
        public double B { get; }
        public double C { get; }
    }
}
