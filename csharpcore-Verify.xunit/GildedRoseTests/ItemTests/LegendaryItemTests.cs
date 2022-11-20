using GildedRoseKata;
using Xunit;

namespace GildedRoseTests.ItemTests
{
    public class LegendaryItemTests : TestingBase
    {
        private GildedRose _target;

        [Fact]
        public void ItemUpdateQuality()
        {
            var list = legendaryFake.Generate(1);
            var expectedQuality = list[0].Quality;

            _target = new GildedRose(list);
            _target.UpdateQuality();

            Assert.Equal(expectedQuality, list[0].Quality);
        }

        [Fact]
        public void ItemUpdateSellIn()
        {
            var list = legendaryFake.Generate(1);
            var expectedSellin = list[0].SellIn;

            _target = new GildedRose(list);
            _target.UpdateQuality();

            Assert.Equal(expectedSellin, list[0].SellIn);
        }

        [Fact]
        public void ItemUpdateQuality_PastSellin()
        {
            var list = legendaryFake.RuleFor(x => x.SellIn, fake => 0).Generate(1);
            var expectedQuality = list[0].Quality;

            _target = new GildedRose(list);
            _target.UpdateQuality();

            Assert.Equal(expectedQuality, list[0].Quality);
        }

    }
}
