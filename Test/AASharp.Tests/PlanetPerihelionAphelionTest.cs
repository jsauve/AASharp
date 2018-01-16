using Xunit;

namespace AASharp.Tests
{
    public class PlanetPerihelionAphelionTest
    {
        [Theory]
        [InlineData(1978.79, -35)]
        public void VenusKTest(double year, long expectedK)
        {
            long k = AASPlanetPerihelionAphelion.VenusK(year);
            Assert.Equal(expectedK, k);
        }

        [Theory]
        [InlineData(1978.79, 2443873.7043019426)]
        public void VenusPerihelionTest(double year, double expectedPerihelion)
        {
            long k = AASPlanetPerihelionAphelion.VenusK(year);
            double perihelion = AASPlanetPerihelionAphelion.VenusPerihelion(k);
            Assert.Equal(expectedPerihelion, perihelion);
        }

        [Theory]
        [InlineData(2032, 16)]
        public void MarsKTest(double year, long expectedK)
        {
            long k = AASPlanetPerihelionAphelion.MarsK(year);
            Assert.Equal(expectedK, k);
        }

        [Theory]
        [InlineData(2032, 2463530.4564317339)]
        public void MarsAphelionTest(double year, double expectedAphelion)
        {
            long k = AASPlanetPerihelionAphelion.MarsK(year);
            double aphelion = AASPlanetPerihelionAphelion.MarsAphelion(k);
            Assert.Equal(expectedAphelion, aphelion);
        }

        [Theory]
        [InlineData(1925, 2436683.79672075)]
        public void SaturnAphelionTest(double year, double expectedAphelion)
        {
            long k = AASPlanetPerihelionAphelion.SaturnK(year);
            double aphelion = AASPlanetPerihelionAphelion.SaturnAphelion(k);
            Assert.Equal(expectedAphelion, aphelion);
        }

        [Theory]
        [InlineData(1940, 2431301.689788)]
        public void SaturnPerihelionTest(double year, double expectedPerihelion)
        {
            long k = AASPlanetPerihelionAphelion.SaturnK(year);
            double perihelion = AASPlanetPerihelionAphelion.SaturnPerihelion(k);
            Assert.Equal(expectedPerihelion, perihelion);
        }

        [Theory]
        [InlineData(1750, 2393476.2744374997)]
        public void UranusAphelionTest(double year, double expectedAphelion)
        {
            long k = AASPlanetPerihelionAphelion.UranusK(year);
            double aphelion = AASPlanetPerihelionAphelion.UranusAphelion(k);
            Assert.Equal(expectedAphelion, aphelion);
        }

        [Theory]
        [InlineData(1890, 2439518.61789)]
        [InlineData(2060, 2470213.5)]
        public void UranusPerihelionTest(double year, double expectedPerihelion)
        {
            long k = AASPlanetPerihelionAphelion.UranusK(year);
            double perihelion = AASPlanetPerihelionAphelion.UranusPerihelion(k);
            Assert.Equal(expectedPerihelion, perihelion);
        }

        [Theory]
        [InlineData(-10, false, 2447896.1714073028)]
        [InlineData(-10, true, 2447894.9106435603)]
        public void EarthPerihelionTest(long k, bool bBarycentric, double expectedPerihelion)
        {
            double perihelion = AASPlanetPerihelionAphelion.EarthPerihelion(k, bBarycentric);
            Assert.Equal(expectedPerihelion, perihelion);
        }
    }
}