using Xunit;

namespace AASharp.Tests.VSOP87.D
{
    public class VSOP87DEarthTest
    {
        [Theory]
        [InlineData(2122820.0, 6.2831821780219732)]
        public void BTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Earth.B(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 1.6367193623173932)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Earth.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.98303318150406693)]
        public void RTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Earth.R(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, -1.5630126729423686E-07)]
        public void BDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Earth.B_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.017803619406062)]
        public void LDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Earth.L_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 2.7374661144823536e-005)]
        public void RDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Earth.R_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}