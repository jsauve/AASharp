using System.Collections.Generic;
using Xunit;

namespace AASharp.Tests
{
    public class PhysicalMarsTest
    {
        public static IEnumerable<object[]> CalculateParameters()
        {
            yield return new object[]
            {
                2448935.500683,
                false,
                new CAAPhysicalMarsDetails
                {
                    DE = 12.437028414455451,
                    DS = -2.7578433421012014,
                    w = 111.55420394167832,
                    P = 347.64317519316489,
                    X = 99.91114758821486,
                    k = 0.9011827295163326,
                    q = 1.062550069786006,
                    d = 10.752675767963305
                }
            };
            yield return new object[]
            {
                2448935.500683,
                true,
                new CAAPhysicalMarsDetails
                {
                    DE = 12.437155758807751,
                    DS = -2.757794840729523,
                    w = 111.5541985379504,
                    P = 347.64319089152372,
                    X = 99.911197481892799,
                    k = 0.90118225093707383,
                    q = 1.0625561894989062,
                    d = 10.752685621509967
                }
            };
        }

        [Theory]
        [MemberData(nameof(CalculateParameters))]
        public void TheoryTest(double JD, bool bHighPrecision, CAAPhysicalMarsDetails expectedPhysicalMarsDetails)
        {
            CAAPhysicalMarsDetails marsDetails = AASPhysicalMars.Calculate(JD, bHighPrecision);
            Assert.Equal(expectedPhysicalMarsDetails.DE, marsDetails.DE);
            Assert.Equal(expectedPhysicalMarsDetails.DS, marsDetails.DS);
            Assert.Equal(expectedPhysicalMarsDetails.w, marsDetails.w);
            Assert.Equal(expectedPhysicalMarsDetails.P, marsDetails.P);
            Assert.Equal(expectedPhysicalMarsDetails.X, marsDetails.X);
            Assert.Equal(expectedPhysicalMarsDetails.k, marsDetails.k);
            Assert.Equal(expectedPhysicalMarsDetails.q, marsDetails.q);
            Assert.Equal(expectedPhysicalMarsDetails.d, marsDetails.d);
        }
    }
}