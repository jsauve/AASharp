using Xunit;

namespace AASharp.Tests
{
    public class GlobeTest
    {
        [Fact]
        public void RhoSinThetaPrimeTest()
        {
            double rhosintheta = AASGlobe.RhoSinThetaPrime(33.356111, 1706);
            Assert.Equal(0.54686082540809344, rhosintheta);
        }

        [Fact]
        public void RhoCosThetaPrimeTest()
        {
            double rhocostheta = AASGlobe.RhoCosThetaPrime(33.356111, 1706);
            Assert.Equal(0.83633923261298548, rhocostheta);
        }

        [Fact]
        public void RadiusOfParallelOfLatitudeTest()
        {
            double radiusOfLatitude = AASGlobe.RadiusOfParallelOfLatitude(42);
            Assert.Equal(4747.0012061560883, radiusOfLatitude);
        }

        [Fact]
        public void RadiusOfCurvatureTest()
        {
            double radiusOfCurvature = AASGlobe.RadiusOfCurvature(42);
            Assert.Equal(6364.0333496136782, radiusOfCurvature);
        }


        [Fact]
        public void DistanceBetweenPointsTest()
        {
            double Distance = AASGlobe.DistanceBetweenPoints(AASCoordinateTransformation.DMSToDegrees(48, 50, 11), AASCoordinateTransformation.DMSToDegrees(2, 20, 14, false), AASCoordinateTransformation.DMSToDegrees(38, 55, 17), AASCoordinateTransformation.DMSToDegrees(77, 3, 56));
            Assert.Equal(6181.6284237262989, Distance);
            
            double Distance1 = AASGlobe.DistanceBetweenPoints(50, 0, 50, 60);
            Assert.Equal(4182.0661922424169, Distance1);

            double Distance2 = AASGlobe.DistanceBetweenPoints(50, 0, 50, 1);
            Assert.Equal(71.695073985889309, Distance2);

            double Distance3 = AASGlobe.DistanceBetweenPoints(AASCoordinateTransformation.DMSToDegrees(89, 59, 0), 0, AASCoordinateTransformation.DMSToDegrees(89, 59, 0), 1);
            Assert.Equal(0.032489698916685648, Distance3);

            double Distance4 = AASGlobe.DistanceBetweenPoints(AASCoordinateTransformation.DMSToDegrees(89, 59, 0), 0, AASCoordinateTransformation.DMSToDegrees(89, 59, 0), 180);
            Assert.Equal(3.7230925584266372, Distance4);

            double Distance5 = AASGlobe.DistanceBetweenPoints(AASCoordinateTransformation.DMSToDegrees(89, 59, 0), 0, AASCoordinateTransformation.DMSToDegrees(89, 59, 0), 90);
            Assert.Equal(2.6326239764851493, Distance5);
        }
    }
}