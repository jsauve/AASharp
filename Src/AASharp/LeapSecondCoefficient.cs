namespace AASharp
{
    struct LeapSecondCoefficient
    {
        public double JD;
        public double LeapSeconds;
        public double BaseMJD;
        public double Coefficient;

        public LeapSecondCoefficient(double jd, double leapSeconds, double baseMjd, double coefficient)
        {
            JD = jd;
            LeapSeconds = leapSeconds;
            BaseMJD = baseMjd;
            Coefficient = coefficient;
        }
    }
}