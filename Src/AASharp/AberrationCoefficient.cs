namespace AASharp
{
    internal struct AberrationCoefficient
    {
        internal AberrationCoefficient(int l2, int l3, int l4, int l5, int l6, int l7, int l8, int lDash, int d, int mDash, int f, int xSin, int xSint, int xCos, int xCost, int ySin, int ySint, int yCos, int yCost, int zSin, int zSint, int zCos, int zCost)
        {
            L2 = l2;
            L3 = l3;
            L4 = l4;
            L5 = l5;
            L6 = l6;
            L7 = l7;
            L8 = l8;
            Ldash = lDash;
            D = d;
            Mdash = mDash;
            F = f;
            xsin = xSin;
            xsint = xSint;
            xcos = xCos;
            xcost = xCost;
            ysin = ySin;
            ysint = ySint;
            ycos = yCos;
            ycost = yCost;
            zsin = zSin;
            zsint = zSint;
            zcos = zCos;
            zcost = zCost;
        }

        public int L2 { get; }
        public int L3 { get; }
        public int L4 { get; }
        public int L5 { get; }
        public int L6 { get; }
        public int L7 { get; }
        public int L8 { get; }
        public int Ldash { get; }
        public int D { get; }
        public int Mdash { get; }
        public int F { get; }
        public int xsin { get; }
        public int xsint { get; }
        public int xcos { get; }
        public int xcost { get; }
        public int ysin { get; }
        public int ysint { get; }
        public int ycos { get; }
        public int ycost { get; }
        public int zsin { get; }
        public int zsint { get; }
        public int zcos { get; }
        public int zcost { get; }
    }
}
