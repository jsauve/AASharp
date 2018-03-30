using Xunit;

namespace AASharp.Tests
{
    public class RefractionTest
    {
        [Theory]
        [InlineData(0.5, 0.47925102784407847)]
        [InlineData(90, -3.6122927158169228E-10)]
        [InlineData(-1.6962987799993996, 0.94783773338343558)]
        [InlineData(-1.7, 0.94783773338343558)]
        public void RefractionFromApparentTest(double altitude, double expectedRefraction)
        {
            double refraction = AASRefraction.RefractionFromApparent(altitude);
            Assert.Equal(expectedRefraction, refraction);
        }

        [Theory]
        [InlineData(0.5 - 0.47925102784407847 + 0.53333333333333333, 0.41033661141786543)] // 1st param : alt - refraction + 32' 
        [InlineData(90 - -3.6122927158169228E-10 + 0.53333333333333333, -0.00015807224687867412)] // 1st param : alt - refraction + 32' 
        [InlineData(-1.9006387000003735, 0.74416143781778543)]
        [InlineData(-1.95, 0.74416143781778543)] 
        public void RefractionFromTrueTest(double altitude, double expectedRefractionFromTrue)
        {
            double refraction = AASRefraction.RefractionFromTrue(altitude);
            Assert.Equal(expectedRefractionFromTrue, refraction);
        }
    }
}