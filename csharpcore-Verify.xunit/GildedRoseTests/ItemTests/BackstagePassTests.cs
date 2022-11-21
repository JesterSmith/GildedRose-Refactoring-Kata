using Xunit;

namespace GildedRoseTests.ItemTests
{
    public class BackstagePassTests : TestingBase
    {
        [Theory]
        //regular increase
        [InlineData(10, 20, 22)]
        [InlineData(5, 30, 33)]
        //50 is quality ceiling
        [InlineData(5, 48, 50)]
        [InlineData(5, 49, 50)]
        [InlineData(10, 49, 50)]
        //past sell by
        [InlineData(0, 50, 0)]
        public void ItemUpdateQuality(int sellIn, int quality, int expected)
        {
            var item = backstagePassFake
                .RuleFor(x => x.Name, fake => "Backstage passes to a TAFKAL80ETC concert")
                .RuleFor(x => x.Quality, fake => quality)
                .RuleFor(x => x.SellIn, fake => sellIn)
                .Generate().UpdateItem();

            //Backstage passes to a TAFKAL80ETC concert

            Assert.Equal(expected, item.Quality);
        }
    }
}
