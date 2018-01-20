using Xunit;

namespace AASharp.Tests
{
    public class ElementsPlanetaryOrbitTest
    {
        #region Mercury

        [Theory]
        [InlineData(2475460.5, 203.49470137557364)]
        public void MercuryMeanLongitudeTest(double jd, double expectedMeanLongitude)
        {
            double meanLongitude = AASElementsPlanetaryOrbit.MercuryMeanLongitude(jd);
            Assert.Equal(expectedMeanLongitude, meanLongitude);
        }

        [Fact]
        public void MercurySemimajorAxisTest()
        {
            double semimajorAxis = AASElementsPlanetaryOrbit.MercurySemimajorAxis();
            Assert.Equal(0.387098310, semimajorAxis);
        }

        [Theory]
        [InlineData(2475460.5, 0.20564509972233957)]
        public void MercuryEccentricityTest(double jd, double expectedEccentricity)
        {
            double eccentricity = AASElementsPlanetaryOrbit.MercuryEccentricity(jd);
            Assert.Equal(expectedEccentricity, eccentricity);
        }

        [Theory]
        [InlineData(2475460.5, 7.0061709206426288)]
        public void MercuryInclinationTest(double jd, double expectedInclination)
        {
            double inclination = AASElementsPlanetaryOrbit.MercuryInclination(jd);
            Assert.Equal(expectedInclination, inclination);
        }

        [Theory]
        [InlineData(2475460.5, 49.107649616686395)]
        public void MercuryLongitudeAscendingNodeTest(double jd, double expectedLongitudeAscendingNode)
        {
            double longitudeAscendingNode = AASElementsPlanetaryOrbit.MercuryLongitudeAscendingNode(jd);
            Assert.Equal(expectedLongitudeAscendingNode, longitudeAscendingNode);
        }

        [Theory]
        [InlineData(2475460.5, 78.475381600408141)]
        public void MercuryLongitudePerihelionTest(double jd, double expectedLongitudePerihelion)
        {
            double longitudePerihelion = AASElementsPlanetaryOrbit.MercuryLongitudePerihelion(jd);
            Assert.Equal(expectedLongitudePerihelion, longitudePerihelion);
        }

        [Theory]
        [InlineData(2475460.5, 202.57945270944037)]
        public void MercuryMeanLongitudeJ2000Test(double jd, double expectedMeanLongitude)
        {
            double meanLongitude = AASElementsPlanetaryOrbit.MercuryMeanLongitudeJ2000(jd);
            Assert.Equal(expectedMeanLongitude, meanLongitude);
        }

        [Theory]
        [InlineData(2475460.5, 7.0010894217226856)]
        public void MercuryInclinationJ2000Test(double jd, double expectedInclination)
        {
            double inclination = AASElementsPlanetaryOrbit.MercuryInclinationJ2000(jd);
            Assert.Equal(expectedInclination, inclination);
        }

        [Theory]
        [InlineData(2475460.5, 48.248731964904515)]
        public void MercuryLongitudeAscendingNodeJ2000Test(double jd, double expectedLongitudeAscendingNode)
        {
            double longitudeAscendingNode = AASElementsPlanetaryOrbit.MercuryLongitudeAscendingNodeJ2000(jd);
            Assert.Equal(expectedLongitudeAscendingNode, longitudeAscendingNode);
        }

        [Theory]
        [InlineData(2475460.5, 77.560132934259613)]
        public void MercuryLongitudePerihelionJ2000Test(double jd, double expectedLongitudePerihelion)
        {
            double longitudePerihelion = AASElementsPlanetaryOrbit.MercuryLongitudePerihelionJ2000(jd);
            Assert.Equal(expectedLongitudePerihelion, longitudePerihelion);
        }

        #endregion

        #region Venus

        [Theory]
        [InlineData(2475460.5, 338.64630559785292)]
        public void VenusMeanLongitudeTest(double jd, double expectedMeanLongitude)
        {
            double meanLongitude = AASElementsPlanetaryOrbit.VenusMeanLongitude(jd);
            Assert.Equal(expectedMeanLongitude, meanLongitude);
        }

        [Fact]
        public void VenusSemimajorAxisTest()
        {
            double semimajorAxis = AASElementsPlanetaryOrbit.VenusSemimajorAxis();
            Assert.Equal(0.723329820, semimajorAxis);
        }

        [Theory]
        [InlineData(2475460.5, 0.0067406870642960906)]
        public void VenusEccentricityTest(double jd, double expectedEccentricity)
        {
            double eccentricity = AASElementsPlanetaryOrbit.VenusEccentricity(jd);
            Assert.Equal(expectedEccentricity, eccentricity);
        }

        [Theory]
        [InlineData(2475460.5, 3.3953188141138755)]
        public void VenusInclinationTest(double jd, double expectedInclination)
        {
            double inclination = AASElementsPlanetaryOrbit.VenusInclination(jd);
            Assert.Equal(expectedInclination, inclination);
        }

        [Theory]
        [InlineData(2475460.5, 77.270121483831261)]
        public void VenusLongitudeAscendingNodeTest(double jd, double expectedLongitudeAscendingNode)
        {
            double longitudeAscendingNode = AASElementsPlanetaryOrbit.VenusLongitudeAscendingNode(jd);
            Assert.Equal(expectedLongitudeAscendingNode, longitudeAscendingNode);
        }

        [Theory]
        [InlineData(2475460.5, 132.48137836111309)]
        public void VenusLongitudePerihelionTest(double jd, double expectedLongitudePerihelion)
        {
            double longitudePerihelion = AASElementsPlanetaryOrbit.VenusLongitudePerihelion(jd);
            Assert.Equal(expectedLongitudePerihelion, longitudePerihelion);
        }

        [Theory]
        [InlineData(2475460.5, 337.73122674113984)]
        public void VenusMeanLongitudeJ2000Test(double jd, double expectedMeanLongitude)
        {
            double meanLongitude = AASElementsPlanetaryOrbit.VenusMeanLongitudeJ2000(jd);
            Assert.Equal(expectedMeanLongitude, meanLongitude);
        }

        [Theory]
        [InlineData(2475460.5, 3.3940870871579127)]
        public void VenusInclinationJ2000Test(double jd, double expectedInclination)
        {
            double inclination = AASElementsPlanetaryOrbit.VenusInclinationJ2000(jd);
            Assert.Equal(expectedInclination, inclination);
        }

        [Theory]
        [InlineData(2475460.5, 76.497823800768941)]
        public void VenusLongitudeAscendingNodeJ2000Test(double jd, double expectedLongitudeAscendingNode)
        {
            double longitudeAscendingNode = AASElementsPlanetaryOrbit.VenusLongitudeAscendingNodeJ2000(jd);
            Assert.Equal(expectedLongitudeAscendingNode, longitudeAscendingNode);
        }

        [Theory]
        [InlineData(2475460.5, 131.56629950440163)]
        public void VenusLongitudePerihelionJ2000Test(double jd, double expectedLongitudePerihelion)
        {
            double longitudePerihelion = AASElementsPlanetaryOrbit.VenusLongitudePerihelionJ2000(jd);
            Assert.Equal(expectedLongitudePerihelion, longitudePerihelion);
        }

        #endregion

        #region Earth

        [Theory]
        [InlineData(2475460.5, 272.71602757163782)]
        public void EarthMeanLongitudeTest(double jd, double expectedMeanLongitude)
        {
            double meanLongitude = AASElementsPlanetaryOrbit.EarthMeanLongitude(jd);
            Assert.Equal(expectedMeanLongitude, meanLongitude);
        }

        [Fact]
        public void EarthSemimajorAxisTest()
        {
            double semimajorAxis = AASElementsPlanetaryOrbit.EarthSemimajorAxis();
            Assert.Equal(1.000001018, semimajorAxis);
        }

        [Theory]
        [InlineData(2475460.5, 0.016681051123757881)]
        public void EarthEccentricityTest(double jd, double expectedEccentricity)
        {
            double eccentricity = AASElementsPlanetaryOrbit.EarthEccentricity(jd);
            Assert.Equal(expectedEccentricity, eccentricity);
        }

        [Fact]
        public void EarthInclinationTest()
        {
            double inclination = AASElementsPlanetaryOrbit.EarthInclination();
            Assert.Equal(0, inclination);
        }
        
        [Theory]
        [InlineData(2475460.5, 103.70490479485865)]
        public void EarthLongitudePerihelionTest(double jd, double expectedLongitudePerihelion)
        {
            double longitudePerihelion = AASElementsPlanetaryOrbit.EarthLongitudePerihelion(jd);
            Assert.Equal(expectedLongitudePerihelion, longitudePerihelion);
        }

        [Theory]
        [InlineData(2475460.5, 271.80119924972678)]
        public void EarthMeanLongitudeJ2000Test(double jd, double expectedMeanLongitude)
        {
            double meanLongitude = AASElementsPlanetaryOrbit.EarthMeanLongitudeJ2000(jd);
            Assert.Equal(expectedMeanLongitude, meanLongitude);
        }

        [Theory]
        [InlineData(2475460.5, 0.0085438996284984414)]
        public void EarthInclinationJ2000Test(double jd, double expectedInclination)
        {
            double inclination = AASElementsPlanetaryOrbit.EarthInclinationJ2000(jd);
            Assert.Equal(expectedInclination, inclination);
        }

        [Theory]
        [InlineData(2475460.5, 174.71533036509314)]
        public void EarthLongitudeAscendingNodeJ2000Test(double jd, double expectedLongitudeAscendingNode)
        {
            double longitudeAscendingNode = AASElementsPlanetaryOrbit.EarthLongitudeAscendingNodeJ2000(jd);
            Assert.Equal(expectedLongitudeAscendingNode, longitudeAscendingNode);
        }

        [Theory]
        [InlineData(2475460.5, 103.14861781038238)]
        public void EarthLongitudePerihelionJ2000Test(double jd, double expectedLongitudePerihelion)
        {
            double longitudePerihelion = AASElementsPlanetaryOrbit.EarthLongitudePerihelionJ2000(jd);
            Assert.Equal(expectedLongitudePerihelion, longitudePerihelion);
        }

        #endregion

        #region Mars

        [Theory]
        [InlineData(2475460.5, 288.85521063023043)]
        public void MarsMeanLongitudeTest(double jd, double expectedMeanLongitude)
        {
            double meanLongitude = AASElementsPlanetaryOrbit.MarsMeanLongitude(jd);
            Assert.Equal(expectedMeanLongitude, meanLongitude);
        }

        [Fact]
        public void MarsSemimajorAxisTest()
        {
            double semimajorAxis = AASElementsPlanetaryOrbit.MarsSemimajorAxis();
            Assert.Equal(1.523679342, semimajorAxis);
        }

        [Theory]
        [InlineData(2475460.5, 0.093459861647082934)]
        public void MarsEccentricityTest(double jd, double expectedEccentricity)
        {
            double eccentricity = AASElementsPlanetaryOrbit.MarsEccentricity(jd);
            Assert.Equal(expectedEccentricity, eccentricity);
        }

        [Theory]
        [InlineData(2475460.5, 1.8493378858910792)]
        public void MarsInclinationTest(double jd, double expectedInclination)
        {
            double inclination = AASElementsPlanetaryOrbit.MarsInclination(jd);
            Assert.Equal(expectedInclination, inclination);
        }

        [Theory]
        [InlineData(2475460.5, 50.093646088395161)]
        public void MarsLongitudeAscendingNodeTest(double jd, double expectedLongitudeAscendingNode)
        {
            double longitudeAscendingNode = AASElementsPlanetaryOrbit.MarsLongitudeAscendingNode(jd);
            Assert.Equal(expectedLongitudeAscendingNode, longitudeAscendingNode);
        }

        [Theory]
        [InlineData(2475460.5, 337.26575419679193)]
        public void MarsLongitudePerihelionTest(double jd, double expectedLongitudePerihelion)
        {
            double longitudePerihelion = AASElementsPlanetaryOrbit.MarsLongitudePerihelion(jd);
            Assert.Equal(expectedLongitudePerihelion, longitudePerihelion);
        }

        [Theory]
        [InlineData(2475460.5, 287.940270182522)]
        public void MarsMeanLongitudeJ2000Test(double jd, double expectedMeanLongitude)
        {
            double meanLongitude = AASElementsPlanetaryOrbit.MarsMeanLongitudeJ2000(jd);
            Assert.Equal(expectedMeanLongitude, meanLongitude);
        }

        [Theory]
        [InlineData(2475460.5, 1.8443814488446784)]
        public void MarsInclinationJ2000Test(double jd, double expectedInclination)
        {
            double inclination = AASElementsPlanetaryOrbit.MarsInclinationJ2000(jd);
            Assert.Equal(expectedInclination, inclination);
        }

        [Theory]
        [InlineData(2475460.5, 49.394644131850896)]
        public void MarsLongitudeAscendingNodeJ2000Test(double jd, double expectedLongitudeAscendingNode)
        {
            double longitudeAscendingNode = AASElementsPlanetaryOrbit.MarsLongitudeAscendingNodeJ2000(jd);
            Assert.Equal(expectedLongitudeAscendingNode, longitudeAscendingNode);
        }

        [Theory]
        [InlineData(2475460.5, 336.35081368388904)]
        public void MarsLongitudePerihelionJ2000Test(double jd, double expectedLongitudePerihelion)
        {
            double longitudePerihelion = AASElementsPlanetaryOrbit.MarsLongitudePerihelionJ2000(jd);
            Assert.Equal(expectedLongitudePerihelion, longitudePerihelion);
        }

        #endregion

        #region Jupiter

        [Theory]
        [InlineData(2475460.5, 222.43372318346746)]
        public void JupiterMeanLongitudeTest(double jd, double expectedMeanLongitude)
        {
            double meanLongitude = AASElementsPlanetaryOrbit.JupiterMeanLongitude(jd);
            Assert.Equal(expectedMeanLongitude, meanLongitude);
        }

        [Theory]
        [InlineData(2475460.5, 5.2026033342576365)]
        public void JupiterSemimajorAxisTest(double jd, double expectedSemimajorAxis)
        {
            double semimajorAxis = AASElementsPlanetaryOrbit.JupiterSemimajorAxis(jd);
            Assert.Equal(expectedSemimajorAxis, semimajorAxis);
        }

        [Theory]
        [InlineData(2475460.5, 0.048604602283270869)]
        public void JupiterEccentricityTest(double jd, double expectedEccentricity)
        {
            double eccentricity = AASElementsPlanetaryOrbit.JupiterEccentricity(jd);
            Assert.Equal(expectedEccentricity, eccentricity);
        }

        [Theory]
        [InlineData(2475460.5, 1.2996700501155443)]
        public void JupiterInclinationTest(double jd, double expectedInclination)
        {
            double inclination = AASElementsPlanetaryOrbit.JupiterInclination(jd);
            Assert.Equal(expectedInclination, inclination);
        }

        [Theory]
        [InlineData(2475460.5, 101.13308604574615)]
        public void JupiterLongitudeAscendingNodeTest(double jd, double expectedLongitudeAscendingNode)
        {
            double longitudeAscendingNode = AASElementsPlanetaryOrbit.JupiterLongitudeAscendingNode(jd);
            Assert.Equal(expectedLongitudeAscendingNode, longitudeAscendingNode);
        }

        [Theory]
        [InlineData(2475460.5, 15.38755380016924)]
        public void JupiterLongitudePerihelionTest(double jd, double expectedLongitudePerihelion)
        {
            double longitudePerihelion = AASElementsPlanetaryOrbit.JupiterLongitudePerihelion(jd);
            Assert.Equal(expectedLongitudePerihelion, longitudePerihelion);
        }

        [Theory]
        [InlineData(2475460.5, 221.51880154777291)]
        public void JupiterMeanLongitudeJ2000Test(double jd, double expectedMeanLongitude)
        {
            double meanLongitude = AASElementsPlanetaryOrbit.JupiterMeanLongitudeJ2000(jd);
            Assert.Equal(expectedMeanLongitude, meanLongitude);
        }

        [Theory]
        [InlineData(2475460.5, 1.3019797731584122)]
        public void JupiterInclinationJ2000Test(double jd, double expectedInclination)
        {
            double inclination = AASElementsPlanetaryOrbit.JupiterInclinationJ2000(jd);
            Assert.Equal(expectedInclination, inclination);
        }

        [Theory]
        [InlineData(2475460.5, 100.58050698616512)]
        public void JupiterLongitudeAscendingNodeJ2000Test(double jd, double expectedLongitudeAscendingNode)
        {
            double longitudeAscendingNode = AASElementsPlanetaryOrbit.JupiterLongitudeAscendingNodeJ2000(jd);
            Assert.Equal(expectedLongitudeAscendingNode, longitudeAscendingNode);
        }

        [Theory]
        [InlineData(2475460.5, 14.472632098997503)]
        public void JupiterLongitudePerihelionJ2000Test(double jd, double expectedLongitudePerihelion)
        {
            double longitudePerihelion = AASElementsPlanetaryOrbit.JupiterLongitudePerihelionJ2000(jd);
            Assert.Equal(expectedLongitudePerihelion, longitudePerihelion);
        }

        #endregion

        #region Saturn

        [Theory]
        [InlineData(2475460.5, 131.19687149232152)]
        public void SaturnMeanLongitudeTest(double jd, double expectedMeanLongitude)
        {
            double meanLongitude = AASElementsPlanetaryOrbit.SaturnMeanLongitude(jd);
            Assert.Equal(expectedMeanLongitude, meanLongitude);
        }

        [Theory]
        [InlineData(2475460.5, 9.55490779316036)]
        public void SaturnSemimajorAxisTest(double jd, double expectedSemimajorAxis)
        {
            double semimajorAxis = AASElementsPlanetaryOrbit.SaturnSemimajorAxis(jd);
            Assert.Equal(expectedSemimajorAxis, semimajorAxis);
        }

        [Theory]
        [InlineData(2475460.5, 0.055322189071490058)]
        public void SaturnEccentricityTest(double jd, double expectedEccentricity)
        {
            double eccentricity = AASElementsPlanetaryOrbit.SaturnEccentricity(jd);
            Assert.Equal(expectedEccentricity, eccentricity);
        }

        [Theory]
        [InlineData(2475460.5, 2.4864261577864846)]
        public void SaturnInclinationTest(double jd, double expectedInclination)
        {
            double inclination = AASElementsPlanetaryOrbit.SaturnInclination(jd);
            Assert.Equal(expectedInclination, inclination);
        }

        [Theory]
        [InlineData(2475460.5, 114.23974169525638)]
        public void SaturnLongitudeAscendingNodeTest(double jd, double expectedLongitudeAscendingNode)
        {
            double longitudeAscendingNode = AASElementsPlanetaryOrbit.SaturnLongitudeAscendingNode(jd);
            Assert.Equal(expectedLongitudeAscendingNode, longitudeAscendingNode);
        }

        [Theory]
        [InlineData(2475460.5, 94.3434108239942)]
        public void SaturnLongitudePerihelionTest(double jd, double expectedLongitudePerihelion)
        {
            double longitudePerihelion = AASElementsPlanetaryOrbit.SaturnLongitudePerihelion(jd);
            Assert.Equal(expectedLongitudePerihelion, longitudePerihelion);
        }

        [Theory]
        [InlineData(2475460.5, 130.28188040127486)]
        public void SaturnMeanLongitudeJ2000Test(double jd, double expectedMeanLongitude)
        {
            double meanLongitude = AASElementsPlanetaryOrbit.SaturnMeanLongitudeJ2000(jd);
            Assert.Equal(expectedMeanLongitude, meanLongitude);
        }

        [Theory]
        [InlineData(2475460.5, 2.4905285535162958)]
        public void SaturnInclinationJ2000Test(double jd, double expectedInclination)
        {
            double inclination = AASElementsPlanetaryOrbit.SaturnInclinationJ2000(jd);
            Assert.Equal(expectedInclination, inclination);
        }

        [Theory]
        [InlineData(2475460.5, 113.49736281634368)]
        public void SaturnLongitudeAscendingNodeJ2000Test(double jd, double expectedLongitudeAscendingNode)
        {
            double longitudeAscendingNode = AASElementsPlanetaryOrbit.SaturnLongitudeAscendingNodeJ2000(jd);
            Assert.Equal(expectedLongitudeAscendingNode, longitudeAscendingNode);
        }

        [Theory]
        [InlineData(2475460.5, 93.42841973723489)]
        public void SaturnLongitudePerihelionJ2000Test(double jd, double expectedLongitudePerihelion)
        {
            double longitudePerihelion = AASElementsPlanetaryOrbit.SaturnLongitudePerihelionJ2000(jd);
            Assert.Equal(expectedLongitudePerihelion, longitudePerihelion);
        }

        #endregion

        #region Uranus

        [Theory]
        [InlineData(2475460.5, 235.51752636201309)]
        public void UranusMeanLongitudeTest(double jd, double expectedMeanLongitude)
        {
            double meanLongitude = AASElementsPlanetaryOrbit.UranusMeanLongitude(jd);
            Assert.Equal(expectedMeanLongitude, meanLongitude);
        }

        [Theory]
        [InlineData(2475460.5, 19.218446038062684)]
        public void UranusSemimajorAxisTest(double jd, double expectedSemimajorAxis)
        {
            double semimajorAxis = AASElementsPlanetaryOrbit.UranusSemimajorAxis(jd);
            Assert.Equal(expectedSemimajorAxis, semimajorAxis);
        }

        [Theory]
        [InlineData(2475460.5, 0.0463633832368974)]
        public void UranusEccentricityTest(double jd, double expectedEccentricity)
        {
            double eccentricity = AASElementsPlanetaryOrbit.UranusEccentricity(jd);
            Assert.Equal(expectedEccentricity, eccentricity);
        }

        [Theory]
        [InlineData(2475460.5, 0.77372010149615222)]
        public void UranusInclinationTest(double jd, double expectedInclination)
        {
            double inclination = AASElementsPlanetaryOrbit.UranusInclination(jd);
            Assert.Equal(expectedInclination, inclination);
        }

        [Theory]
        [InlineData(2475460.5, 74.3477556696024)]
        public void UranusLongitudeAscendingNodeTest(double jd, double expectedLongitudeAscendingNode)
        {
            double longitudeAscendingNode = AASElementsPlanetaryOrbit.UranusLongitudeAscendingNode(jd);
            Assert.Equal(expectedLongitudeAscendingNode, longitudeAscendingNode);
        }

        [Theory]
        [InlineData(2475460.5, 173.97862032035721)]
        public void UranusLongitudePerihelionTest(double jd, double expectedLongitudePerihelion)
        {
            double longitudePerihelion = AASElementsPlanetaryOrbit.UranusLongitudePerihelion(jd);
            Assert.Equal(expectedLongitudePerihelion, longitudePerihelion);
        }

        [Theory]
        [InlineData(2475460.5, 234.60264146274073)]
        public void UranusMeanLongitudeJ2000Test(double jd, double expectedMeanLongitude)
        {
            double meanLongitude = AASElementsPlanetaryOrbit.UranusMeanLongitudeJ2000(jd);
            Assert.Equal(expectedMeanLongitude, meanLongitude);
        }

        [Theory]
        [InlineData(2475460.5, 0.77209396803832275)]
        public void UranusInclinationJ2000Test(double jd, double expectedInclination)
        {
            double inclination = AASElementsPlanetaryOrbit.UranusInclinationJ2000(jd);
            Assert.Equal(expectedInclination, inclination);
        }

        [Theory]
        [InlineData(2475460.5, 74.054677563959331)]
        public void UranusLongitudeAscendingNodeJ2000Test(double jd, double expectedLongitudeAscendingNode)
        {
            double longitudeAscendingNode = AASElementsPlanetaryOrbit.UranusLongitudeAscendingNodeJ2000(jd);
            Assert.Equal(expectedLongitudeAscendingNode, longitudeAscendingNode);
        }

        [Theory]
        [InlineData(2475460.5, 173.06373542108486)]
        public void UranusLongitudePerihelionJ2000Test(double jd, double expectedLongitudePerihelion)
        {
            double longitudePerihelion = AASElementsPlanetaryOrbit.UranusLongitudePerihelionJ2000(jd);
            Assert.Equal(expectedLongitudePerihelion, longitudePerihelion);
        }

        #endregion

        #region Neptune

        [Theory]
        [InlineData(2475460.5, 88.3219467856718)]
        public void NeptuneMeanLongitudeTest(double jd, double expectedMeanLongitude)
        {
            double meanLongitude = AASElementsPlanetaryOrbit.NeptuneMeanLongitude(jd);
            Assert.Equal(expectedMeanLongitude, meanLongitude);
        }

        [Theory]
        [InlineData(2475460.5, 30.110386760407451)]
        public void NeptuneSemimajorAxisTest(double jd, double expectedSemimajorAxis)
        {
            double semimajorAxis = AASElementsPlanetaryOrbit.NeptuneSemimajorAxis(jd);
            Assert.Equal(expectedSemimajorAxis, semimajorAxis);
        }

        [Theory]
        [InlineData(2475460.5, 0.0094597002176274279)]
        public void NeptuneEccentricityTest(double jd, double expectedEccentricity)
        {
            double eccentricity = AASElementsPlanetaryOrbit.NeptuneEccentricity(jd);
            Assert.Equal(expectedEccentricity, eccentricity);
        }

        [Theory]
        [InlineData(2475460.5, 1.7638552355323855)]
        public void NeptuneInclinationTest(double jd, double expectedInclination)
        {
            double inclination = AASElementsPlanetaryOrbit.NeptuneInclination(jd);
            Assert.Equal(expectedInclination, inclination);
        }

        [Theory]
        [InlineData(2475460.5, 132.50585890846457)]
        public void NeptuneLongitudeAscendingNodeTest(double jd, double expectedLongitudeAscendingNode)
        {
            double longitudeAscendingNode = AASElementsPlanetaryOrbit.NeptuneLongitudeAscendingNode(jd);
            Assert.Equal(expectedLongitudeAscendingNode, longitudeAscendingNode);
        }

        [Theory]
        [InlineData(2475460.5, 49.054337422678927)]
        public void NeptuneLongitudePerihelionTest(double jd, double expectedLongitudePerihelion)
        {
            double longitudePerihelion = AASElementsPlanetaryOrbit.NeptuneLongitudePerihelion(jd);
            Assert.Equal(expectedLongitudePerihelion, longitudePerihelion);
        }

        [Theory]
        [InlineData(2475460.5, 87.407028589363563)]
        public void NeptuneMeanLongitudeJ2000Test(double jd, double expectedMeanLongitude)
        {
            double meanLongitude = AASElementsPlanetaryOrbit.NeptuneMeanLongitudeJ2000(jd);
            Assert.Equal(expectedMeanLongitude, meanLongitude);
        }

        [Theory]
        [InlineData(2475460.5, 1.7701008148777229)]
        public void NeptuneInclinationJ2000Test(double jd, double expectedInclination)
        {
            double inclination = AASElementsPlanetaryOrbit.NeptuneInclinationJ2000(jd);
            Assert.Equal(expectedInclination, inclination);
        }

        [Theory]
        [InlineData(2475460.5, 131.78001931232367)]
        public void NeptuneLongitudeAscendingNodeJ2000Test(double jd, double expectedLongitudeAscendingNode)
        {
            double longitudeAscendingNode = AASElementsPlanetaryOrbit.NeptuneLongitudeAscendingNodeJ2000(jd);
            Assert.Equal(expectedLongitudeAscendingNode, longitudeAscendingNode);
        }

        [Theory]
        [InlineData(2475460.5, 48.1394191566063)]
        public void NeptuneLongitudePerihelionJ2000Test(double jd, double expectedLongitudePerihelion)
        {
            double longitudePerihelion = AASElementsPlanetaryOrbit.NeptuneLongitudePerihelionJ2000(jd);
            Assert.Equal(expectedLongitudePerihelion, longitudePerihelion);
        }

        #endregion
    }
}