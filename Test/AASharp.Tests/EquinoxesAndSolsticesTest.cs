using Xunit;

namespace AASharp.Tests
{
    public class EquinoxesAndSolsticesTest
    {
        [Theory]
        [InlineData(1962, false, 2437837.3921327158)]
        [InlineData(1962, true, 2437837.3921528598)]
        [InlineData(1996, false, 2450255.600529951)]
        [InlineData(1996, true, 2450255.6005360624)]
        [InlineData(2003, false, 2452812.2996082618)]
        [InlineData(2003, true, 2452812.2996761221)]
        public void NorthernSolsticeTest(long year, bool bHighPrecision, double expectedResult)
        {
            double juneSolstice = AASEquinoxesAndSolstices.NorthernSolstice(year, bHighPrecision);
            Assert.Equal(expectedResult, juneSolstice);
        }

        [Theory]
        [InlineData(1996, false, 2450439.0881509269)]
        [InlineData(1996, true, 2450439.0881434497)]
        [InlineData(1997, false, 2450804.3389824834)]
        [InlineData(1997, true, 2450804.3389486582)]
        [InlineData(2000, false, 2451900.0684589716)]
        [InlineData(2000, true, 2451900.0684013763)]
        [InlineData(2003, false, 2452995.7950505805)]
        [InlineData(2003, true, 2452995.795057992)]
        public void SouthernSolsticeTest(long year, bool bHighPrecision, double expectedResult)
        {
            double decemberSolstice = AASEquinoxesAndSolstices.SouthernSolstice(year, bHighPrecision);
            Assert.Equal(expectedResult, decemberSolstice);
        }

        [Theory]
        [InlineData(1996, false, 2450162.8362334687)]
        [InlineData(1996, true, 2450162.8361881799)]
        public void NorthwardEquinoxTest(long year, bool bHighPrecision, double expectedResult)
        {
            double marchEquinox = AASEquinoxesAndSolstices.NorthwardEquinox(year, bHighPrecision);
            Assert.Equal(expectedResult, marchEquinox);
        }

        [Theory]
        [InlineData(1996, false, 2450349.2507369881)]
        [InlineData(1996, true, 2450349.2507905965)]
        public void SouthwardEquinoxTest(long year, bool bHighPrecision, double expectedResult)
        {
            double septemberEquinox = AASEquinoxesAndSolstices.SouthwardEquinox(year, bHighPrecision);
            Assert.Equal(expectedResult, septemberEquinox);
        }

        [Theory]
        [InlineData(-2000, false, 94.286396640585735)]
        [InlineData(-2000, true, 94.286448843195103)]
        [InlineData(2000, false, 92.758618404623121)]
        [InlineData(2000, true, 92.758652227465063)]
        [InlineData(4000, false, 91.178408439736813)]
        [InlineData(4000, true, 91.178335872944444)]
        public void LengthOfSpringTest(long year, bool bHighPrecision, double expectedResult)
        {
            double springLength = AASEquinoxesAndSolstices.LengthOfSpring(year, true, bHighPrecision);
            Assert.Equal(expectedResult, springLength);
        }

        [Theory]
        [InlineData(-2000, false, 90.762898253742605)]
        [InlineData(-2000, true, 90.762723386171274)]
        [InlineData(2000, false, 93.652660072781146)]
        [InlineData(2000, true, 93.652698618825525)]
        [InlineData(4000, false, 93.9336535804905)]
        [InlineData(4000, true, 93.933674767613411)]
        public void LengthOfSummerTest(long year, bool bHighPrecision, double expectedResult)
        {
            double summerLength = AASEquinoxesAndSolstices.LengthOfSummer(year, true, bHighPrecision);
            Assert.Equal(expectedResult, summerLength);
        }

        [Theory]
        [InlineData(-2000, false, 88.393839993979782)]
        [InlineData(-2000, true, 88.393805515603162)]
        [InlineData(2000, false, 89.840221148915589)]
        [InlineData(2000, true, 89.840166262816638)]
        [InlineData(4000, false, 91.401426267810166)]
        [InlineData(4000, true, 91.401439854875207)]
        public void LengthOfAutumnTest(long year, bool bHighPrecision, double expectedResult)
        {
            double autumnLength = AASEquinoxesAndSolstices.LengthOfAutumn(year, true, bHighPrecision);
            Assert.Equal(expectedResult, autumnLength);
        }

        [Theory]
        [InlineData(-2000, false, 91.804609601036645)]
        [InlineData(-2000, true, 91.80475937074516)]
        [InlineData(2000, false, 88.995391126722097)]
        [InlineData(2000, true, 88.995333938393742)]
        [InlineData(4000, false, 88.729492589831352)]
        [InlineData(4000, true, 88.729444715194404)]
        public void LengthOfWinterTest(long year, bool bHighPrecision, double expectedResult)
        {
            double winterLength = AASEquinoxesAndSolstices.LengthOfWinter(year, true, bHighPrecision);
            Assert.Equal(expectedResult, winterLength);
        }
    }
}