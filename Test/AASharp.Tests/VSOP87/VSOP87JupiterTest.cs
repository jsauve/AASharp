using Xunit;

namespace AASharp.Tests.VSOP87
{
    public class VSOP87JupiterTest
    {
        [Theory]
        [InlineData(2305445.0, 5.2018720769568434)]
        public void ATest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Jupiter.A(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 2.3540228342049119)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Jupiter.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.046873601567457519)]
        public void KTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Jupiter.K(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.010357779590825379)]
        public void HTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Jupiter.H(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 6.2812492564277118)]
        public void QTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Jupiter.Q(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.011277452657551918)]
        public void PTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Jupiter.P(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}