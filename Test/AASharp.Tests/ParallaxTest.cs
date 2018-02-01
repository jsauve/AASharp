using Xunit;
  
namespace AASharp.Tests
{
    public class ParallaxTest
    {
        [Theory]
        [InlineData(22.635347222222222, -15.771083, 0.37276, 116.8625, 33.356111111111112, 1706, 2452879.63681, 0.00035942306707589821, -0.0039287861930598182)]
        public void Equatorial2TopocentricDeltaTest(double alpha, double delta, double distance, double longitude, double latitude, double height, double jd, double expectedX, double expectedY)
        {
            AAS2DCoordinate topocentricDelta = AASParallax.Equatorial2TopocentricDelta(alpha, delta, distance, longitude, latitude, height, jd);
            Assert.Equal(expectedX, topocentricDelta.X);
            Assert.Equal(expectedY, topocentricDelta.Y);
        }

        [Theory]
        [InlineData(22.635347222222222, -15.771083, 0.37276, 116.8625, 33.356111111111112, 1706, 2452879.63681, 22.635706656799634, -15.775011769561779)]
        public void Equatorial2TopocentricTest(double alpha, double delta, double distance, double longitude, double latitude, double height, double jd, double expectedX, double expectedY)
        {
            AAS2DCoordinate topocentricDelta = AASParallax.Equatorial2Topocentric(alpha, delta, distance, longitude, latitude, height, jd);
            Assert.Equal(expectedX, topocentricDelta.X);
            Assert.Equal(expectedY, topocentricDelta.Y);
        }

        [Theory]
        [InlineData(0.99102777777777773, 0.0024650162582525149)]
        public void ParallaxToDistanceTest(double parallax, double expectedDistance) 
        {
            double distance = AASParallax.ParallaxToDistance(parallax);
            Assert.Equal(expectedDistance, distance);
        }

        [Theory]
        [InlineData(0.0024650162582525149, 0.99102777777777762)]
        public void DistanceToParallaxTest(double distance, double expectedParallax) 
        {
            double parallax = AASParallax.DistanceToParallax(distance);
            Assert.Equal(expectedParallax, parallax);
        }

        [Theory]
        [InlineData(181.77291666666667, 2.2906111111111112, 0.27097222222222223, 0.0024650162582525149, 23.466888888888889, 50.0855, 0, 2452879.150858, 181.80140510243547, 1.4852955892990602, 0.27373920671847568)]
        public void Ecliptic2TopocentricTest(double lambda, double beta, double semidiameter, double distance, double epsilon, double latitude, double height, double jd, double expectedLambda, double expectedBeta, double expectedSemidiameter) 
        {
            AASTopocentricEclipticDetails parallax = AASParallax.Ecliptic2Topocentric(lambda, beta, semidiameter, distance, epsilon, latitude, height, jd);
            Assert.Equal(expectedLambda, parallax.Lambda);
            Assert.Equal(expectedBeta, parallax.Beta);
            Assert.Equal(expectedSemidiameter, parallax.Semidiameter);
        }
    }
}