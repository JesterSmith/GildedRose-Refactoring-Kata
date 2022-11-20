using GildedRoseKata;
using Xunit;

namespace GildedRoseTests.ItemTests
{
    public class NormalItemTests : TestingBase
    {
        private GildedRose _target;

        [Fact]
        public void ItemUpdateQuality()
        {
            var list = itemFake.Generate(1);
            var expectedQuality = list[0].Quality - 1;

            _target = new GildedRose(list);
            _target.UpdateQuality();

            Assert.Equal(expectedQuality, list[0].Quality);
        }

        [Fact]
        public void ItemUpdateSellIn()
        {
            var list = itemFake.Generate(1);
            var expectedSellin = list[0].SellIn - 1;

            _target = new GildedRose(list);
            _target.UpdateQuality();

            Assert.Equal(expectedSellin, list[0].SellIn);
        }

        [Fact]
        public void ItemUpdateQuality_PastSellin()
        {
            var list = itemFake.RuleFor(x => x.SellIn, fake => 0).Generate(1);
            var expectedQuality = list[0].Quality - 2;

            _target = new GildedRose(list);
            _target.UpdateQuality();

            Assert.Equal(expectedQuality, list[0].Quality);
        }

        [Fact]
        public void ItemUpdateQuality_ZeroIsFloor()
        {
            var list = itemFake.RuleFor(x => x.Quality, fake => 0).Generate(1);

            _target = new GildedRose(list);
            _target.UpdateQuality();

            Assert.Equal(0, list[0].Quality);
        }

    }
}
