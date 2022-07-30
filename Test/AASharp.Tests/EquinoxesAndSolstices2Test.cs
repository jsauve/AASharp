using System.Linq;
using Xunit;

namespace AASharp.Tests
{
    public class EquinoxesAndSolstices2Test
    {
        [Fact]
        public void CalculateTest()
        {
            var events2 = AASEquinoxesAndSolstices2.Calculate(2458484.5008011586, 2458848.5008086604);

            var northwardEquinox = events2.First(e => e.type == AASEquinoxSolsticeDetails2.Type.NorthwardEquinox);
            var northernSolstice = events2.First(e => e.type == AASEquinoxSolsticeDetails2.Type.NorthernSolstice);
            var southwardEquinox = events2.First(e => e.type == AASEquinoxSolsticeDetails2.Type.SouthwardEquinox);
            var southernSolstice = events2.First(e => e.type == AASEquinoxSolsticeDetails2.Type.SouthernSolstice);

            Assert.Equal(2458563.4158664597, northwardEquinox.JD);
            Assert.Equal(2458656.1603451069, northernSolstice.JD);
            Assert.Equal(2458749.8271348597, southwardEquinox.JD);
            Assert.Equal(2458839.6815940812, southernSolstice.JD);
        }
    }
}