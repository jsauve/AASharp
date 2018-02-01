using System.Collections.Generic;
using Xunit;

namespace AASharp.Tests
{
    public class NodesTest
    {
        public static IEnumerable<object[]> PassageThroAscendingNodeParameters()
        {
            yield return new object[] {
                new AASEllipticalObjectElements
                {
                    a = 17.9400782,
                    e = 0.96727426,
                    i = 0 /*Not required*/,
                    omega = 0 /*Not required*/,
                    w = 111.84644,
                    T = 2446470.5 + 0.45891,
                    JDEquinox = 0 /*Not required*/

                },
                2446378.6591217481,
                1.8045114285608728
            };
            yield return new object[]
            {
                new AASEllipticalObjectElements
                {
                    a = 0.723329820,
                    e = 0.00678195,
                    i = 0 /*Not required*/,
                    omega = 0 /*Not required*/,
                    w = 54.778485,
                    T = 2443873.704,
                    JDEquinox = 0 /*Not required*/
                },
                2443839.9082117379,
                0.72047845967358037
            };
        }

        [Theory]
        [MemberData(nameof(PassageThroAscendingNodeParameters))]
        public void PassageThroAscendingNodeTest(AASEllipticalObjectElements elements, double expectedT, double expectedRadius)
        {
            AASNodeObjectDetails nodedetails = AASNodes.PassageThroAscendingNode(ref elements);
            Assert.Equal(expectedT, nodedetails.t);
            Assert.Equal(expectedRadius, nodedetails.radius);
        }


        public static IEnumerable<object[]> PassageThroDescendingNodeParameters()
        {
            yield return new object[] {
                new AASEllipticalObjectElements
                {
                    a = 17.9400782,
                    e = 0.96727426,
                    i = 0 /*Not required*/,
                    omega = 0 /*Not required*/,
                    w = 111.84644,
                    T = 2446470.5 + 0.45891,
                    JDEquinox = 0 /*Not required*/

                },
                2446499.8693965622,
                0.84929430685891827
            };
        }

        [Theory]
        [MemberData(nameof(PassageThroDescendingNodeParameters))]
        public void PassageThroDescendingNodeTest(AASEllipticalObjectElements elements, double expectedT, double expectedRadius)
        {
            AASNodeObjectDetails nodedetails = AASNodes.PassageThroDescendingNode(ref elements);
            Assert.Equal(expectedT, nodedetails.t);
            Assert.Equal(expectedRadius, nodedetails.radius);
        }

        public static IEnumerable<object[]> ParabolicObjectElementsForPassageThroAscendingNodeParameters()
        {
            yield return new object[] 
            {
                new AASParabolicObjectElements
                {
                    q = 1.324502,
                    i = 0 /*Not required*/,
                    omega = 0 /*Not required*/,
                    w = 154.9103,
                    T = 2447758.5 + 0.2910,
                    JDEquinox = 0 /*Not required*/
                },
                2443404.1400882676,
                28.074878767280349
            };
        }

        [Theory]
        [MemberData(nameof(ParabolicObjectElementsForPassageThroAscendingNodeParameters))]
        public void PassageThroAscendingNodeWithParabolicObjectElementsTest(AASParabolicObjectElements elements, double expectedT, double expectedRadius)
        {
            AASNodeObjectDetails nodedetails = AASNodes.PassageThroAscendingNode(ref elements);
            Assert.Equal(expectedT, nodedetails.t);
            Assert.Equal(expectedRadius, nodedetails.radius);
        }


        public static IEnumerable<object[]> ParabolicObjectElementsForPassageThroDescendingNodeParameters()
        {
            yield return new object[]
            {
                new AASParabolicObjectElements
                {
                    q = 1.324502,
                    i = 0 /*Not required*/,
                    omega = 0 /*Not required*/,
                    w = 154.9103,
                    T = 2447758.5 + 0.2910,
                    JDEquinox = 0 /*Not required*/
                },
                2447787.1364349541,
                1.3900825921264546
            };
        }

        [Theory]
        [MemberData(nameof(ParabolicObjectElementsForPassageThroDescendingNodeParameters))]
        public void PassageThroDescendingNodeWithParabolicObjectElementsTest(AASParabolicObjectElements elements, double expectedT, double expectedRadius)
        {
            AASNodeObjectDetails nodedetails = AASNodes.PassageThroDescendingNode(ref elements);
            Assert.Equal(expectedT, nodedetails.t);
            Assert.Equal(expectedRadius, nodedetails.radius);
        }
    }
}