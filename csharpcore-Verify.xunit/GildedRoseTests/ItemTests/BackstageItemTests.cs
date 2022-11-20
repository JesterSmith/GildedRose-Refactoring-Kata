using GildedRoseKata;
using Xunit;

namespace GildedRoseTests.ItemTests
{
    public class BackstageItemTests : TestingBase
    {
        private GildedRose _target;

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
            var list = itemFake
                .RuleFor(x => x.Name, fake => "Aged Brie")
                .RuleFor(x => x.Quality, fake => quality)
                .RuleFor(x => x.SellIn, fake => sellIn)
                .Generate(1);

            //Backstage passes to a TAFKAL80ETC concert

            _target = new GildedRose(list);
            _target.UpdateQuality();

            Assert.Equal(expected, list[0].Quality);
        }

        [Theory]
        //regular increase
        [InlineData(10, 20, 22)]
        [InlineData(5, 30, 33)]
        //50 is quality ceiling
        [InlineData(5, 48, 50)]
        //past sell by
        [InlineData(0, 50, 0)]
        public void ItemUpdateQuality_ConcertTickets(int sellIn, int quality, int expected)
        {
            var list = itemFake
                .RuleFor(x => x.Name, fake => "Backstage passes to a TAFKAL80ETC concert")
                .RuleFor(x => x.Quality, fake => quality)
                .RuleFor(x => x.SellIn, fake => sellIn)
                .Generate(1);

            //Backstage passes to a TAFKAL80ETC concert

            _target = new GildedRose(list);
            _target.UpdateQuality();

            Assert.Equal(expected, list[0].Quality);
        }

        [Fact]
        public void ItemUpdateSellIn()
        {
            var list = itemFake
                .RuleFor(x => x.Name, fake => "Aged Brie")
                .RuleFor(x => x.Quality, fake => 10)
                .RuleFor(x => x.SellIn, fake => 10)
                .Generate(1);
            var expectedSellin = list[0].SellIn - 1;

            _target = new GildedRose(list);
            _target.UpdateQuality();

            Assert.Equal(expectedSellin, list[0].SellIn);
        }

    }
}
