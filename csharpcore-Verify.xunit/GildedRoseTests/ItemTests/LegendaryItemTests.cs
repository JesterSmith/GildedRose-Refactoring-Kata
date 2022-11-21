using Xunit;

namespace GildedRoseTests.ItemTests
{
    public class LegendaryItemTests : TestingBase
    {

        [Fact]
        public void ItemUpdateQuality()
        {
            var item = legendaryFake.Generate();
            var expectedQuality = item.Quality;

            item.UpdateItem();

            Assert.Equal(expectedQuality, item.Quality);
        }

        [Fact]
        public void ItemUpdateSellIn()
        {
            var item = legendaryFake.Generate();
            var expectedSellin = item.SellIn;

            item.UpdateItem();

            Assert.Equal(expectedSellin, item.SellIn);
        }

        [Fact]
        public void ItemUpdateQuality_PastSellin()
        {
            var item = legendaryFake.RuleFor(x => x.SellIn, fake => 0).Generate();
            var expectedQuality = item.Quality;

            item.UpdateItem();

            Assert.Equal(expectedQuality, item.Quality);
        }

    }
}
