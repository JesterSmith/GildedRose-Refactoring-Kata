using GildedRoseKata;
using Xunit;

namespace GildedRoseTests.ItemTests
{
    //new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
    //            new Item { Name = "Conjured Health Potion", SellIn = 5, Quality = 20 }

    public class ConjuredItemsTest : TestingBase
    {
        private GildedRose _target;

        [Fact]
        public void ItemUpdateQuality()
        {
            var list = conjuredFake.Generate(1);
            var expectedQuality = list[0].Quality - 2;

            _target = new GildedRose(list);
            _target.UpdateQuality();

            Assert.Equal(expectedQuality, list[0].Quality);
        }

        [Fact]
        public void ItemUpdateSellIn()
        {
            var list = conjuredFake.Generate(1);
            var expectedSellin = list[0].SellIn - 1;

            _target = new GildedRose(list);
            _target.UpdateQuality();

            Assert.Equal(expectedSellin, list[0].SellIn);
        }

        [Fact]
        public void ItemUpdateQuality_PastSellin()
        {
            var list = conjuredFake.RuleFor(x => x.SellIn, 0).Generate(1);
            var expectedQuality = list[0].Quality - 4;

            _target = new GildedRose(list);
            _target.UpdateQuality();

            Assert.Equal(expectedQuality, list[0].Quality);
        }

        [Fact]
        public void ItemUpdateQuality_ZeroIsFloor()
        {
            var list = conjuredFake
                .RuleFor(x => x.SellIn, 2)
                .RuleFor(x => x.Quality, 1)
                .Generate(1);
            var expectedQuality = 0;

            _target = new GildedRose(list);
            _target.UpdateQuality();

            Assert.Equal(expectedQuality, list[0].Quality);
        }

    }
}
