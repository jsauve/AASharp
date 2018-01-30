using System.Collections.Generic;
using Xunit;

namespace AASharp.Tests
{
    public class EclipsesTest
    {
        public static IEnumerable<object[]> CalculateSolarParameters()
        {
            yield return new object[]
            {
                -82,
                new AASSolarEclipseDetails
                {
                    Flags = AASSolarEclipseDetails.PARTIAL_ECLIPSE | AASSolarEclipseDetails.NON_CENTRAL_ECLIPSE,
                    TimeOfMaximumEclipse = 2449129.0978364432,
                    F = 165.72956003623403,
                    u = 0.0096879666045233681,
                    gamma = 1.1348100547345004,
                    GreatestMagnitude = 0.73951495954369761
                }
            };
            yield return new object[]
            {
                118,
                new AASSolarEclipseDetails
                {
                    Flags = AASSolarEclipseDetails.TOTAL_ECLIPSE | AASSolarEclipseDetails.CENTRAL_ECLIPSE,
                    TimeOfMaximumEclipse = 2455034.6087615537,
                    F = 179.83012044765928,
                    u = -0.015684815110318127,
                    gamma = 0.069522777221875665,
                    GreatestMagnitude = 0
                }
            };
        }

        [Theory]
        [MemberData(nameof(CalculateSolarParameters))]
        public void CalculateSolarTest(double k, AASSolarEclipseDetails expectedSolarEclipseDetails)
        {
            AASSolarEclipseDetails eclipseDetails = AASEclipses.CalculateSolar(k);
            Assert.Equal(expectedSolarEclipseDetails.Flags, eclipseDetails.Flags);
            Assert.Equal(expectedSolarEclipseDetails.TimeOfMaximumEclipse, eclipseDetails.TimeOfMaximumEclipse);
            Assert.Equal(expectedSolarEclipseDetails.F, eclipseDetails.F);
            Assert.Equal(expectedSolarEclipseDetails.u, eclipseDetails.u);
            Assert.Equal(expectedSolarEclipseDetails.gamma, eclipseDetails.gamma);
            Assert.Equal(expectedSolarEclipseDetails.GreatestMagnitude, eclipseDetails.GreatestMagnitude);
        }
        
        public static IEnumerable<object[]> CalculateLunarParameters()
        {
            yield return new object[]
            {
                -328.5,
                new AASLunarEclipseDetails
                {
                    bEclipse = true,
                    F = 345.4505034058966,
                    gamma = -1.3249058563891283,
                    PartialPhasePenumbraSemiDuration = 101.45053480814325,
                    PartialPhaseSemiDuration = 0,
                    PenumbralMagnitude = 0.46248252138436557,
                    PenumbralRadii = 1.3044588305436076,
                    TimeOfMaximumEclipse = 2441849.3686694875,
                    TotalPhaseSemiDuration = 0,
                    u = 0.019658830543607602,
                    UmbralMagnitude = -0.60874254483070822,
                    UmbralRadii = 0.72064116945639234
                }
            };
            yield return new object[]//No lunar eclipse
            {
                -30.5,
                new AASLunarEclipseDetails
                {
                    bEclipse = false,
                    F = 125.26046239992138,
                    gamma = 0,
                    PartialPhasePenumbraSemiDuration = 0,
                    PartialPhaseSemiDuration = 0,
                    PenumbralMagnitude = 0,
                    PenumbralRadii = 0,
                    TimeOfMaximumEclipse = 0,
                    TotalPhaseSemiDuration = 0,
                    u = 0,
                    UmbralMagnitude = 0,
                    UmbralRadii = 0,
                }
            };
            yield return new object[]//No lunar eclipse
            {
                -29.5,
                new AASLunarEclipseDetails
                {
                    bEclipse = false,
                    F = 155.93096530313414,
                    gamma = 0,
                    PartialPhasePenumbraSemiDuration = 0,
                    PartialPhaseSemiDuration = 0,
                    PenumbralMagnitude = 0,
                    PenumbralRadii = 0,
                    TimeOfMaximumEclipse = 0,
                    TotalPhaseSemiDuration = 0,
                    u = 0,
                    UmbralMagnitude = 0,
                    UmbralRadii = 0,
                }
            };
            yield return new object[]
            {
                -28.5,
                new AASLunarEclipseDetails
                {
                    bEclipse = true,
                    F = 186.6014682042387,
                    gamma = -0.37907614559025882,
                    PartialPhasePenumbraSemiDuration = 153.38103591272852,
                    PartialPhaseSemiDuration = 97.669853507410167,
                    PenumbralMagnitude = 2.1379157193235674,
                    PenumbralRadii = 1.2717402126216033,
                    TimeOfMaximumEclipse = 2450708.2835051473,
                    TotalPhaseSemiDuration = 30.312712724607287,
                    u = -0.013059787378396746,
                    UmbralMagnitude = 1.1867589757580508,
                    UmbralRadii = 0.75335978737839671
                }
            };
        }

        [Theory]
        [MemberData(nameof(CalculateLunarParameters))]
        public void CalculateLunarTest(double k, AASLunarEclipseDetails expectedLunarEclipseDetails)
        {
            AASLunarEclipseDetails eclipseDetails = AASEclipses.CalculateLunar(k);         
            Assert.Equal(expectedLunarEclipseDetails.bEclipse, eclipseDetails.bEclipse);
            Assert.Equal(expectedLunarEclipseDetails.F, eclipseDetails.F);
            Assert.Equal(expectedLunarEclipseDetails.gamma, eclipseDetails.gamma);
            Assert.Equal(expectedLunarEclipseDetails.PartialPhasePenumbraSemiDuration, eclipseDetails.PartialPhasePenumbraSemiDuration);
            Assert.Equal(expectedLunarEclipseDetails.PartialPhaseSemiDuration, eclipseDetails.PartialPhaseSemiDuration);
            Assert.Equal(expectedLunarEclipseDetails.PenumbralMagnitude, eclipseDetails.PenumbralMagnitude);
            Assert.Equal(expectedLunarEclipseDetails.PenumbralRadii, eclipseDetails.PenumbralRadii);
            Assert.Equal(expectedLunarEclipseDetails.TimeOfMaximumEclipse, eclipseDetails.TimeOfMaximumEclipse);
            Assert.Equal(expectedLunarEclipseDetails.TotalPhaseSemiDuration, eclipseDetails.TotalPhaseSemiDuration);
            Assert.Equal(expectedLunarEclipseDetails.u, eclipseDetails.u);
            Assert.Equal(expectedLunarEclipseDetails.UmbralMagnitude, eclipseDetails.UmbralMagnitude);
            Assert.Equal(expectedLunarEclipseDetails.UmbralRadii, eclipseDetails.UmbralRadii);
        }
    }
}