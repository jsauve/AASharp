using Xunit;

namespace AASharp.Tests
{
    public class GlobeTest
    {
        [Theory]
        [InlineData(33.356111, 1706, 0.54686082540809344)]
        public void RhoSinThetaPrimeTest(double geographicalLatitude, double height, double expectedRhoSinTheta)
        {
            double rhosintheta = AASGlobe.RhoSinThetaPrime(geographicalLatitude, height);
            Assert.Equal(expectedRhoSinTheta, rhosintheta);
        }

        [Theory]
        [InlineData(33.356111, 1706, 0.83633923261298548)]
        public void RhoCosThetaPrimeTest(double geographicalLatitude, double height, double expectedRhoCosTheta)
        {
            double rhocostheta = AASGlobe.RhoCosThetaPrime(geographicalLatitude, height);
            Assert.Equal(expectedRhoCosTheta, rhocostheta);
        }

        [Theory]
        [InlineData(42, 4747.0012061560883)]
        public void RadiusOfParallelOfLatitudeTest(double geographicalLatitude, double expectedRadiusOfLatitude)
        {
            double radiusOfLatitude = AASGlobe.RadiusOfParallelOfLatitude(geographicalLatitude);
            Assert.Equal(expectedRadiusOfLatitude, radiusOfLatitude);
        }

        [Theory]
        [InlineData(42, 6364.0333496136782)]
        public void RadiusOfCurvatureTest(double geographicalLatitude, double expectedRadiusOfCurvature)
        {
            double radiusOfCurvature = AASGlobe.RadiusOfCurvature(geographicalLatitude);
            Assert.Equal(expectedRadiusOfCurvature, radiusOfCurvature);
        }


        [Theory]
        [InlineData(48.836388888888891, -2.3372222222222225, 38.921388888888885, 77.065555555555548, 6181.6284237262989)]
        [InlineData(50, 0, 50, 60, 4182.0661922424169)]
        [InlineData(50, 0, 50, 1, 71.695073985889309)]
        [InlineData(89.983333333333334, 0, 89.983333333333334, 1, 0.032489698916685648)]
        [InlineData(89.983333333333334, 0, 89.983333333333334, 180, 3.7230925584266372)]
        [InlineData(89.983333333333334, 0, 89.983333333333334, 90, 2.6326239764851493)]
        public void DistanceBetweenPointsTest(double geographicalLatitude1, double geographicalLongitude1, double geographicalLatitude2, double geographicalLongitude2, double expectedDistance)
        {
            double distance = AASGlobe.DistanceBetweenPoints(geographicalLatitude1, geographicalLongitude1, geographicalLatitude2, geographicalLongitude2);
            Assert.Equal(expectedDistance, distance);
        }
    }
}