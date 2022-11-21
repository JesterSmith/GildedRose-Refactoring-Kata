using Xunit;

namespace GildedRoseTests.ItemTests
{
    public class AgedItemsTests : TestingBase
    {

        [Theory]
        //regular increase
        [InlineData(10, 20, 21)]
        [InlineData(5, 30, 31)]
        //50 is quality ceiling
        [InlineData(5, 50, 50)]
        //past sell by doubles
        [InlineData(-1, 30, 32)]
        //past sell by maintains max
        [InlineData(0, 50, 50)]
        [InlineData(-1, 50, 50)]
        public void ItemUpdateQuality_Brie(int sellIn, int quality, int expected)
        {
            var item = agedItemFake
                .RuleFor(x => x.Name, fake => "Aged Brie")
                .RuleFor(x => x.Quality, fake => quality)
                .RuleFor(x => x.SellIn, fake => sellIn)
                .Generate().UpdateItem();

            Assert.Equal(expected, item.Quality);
        }

        [Fact]
        public void ItemUpdateSellIn()
        {
            var item = agedItemFake
                .RuleFor(x => x.Name, fake => "Aged Brie")
                .RuleFor(x => x.Quality, fake => 10)
                .RuleFor(x => x.SellIn, fake => 10)
                .Generate().UpdateItem();

            Assert.Equal(9, item.SellIn);
        }

    }
}
