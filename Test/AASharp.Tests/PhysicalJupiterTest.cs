using System.Collections.Generic;
using Xunit;

namespace AASharp.Tests
{
    public class PhysicalJupiterTest
    {
        public static IEnumerable<object[]> CalculateParameters()
        {
            yield return new object[]
            {
                2448972.50068,
                false,
                new CAAPhysicalJupiterDetails
                {
                    DE = -2.4847151106937355,
                    DS = -2.1981310756592554,
                    Apparentw1 = 268.06313980652868,
                    Apparentw2 = 72.735437761719425,
                    Geometricw1 = 267.63462405291216,
                    Geometricw2 = 72.306922008102916,
                    P = 24.800807847334582
                }
            };
            yield return new object[]
            {
                2448972.50068,
                true,
                new CAAPhysicalJupiterDetails
                {
                    DE = -2.4846380183035937,
                    DS = -2.1980557587338838,
                    Apparentw1 = 268.06320592090793,
                    Apparentw2 = 72.735503254302941,
                    Geometricw1 = 267.63468803135646,
                    Geometricw2 = 72.306985364751455,
                    P = 24.800809089899719
                }
            };
        }

        [Theory]
        [MemberData(nameof(CalculateParameters))]
        public void TheoryTest(double JD, bool bHighPrecision, CAAPhysicalJupiterDetails expectedJupiterDetails)
        {
            CAAPhysicalJupiterDetails jupiterDetails = AASPhysicalJupiter.Calculate(JD, bHighPrecision);
            Assert.Equal(expectedJupiterDetails.DE, jupiterDetails.DE);
            Assert.Equal(expectedJupiterDetails.DS, jupiterDetails.DS);
            Assert.Equal(expectedJupiterDetails.Geometricw1, jupiterDetails.Geometricw1);
            Assert.Equal(expectedJupiterDetails.Geometricw2, jupiterDetails.Geometricw2);
            Assert.Equal(expectedJupiterDetails.Apparentw1, jupiterDetails.Apparentw1);
            Assert.Equal(expectedJupiterDetails.Apparentw2, jupiterDetails.Apparentw2);
            Assert.Equal(expectedJupiterDetails.P, jupiterDetails.P);
        }
    }
}
