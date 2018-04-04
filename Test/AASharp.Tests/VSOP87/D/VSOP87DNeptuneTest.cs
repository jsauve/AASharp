using Xunit;

namespace AASharp.Tests.VSOP87.D
{
    public class VSOP87DNeptuneTest
    {
        [Theory]
        [InlineData(2122820.0, 0.0027498092770598796)]
        public void BTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Neptune.B(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 2.2124988266512204)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Neptune.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 30.065369360953003)]
        public void RTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Neptune.R(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 3.3730234087714225e-006)]
        public void BDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Neptune.B_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.0001051888114460019)]
        public void LDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Neptune.L_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 3.1440054056983516E-05)]
        public void RDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Neptune.R_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}