using System.Linq;
using MonoGame.Extended.Collections;
using Xunit;

namespace MonoGame.Extended.Tests.Collections
{
    public class BagTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(50)]
        public void Deque_Remove_Front(int count)
        {
            var bag = new Bag<int>();

            for (var i = 0; i < count; i++)
            {
                bag.Add(i);
            }

            Assert.Equal(bag.Count, count);

            var numToRemove = bag.Count(i => i < 2 || i >= count - 2);
            var numRemoved = bag.RemoveAll(i => i < 2 || i >= count - 2);
            Assert.Equal(numToRemove, numRemoved);
            Assert.Equal(bag.Count, count - numToRemove);

            for (var i = 0; i < count; i++)
            {
                Assert.Equal(bag.Contains(i), !(i < 2 || i >= count - 2));
            }
        }
    }
}
