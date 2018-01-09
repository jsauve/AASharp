using Xunit;

namespace AASharp.Tests
{
    public class RefractionTest
    {
        [Theory]
        [InlineData(0.5, 0.47925102784407847, 0.41033661141786543)]
        [InlineData(90, -3.6122927158169228E-10, -0.00015807224687867412)]
        public void TheoryTest(double altitude, double expectedRefraction, double expectedRefractionFromTrue)
        {
            double R1 = AASRefraction.RefractionFromApparent(altitude);
            Assert.Equal(expectedRefraction, R1);

            double R2 = AASRefraction.RefractionFromTrue(altitude - R1 + AASCoordinateTransformation.DMSToDegrees(0, 32, 0));
            Assert.Equal(expectedRefractionFromTrue, R2);
        }
    }
}