using CSharpDS;
using System.Collections.Generic;
using Xunit;

namespace CSharpDSTests
{
    public class LargestAssociationTests
    {
        LargestAssociation tSub;

        public LargestAssociationTests()
        {
            tSub = new LargestAssociation();
        }

        [Fact]
        public void GetLargestAssociationTest1()
        {
            //Given
            var list = new List<PairString>{new PairString("Item1", "Item2")
                                        ,new PairString("Item3", "Item4")
                                        ,new PairString("Item4", "Item5")};

            //When
            var expected = new List<string> { "Item3", "Item4", "Item5" };
            var actual = tSub.largestItemAssociation(list);

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLargestAssociationTest2()
        {
            //Given
            var list = new List<PairString>{new PairString("Item1", "Item2")
                                        ,new PairString("Item1", "Item2")
                                        ,new PairString("Item2", "Item1")
                                        ,new PairString("Item3", "Item4")
                                        ,new PairString("Item3", "Item4")
                                        ,new PairString("Item4", "Item5")};

            //When
            var expected = new List<string> { "Item3", "Item4", "Item5" };
            var actual = tSub.largestItemAssociation(list);

            //Then
            Assert.Equal(expected, actual);
        }
    }
}