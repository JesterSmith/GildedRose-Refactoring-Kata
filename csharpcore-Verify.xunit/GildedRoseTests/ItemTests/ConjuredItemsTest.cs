using Xunit;

namespace GildedRoseTests.ItemTests
{
    public class ConjuredItemsTest : TestingBase
    {
        [Fact]
        public void ItemUpdateQuality()
        {
            var item = conjuredFake.Generate();

            var expectedQuality = item.Quality - 2;

            item.UpdateItem();

            Assert.Equal(expectedQuality, item.Quality);
        }

        [Fact]
        public void ItemUpdateSellIn()
        {
            var item = conjuredFake.Generate();
            var expectedSellin = item.SellIn - 1;

            item.UpdateItem();

            Assert.Equal(expectedSellin, item.SellIn);
        }

        [Fact]
        public void ItemUpdateQuality_PastSellin()
        {
            var item = conjuredFake.RuleFor(x => x.SellIn, 0).Generate();
            var expectedQuality = item.Quality - 4;

            item.UpdateItem();

            Assert.Equal(expectedQuality, item.Quality);
        }

        [Fact]
        public void ItemUpdateQuality_ZeroIsFloor()
        {
            var item = conjuredFake
                .RuleFor(x => x.SellIn, 2)
                .RuleFor(x => x.Quality, 0)
                .Generate();
            var expectedQuality = 0;

            item.UpdateItem();

            Assert.Equal(expectedQuality, item.Quality);
        }

    }
}
