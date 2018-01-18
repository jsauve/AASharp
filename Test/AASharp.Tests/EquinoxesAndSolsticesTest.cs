using Xunit;

namespace AASharp.Tests
{
    public class EquinoxesAndSolsticesTest
    {
        [Theory]
        [InlineData(1962, false, 2437837.3921327158)]
        [InlineData(1996, false, 2450255.600529951)]
        [InlineData(2003, false, 2452812.2996082618)]
        public void NorthernSolsticeTest(long year, bool bHighPrecision, double expectedResult)
        {
            double juneSolstice = AASEquinoxesAndSolstices.NorthernSolstice(year, bHighPrecision);
            Assert.Equal(expectedResult, juneSolstice);
        }

        [Theory]
        [InlineData(1996, false, 2450439.0881509269)]
        [InlineData(1997, false, 2450804.3389824834)]
        [InlineData(2000, false, 2451900.0684589716)]
        [InlineData(2003, false, 2452995.7950505805)]
        public void SouthernSolsticeTest(long year, bool bHighPrecision, double expectedResult)
        {
            double decemberSolstice = AASEquinoxesAndSolstices.SouthernSolstice(year, bHighPrecision);
            Assert.Equal(expectedResult, decemberSolstice);
        }

        [Theory]
        [InlineData(1996, false, 2450162.8362334687)]
        public void NorthwardEquinoxTest(long year, bool bHighPrecision, double expectedResult)
        {
            double marchEquinox = AASEquinoxesAndSolstices.NorthwardEquinox(year, bHighPrecision);
            Assert.Equal(expectedResult, marchEquinox);
        }

        [Theory]
        [InlineData(1996, false, 2450349.2507369881)]
        public void SouthwardEquinoxTest(long year, bool bHighPrecision, double expectedResult)
        {
            double septemberEquinox = AASEquinoxesAndSolstices.SouthwardEquinox(year, bHighPrecision);
            Assert.Equal(expectedResult, septemberEquinox);
        }

        [Theory]
        [InlineData(-2000, false, 94.286396640236489)]
        [InlineData(2000, false, 92.758618404623121)]
        [InlineData(4000, false, 91.178408439736813)]
        public void LengthOfSpringTest(long year, bool bHighPrecision, double expectedResult)
        {
            double springLength = AASEquinoxesAndSolstices.LengthOfSpring(year, true, bHighPrecision);
            Assert.Equal(expectedResult, springLength);
        }

        [Theory]
        [InlineData(-2000, false, 90.7628982537426)]
        [InlineData(2000, false, 93.652660072781146)]
        [InlineData(4000, false, 93.9336535804905)]
        public void LengthOfSummerTest(long year, bool bHighPrecision, double expectedResult)
        {
            double summerLength = AASEquinoxesAndSolstices.LengthOfSummer(year, true, bHighPrecision);
            Assert.Equal(expectedResult, summerLength);
        }

        [Theory]
        [InlineData(-2000, false, 88.393839993979782)]
        [InlineData(2000, false, 89.840221148915589)]
        [InlineData(4000, false, 91.401426267810166)]
        public void LengthOfAutumnTest(long year, bool bHighPrecision, double expectedResult)
        {
            double autumnLength = AASEquinoxesAndSolstices.LengthOfAutumn(year, true, bHighPrecision);
            Assert.Equal(expectedResult, autumnLength);
        }

        [Theory]
        [InlineData(-2000, false, 91.8046096006874)]
        [InlineData(2000, false, 88.9953911267221)]
        [InlineData(4000, false, 88.729492589831352)]
        public void LengthOfWinterTest(long year, bool bHighPrecision, double expectedResult)
        {
            double winterLength = AASEquinoxesAndSolstices.LengthOfWinter(year, true, bHighPrecision);
            Assert.Equal(expectedResult, winterLength);
        }
    }
}