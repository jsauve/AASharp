using Xunit;

namespace AASharp.Tests.VSOP87.D
{
    public class VSOP87DMarsTest
    {
        [Theory]
        [InlineData(2122820.0, 0.029552271923718166)]
        public void BTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Mars.B(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 2.7367104344245519)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Mars.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 1.6571002307100959)]
        public void RTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Mars.R(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, -0.00010218690516103185)]
        public void BDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Mars.B_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.0077025916943912216)]
        public void LDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Mars.L_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, -0.00038600802469561179)]
        public void RDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Mars.R_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}