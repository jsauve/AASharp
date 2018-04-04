using Xunit;

namespace AASharp.Tests.VSOP87
{
    public class VSOP87UranusTest
    {
        [Theory]
        [InlineData(2305445.0, 19.182207267890039)]
        public void ATest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Uranus.A(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.69021523367323567)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Uranus.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 6.236762469274673)]
        public void KTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Uranus.K(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.0091244200164874688)]
        public void HTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Uranus.H(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.0019242448224586234)]
        public void QTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Uranus.Q(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.0065416747575271512)]
        public void PTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Uranus.P(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}