using Xunit;

namespace AASharp.Tests
{
    public class PlanetaryPhenomenaTest
    {
        [Theory]
        [InlineData(1993.75, PlanetaryObject.MERCURY, EventType.INFERIOR_CONJUNCTION, -20)]
        [InlineData(1631.8, PlanetaryObject.MERCURY, EventType.INFERIOR_CONJUNCTION, -1161)]
        [InlineData(2125.5, PlanetaryObject.SATURN, EventType.CONJUNCTION, 121)]
        [InlineData(1882.9, PlanetaryObject.VENUS, EventType.INFERIOR_CONJUNCTION, -74)]
        [InlineData(2729.65, PlanetaryObject.MARS, EventType.OPPOSITION, 341)]
        [InlineData(-5, PlanetaryObject.JUPITER, EventType.OPPOSITION, -1837)]
        [InlineData(-5, PlanetaryObject.SATURN, EventType.OPPOSITION, -1938)]
        [InlineData(1780.6, PlanetaryObject.URANUS, EventType.OPPOSITION, -217)]
        [InlineData(1846.5, PlanetaryObject.NEPTUNE, EventType.OPPOSITION, -153)]
        public void KTest(double year, PlanetaryObject planetaryObject, EventType eventType, double expectedK)
        {
            double k = AASPlanetaryPhenomena.K(year, planetaryObject, eventType);
            Assert.Equal(expectedK, k);
        }

        [Theory]
        [InlineData(-20, PlanetaryObject.MERCURY, EventType.INFERIOR_CONJUNCTION, 2449294.473458)]
        [InlineData(2125.5, PlanetaryObject.SATURN, EventType.CONJUNCTION, 3255315.4659519996)]
        public void MeanInferiorConjunctionTest(double k, PlanetaryObject planetaryObject, EventType eventType, double expectedInferiorConjunction)
        {
            double inferiorConjunction = AASPlanetaryPhenomena.Mean(k, planetaryObject, eventType);
            Assert.Equal(expectedInferiorConjunction, inferiorConjunction);
        }

        [Theory]
        [InlineData(-20, PlanetaryObject.MERCURY, EventType.INFERIOR_CONJUNCTION, 2449297.6449260321)]
        [InlineData(-20, PlanetaryObject.MERCURY, EventType.WESTERN_ELONGATION, 2449314.1385987741)]
        [InlineData(-1161, PlanetaryObject.MERCURY, EventType.INFERIOR_CONJUNCTION, 2317080.8061396559)]
        [InlineData(121, PlanetaryObject.SATURN, EventType.CONJUNCTION, 2497437.9035375882)]
        [InlineData(-2, PlanetaryObject.MARS, EventType.STATION2, 2450566.2552871821)]
        [InlineData(-74, PlanetaryObject.VENUS, EventType.INFERIOR_CONJUNCTION, 2408786.1911804606)]
        [InlineData(341, PlanetaryObject.MARS, EventType.OPPOSITION, 2718057.6412432436)]
        [InlineData(-1837, PlanetaryObject.JUPITER, EventType.OPPOSITION, 1719123.7865354216)]
        [InlineData(-1938, PlanetaryObject.SATURN, EventType.OPPOSITION, 1719122.8709219305)]
        [InlineData(-217, PlanetaryObject.URANUS, EventType.OPPOSITION, 2371543.0992996683)]
        [InlineData(-153, PlanetaryObject.NEPTUNE, EventType.OPPOSITION, 2395528.6623234339)]
        public void TrueInferiorConjunctionTest(double k, PlanetaryObject planetaryObject, EventType eventType, double expectedInferiorConjunction)
        {
            double inferiorConjunction = AASPlanetaryPhenomena.True(k, planetaryObject, eventType);
            Assert.Equal(expectedInferiorConjunction, inferiorConjunction);
        }

        [Theory]
        [InlineData(-20, PlanetaryObject.MERCURY, false, 19.750578378018979)]
        public void ElongationValueTest(double k, PlanetaryObject planetaryObject, bool bEastern, double expectedElongationValue)
        {
            double elongationValue = AASPlanetaryPhenomena.ElongationValue(k, planetaryObject, bEastern);
            Assert.Equal(expectedElongationValue, elongationValue);
        }
    }
}