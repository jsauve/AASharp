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
        public void CalculateTopocentricTest(double JD, double Longitude, double Latitude, AASPhysicalMoonDetails expectedPhysicalMoonDetails)
        {
            AASPhysicalMoonDetails moonDetails = AASPhysicalMoon.CalculateTopocentric(JD, Longitude, Latitude);
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
                    l0 = 67.897706719345777,
                    b0 = 1.4616960275417989,
                    c0 = 22.102293280654237
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
        [InlineData(2448724.5, -20, 9.7, false, 2.317984493291692)]
        public void AltitudeOfSunTest(double JD, double Longitude, double Latitude, bool bHighPrecision, double expectedAltitudeOfSun)
        {
            double altitudeOfSun = AASPhysicalMoon.AltitudeOfSun(JD, Longitude, Latitude, bHighPrecision);
            Assert.Equal(expectedAltitudeOfSun, altitudeOfSun);
        }

        [Theory]
        [InlineData(2448724.5, -20, 9.7, false, 2448724.3069190998)]
        public void TimeOfSunriseTest(double JD, double Longitude, double Latitude, bool bHighPrecision, double expectedTimeOfSunrise)
        {
            double timeOfSunrise = AASPhysicalMoon.TimeOfSunrise(JD, Longitude, Latitude, bHighPrecision);
            Assert.Equal(expectedTimeOfSunrise, timeOfSunrise);
        }

        [Theory]
        [InlineData(2448724.5, -20, 9.7, false, 2448739.1230258164)]
        public void TimeOfSunsetTest(double JD, double Longitude, double Latitude, bool bHighPrecision, double expectedTimeOfSunset)
        {
            double timeOfSunset = AASPhysicalMoon.TimeOfSunset(JD, Longitude, Latitude, bHighPrecision);
            Assert.Equal(expectedTimeOfSunset, timeOfSunset);
        }  
    }
}