using System.Collections.Generic;
using Xunit;

namespace AASharp.Tests
{
    public class SaturnRingsTest
    {
        public static IEnumerable<object[]> CalculateParameters()
        {
            yield return new object[]
            {
                2448972.50068,
                false,
                new AASSaturnRingDetails
                {
                    B = 16.441911835188233,
                    Bdash = 14.678969495066045,
                    P = 6.740577108250184,
                    a = 35.868661892109358,
                    b = 10.15237793459689,
                    DeltaU = 4.1982857963683387,
                    U1 = 153.26440381014817,
                    U2 = 149.06611801377983
                }
            };
            yield return new object[]
            {
                2448972.50068,
                true,
                new AASSaturnRingDetails
                {
                    B = 16.441844583758304,
                    Bdash = 14.678898781253425,
                    P = 6.7405724162259553,
                    a = 35.868527307510462,
                    b = 10.152299461971353,
                    DeltaU = 4.1982759482081349,
                    U1 = 153.26454330585148,
                    U2 = 149.06626735764334
                }
            };
        }

        [Theory]
        [MemberData(nameof(CalculateParameters))]
        public void CalculateTest(double jd, bool bHighPrecision, AASSaturnRingDetails expectedSaturnRingDetails)
        {
            AASSaturnRingDetails saturnRingsDetails = AASSaturnRings.Calculate(jd, bHighPrecision);
            Assert.Equal(expectedSaturnRingDetails.B, saturnRingsDetails.B);
            Assert.Equal(expectedSaturnRingDetails.Bdash, saturnRingsDetails.Bdash);
            Assert.Equal(expectedSaturnRingDetails.P, saturnRingsDetails.P);
            Assert.Equal(expectedSaturnRingDetails.a, saturnRingsDetails.a);
            Assert.Equal(expectedSaturnRingDetails.b, saturnRingsDetails.b);
            Assert.Equal(expectedSaturnRingDetails.DeltaU, saturnRingsDetails.DeltaU);
            Assert.Equal(expectedSaturnRingDetails.U1, saturnRingsDetails.U1);
            Assert.Equal(expectedSaturnRingDetails.U2, saturnRingsDetails.U2);
        }
    }
}