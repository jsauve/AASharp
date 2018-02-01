using Xunit;

namespace AASharp.Tests
{
    public class CoordinateTransformationTest
    {
        [Fact]
        public void Equatorial2EclipticTest()
        {
            AAS2DCoordinate Ecliptic = AASCoordinateTransformation.Equatorial2Ecliptic(AASCoordinateTransformation.DMSToDegrees(7, 45, 18.946), AASCoordinateTransformation.DMSToDegrees(28, 01, 34.26), 23.4392911);
            Assert.Equal(113.215629227584, Ecliptic.X);
            Assert.Equal(6.6841700720452888, Ecliptic.Y);
        }

        [Fact]
        public void Ecliptic2EquatorialTest()
        {
            var equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(113.215629227584, 6.6841700720452888, 23.4392911);
            Assert.Equal(7.7552627777777783, equatorial.X);
            Assert.Equal(28.026183333333329, equatorial.Y);
        }

        [Fact]
        public void Equatorial2GalacticTest()
        {
            AAS2DCoordinate galactic = AASCoordinateTransformation.Equatorial2Galactic(AASCoordinateTransformation.DMSToDegrees(17, 48, 59.74), AASCoordinateTransformation.DMSToDegrees(14, 43, 8.2, false));
            Assert.Equal(12.959250041566406, galactic.X);
            Assert.Equal(6.0462984779957027, galactic.Y);
        }

        [Fact]
        public void Galactic2EquatorialTest()
        {
            AAS2DCoordinate equatorial = AASCoordinateTransformation.Galactic2Equatorial(12.959250041566406, 6.0462984779957027);
            Assert.Equal(17.816594444444444, equatorial.X);
            Assert.Equal(-14.718944444444446, equatorial.Y);

        }

        [Fact]
        public void Equatorial2HorizontalTest()
        {
            var date = new AASDate();
            date.Set(1987, 4, 10, 19, 21, 0, true);
            var AST = AASSidereal.ApparentGreenwichSiderealTime(date.Julian);
            var longtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(AASCoordinateTransformation.DMSToDegrees(77, 3, 56));
            double alpha = AASCoordinateTransformation.DMSToDegrees(23, 9, 16.641);
            var localHourAngle = AST - longtitudeAsHourAngle - alpha;

            AAS2DCoordinate Horizontal = AASCoordinateTransformation.Equatorial2Horizontal(localHourAngle, AASCoordinateTransformation.DMSToDegrees(6, 43, 11.61, false), AASCoordinateTransformation.DMSToDegrees(38, 55, 17));
            Assert.Equal(68.033595944105741, Horizontal.X);
            Assert.Equal(15.12497383921664, Horizontal.Y);

            AAS2DCoordinate equatorial = AASCoordinateTransformation.Horizontal2Equatorial(Horizontal.X, Horizontal.Y, AASCoordinateTransformation.DMSToDegrees(38, 55, 17));
            Assert.Equal(4.2901329760498026, equatorial.X);
            Assert.Equal(-6.7198916666666628, equatorial.Y);

            double alpha2 = AASCoordinateTransformation.MapTo0To24Range(AST - equatorial.X - longtitudeAsHourAngle);
            Assert.Equal(23.1546225, alpha2);
        }


        
    }
}