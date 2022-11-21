using Xunit;

namespace GildedRoseTests.ItemTests
{
    public class NormalItemTests : TestingBase
    {

        [Fact]
        public void ItemUpdateQuality()
        {
            var item = normalItemFake.Generate();
            var expectedQuality = item.Quality - 1;

            item.UpdateItem();

            Assert.Equal(expectedQuality, item.Quality);
        }

        [Fact]
        public void ItemUpdateSellIn()
        {
            var item = normalItemFake.Generate();
            var expectedSellin = item.SellIn - 1;

            item.UpdateItem();

            Assert.Equal(expectedSellin, item.SellIn);
        }

        [Fact]
        public void ItemUpdateQuality_PastSellin()
        {
            var item = normalItemFake.RuleFor(x => x.SellIn, fake => 0).Generate();
            var expectedQuality = item.Quality - 2;

            item.UpdateItem();

            Assert.Equal(expectedQuality, item.Quality);
        }

        [Fact]
        public void ItemUpdateQuality_ZeroIsFloor()
        {
            var item = normalItemFake.RuleFor(x => x.Quality, fake => 0).Generate();

            item.UpdateItem();

            Assert.Equal(0, item.Quality);
        }

    }
}
