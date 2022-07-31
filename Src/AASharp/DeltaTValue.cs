namespace AASharp
{
    struct DeltaTValue
    {
        public DeltaTValue(double jd, double deltaT)
        {
            JD = jd;
            DeltaT = deltaT;
        }

        public double JD;
        public double DeltaT;
    }
}