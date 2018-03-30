using Xunit;

namespace AASharp.Tests
{
    public class AngularSeparationTest
    {
        [Theory]
        [InlineData(14.261027777777779, 19.1825, 13.419888888888888, -11.161388888888888, 32.793010335135996)]
        [InlineData(2, 0, 2, 0, 0)]
        [InlineData(2, 0, 14, 0, 180)]
        public void SeparationTest(double alpha1, double delta1, double alpha2, double delta2, double expectedAngularSeparation)
        {
            double angularSeparation = AASAngularSeparation.Separation(alpha1, delta1, alpha2, delta2);
            Assert.Equal(expectedAngularSeparation, angularSeparation);
        }

        
        [Theory]
        [InlineData(5.5334444444444442, -0.2991388888888889, 5.603558333333333, -1.2019444444444445, 130.63784421851054)]
        [InlineData(5.6793111111111116, -1.9425833333333333, 5.603558333333333, -1.2019444444444445, 123.12086775102149)]
        public void PositionAngleTest(double alpha1, double delta1, double alpha2, double delta2, double expectedPositionAngle)
        {
            double positionAngle = AASAngularSeparation.PositionAngle(alpha1, delta1, alpha2, delta2);
            Assert.Equal(expectedPositionAngle, positionAngle);
        }

        [Theory]
        [InlineData(5.5334444444444442, -0.2991388888888889, 5.6793111111111116, -1.9425833333333333, 5.603558333333333, -1.2019444444444445, 0.089875699406236229)]
        public void DistanceFromGreatArcTest(double alpha1, double delta1, double alpha2, double delta2, double alpha3, double delta3, double expectedDistance)
        {
            double distance = AASAngularSeparation.DistanceFromGreatArc(alpha1, delta1, alpha2, delta2, alpha3, delta3);
            Assert.Equal(expectedDistance, distance);
        }

        [Theory]
        [InlineData(12.685730555555557, -5.6317222222222227, 12.868113888888889, -4.3739444444444437, 12.657808333333334, -1.8343611111111113, 4.2636415133960677, false)]
        [InlineData(9.0948444444444458, 18.508333333333333, 9.1580555555555563, 17.732416666666666, 8.996427777777777, 17.826888888888888, 2.3105371915590709, true)]
        public void SmallestCircleTest(double alpha1, double delta1, double alpha2, double delta2, double alpha3, double delta3, double expectedSeparation, bool expectedBType1)
        {
            bool bType1 = false;
            double separation =
                AASAngularSeparation.SmallestCircle(alpha1, delta1, alpha2, delta2, alpha3, delta3, ref bType1);

            Assert.Equal(expectedSeparation, separation);
            Assert.Equal(bType1, expectedBType1);
        }
    }
}