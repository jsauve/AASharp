using Xunit;

namespace AASharp.Tests.VSOP87.D
{
    public class VSOP87DJupiterTest
    {
        [Theory]
        [InlineData(2122820.0, 6.275651733179787)]
        public void BTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Jupiter.B(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 1.2695066546288274)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Jupiter.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 5.1193587362421669)]
        public void RTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Jupiter.R(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 3.3517301153038289e-005)]
        public void BDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Jupiter.B_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.0014965116131368385)]
        public void LDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Jupiter.L_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.00034153813700466798)]
        public void RDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Jupiter.R_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}