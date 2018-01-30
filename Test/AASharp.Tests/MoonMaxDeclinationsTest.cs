using Xunit;

namespace AASharp.Tests
{
    public class MoonMaxDeclinationsTest
    {
        [Theory]
        [InlineData(1988.95, -148.12408799999903)]
        public void KTest(double year, double expectedK)
        {
            double k = AASMoonMaxDeclinations.K(year);
            Assert.Equal(expectedK, k);
        }

        [Theory]
        [InlineData(-148, true, 2447518.3346498054)]
        [InlineData(659, false, 2469553.0834434493)]
        [InlineData(-26788, true, 1719672.141249879)]
        public void TrueGreatestDeclinationTest(double k, bool bNortherly, double expectedDeclination)
        {
            double declination = AASMoonMaxDeclinations.TrueGreatestDeclination(k, bNortherly);
            Assert.Equal(expectedDeclination, declination);
        }

        [Theory]
        [InlineData(-148, true, 28.156234425712228)]
        [InlineData(659, false, 22.138355557143345)]
        [InlineData(-26788, true, 28.973887760315549)]
        public void TrueGreatestDeclinationValueTest(double k, bool bNortherly, double expectedDeclination)
        {
            double declination = AASMoonMaxDeclinations.TrueGreatestDeclinationValue(k, bNortherly);
            Assert.Equal(expectedDeclination, declination);
        }
    }
}