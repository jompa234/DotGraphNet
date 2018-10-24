using Xunit;

namespace GraphNet.UTests
{
    public class NodeUTests
    {
        [Fact]
        public void GivenNode_ToDotString_ShouldReturnCorrectAttributeDotString()
        {
            var node = new Node("");
            var actual = node.ToDotString();
            Assert.Equal("[]",actual);
        }
    }
}
