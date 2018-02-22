using System.Collections.Generic;
using Xunit;

namespace AASharp.Tests
{
    public class PhysicalMoonTest
    {
        public static IEnumerable<object[]> CalculateGeocentricParameters()
        {
            yield return new object[]
            {
                2448724.5,
                new AASPhysicalMoonDetails
                {
                    ldash = -1.2011769450209613,
                    bdash = 4.1941281185712969,
                    ldash2 = -0.025416136046572585,
                    bdash2 = 0.0057710686191127306,
                    l = -1.2265930810675338,
                    b = 4.1998991871904092,
                    P = 15.084132922109571
                }
            };
        }

        [Theory]
        [MemberData(nameof(CalculateGeocentricParameters))]
        public void CalculateGeocentricTest(double JD, AASPhysicalMoonDetails expectedPhysicalMoonDetails)
        {
            AASPhysicalMoonDetails moonDetails = AASPhysicalMoon.CalculateGeocentric(JD);
            Assert.Equal(expectedPhysicalMoonDetails.ldash, moonDetails.ldash);
            Assert.Equal(expectedPhysicalMoonDetails.bdash, moonDetails.bdash);
            Assert.Equal(expectedPhysicalMoonDetails.ldash2, moonDetails.ldash2);
            Assert.Equal(expectedPhysicalMoonDetails.bdash2, moonDetails.bdash2);
            Assert.Equal(expectedPhysicalMoonDetails.l, moonDetails.l);
            Assert.Equal(expectedPhysicalMoonDetails.b, moonDetails.b);
            Assert.Equal(expectedPhysicalMoonDetails.P, moonDetails.P);
        }


        public static IEnumerable<object[]> CalculateTopocentricParameters()
        {
            yield return new object[]
            {
                2448724.5,
                10,
                52,
                new AASPhysicalMoonDetails
                {
                    ldash = -1.2011769450209613,
                    bdash = 4.1941281185712969,
                    ldash2 = -0.025416136046572585,
                    bdash2 = 0.0057710686191127306,
                    l = -1.5413560004529727,
                    b = 4.9923080567192111,
                    P = 14.93193979658186
                }
            };
        }

        [Theory]
        [MemberData(nameof(CalculateTopocentricParameters))]
        public void CalculateTopocentricTest(double JD, double longitude, double latitude, AASPhysicalMoonDetails expectedPhysicalMoonDetails)
        {
            AASPhysicalMoonDetails moonDetails = AASPhysicalMoon.CalculateTopocentric(JD, longitude, latitude);
            Assert.Equal(expectedPhysicalMoonDetails.ldash, moonDetails.ldash);
            Assert.Equal(expectedPhysicalMoonDetails.bdash, moonDetails.bdash);
            Assert.Equal(expectedPhysicalMoonDetails.ldash2, moonDetails.ldash2);
            Assert.Equal(expectedPhysicalMoonDetails.bdash2, moonDetails.bdash2);
            Assert.Equal(expectedPhysicalMoonDetails.l, moonDetails.l);
            Assert.Equal(expectedPhysicalMoonDetails.b, moonDetails.b);
            Assert.Equal(expectedPhysicalMoonDetails.P, moonDetails.P);
        }

        public static IEnumerable<object[]> CalculateSelenographicPositionOfSunParameters()
        {
            yield return new object[]
            {
                2448724.5,
                false,
                new AASSelenographicMoonDetails
                {
                    l0 = 67.89770671927036,
                    c0 = 22.102293280729668,
                    b0 = 1.4616960275424351
                }
            };
            yield return new object[]
            {
                2448724.5,
                true,
                new AASSelenographicMoonDetails
                {
                    l0 = 67.897733452671545,
                    b0 = 1.4616957959885231,
                    c0 = 22.102266547328441
                }
            };
        }

        [Theory]
        [MemberData(nameof(CalculateSelenographicPositionOfSunParameters))]
        public void CalculateSelenographicPositionOfSunTest(double JD, bool bHighPrecision, AASSelenographicMoonDetails expectedSelenographicMoonDetails)
        {
            AASSelenographicMoonDetails moonDetails = AASPhysicalMoon.CalculateSelenographicPositionOfSun(JD, bHighPrecision);
            Assert.Equal(expectedSelenographicMoonDetails.l0, moonDetails.l0);
            Assert.Equal(expectedSelenographicMoonDetails.b0, moonDetails.b0);
            Assert.Equal(expectedSelenographicMoonDetails.c0, moonDetails.c0);
        }

        [Theory]
        [InlineData(2448724.5, -20, 9.7, false, 2.31798449336614)]
        [InlineData(2448724.5, -20, 9.7, true, 2.3179581080871139)]
        public void AltitudeOfSunTest(double JD, double longitude, double latitude, bool bHighPrecision, double expectedAltitudeOfSun)
        {
            double altitudeOfSun = AASPhysicalMoon.AltitudeOfSun(JD, longitude, latitude, bHighPrecision);
            Assert.Equal(expectedAltitudeOfSun, altitudeOfSun);
        }

        [Theory]
        [InlineData(2448724.5, -20, 9.7, false, 2448724.3069190998)]
        [InlineData(2448724.5, -20, 9.7, true, 2448724.3069211878)]
        public void TimeOfSunriseTest(double JD, double longitude, double latitude, bool bHighPrecision, double expectedTimeOfSunrise)
        {
            double timeOfSunrise = AASPhysicalMoon.TimeOfSunrise(JD, longitude, latitude, bHighPrecision);
            Assert.Equal(expectedTimeOfSunrise, timeOfSunrise);
        }

        [Theory]
        [InlineData(2448724.5, -20, 9.7, false, 2448739.1230258164)]
        [InlineData(2448724.5, -20, 9.7, true, 2448739.1230279966)]
        public void TimeOfSunsetTest(double JD, double longitude, double latitude, bool bHighPrecision, double expectedTimeOfSunset)
        {
            double timeOfSunset = AASPhysicalMoon.TimeOfSunset(JD, longitude, latitude, bHighPrecision);
            Assert.Equal(expectedTimeOfSunset, timeOfSunset);
        }  
    }
}