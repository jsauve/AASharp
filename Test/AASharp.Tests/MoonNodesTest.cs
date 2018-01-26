using Xunit;

namespace AASharp.Tests
{
    public class MoonNodesTest
    {
        [Theory]
        [InlineData(-170, 2446938.7680294365)]
        public void PassageThroNodeTest(double k, double expectedJD)
        {
            double moonJd = AASMoonNodes.PassageThroNode(k);
            Assert.Equal(expectedJD, moonJd);

        }


        [Theory]
        [InlineData(1987.37, -170.19476400000084)]
        public void KTest(double year, double expectedK)
        {
            double k = AASMoonNodes.K(year);
            Assert.Equal(expectedK, k);
        }



    }
}