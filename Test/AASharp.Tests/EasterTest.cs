using Xunit;

namespace AASharp.Tests
{
    public class EasterTest
    {
        [Theory]
        [InlineData(1991, true, 3, 31)]
        [InlineData(1818, true, 3, 22)]
        [InlineData(179, false, 4, 12)]
        public void ComputeEaster(int year, bool isGregorian, long expectedMonth, long expectedDay)
        {
            AASEasterDetails easterDetails = AASEaster.Calculate(year, isGregorian);

            Assert.Equal(expectedDay, easterDetails.Day);
            Assert.Equal(expectedMonth, easterDetails.Month);
        }       
    }
}