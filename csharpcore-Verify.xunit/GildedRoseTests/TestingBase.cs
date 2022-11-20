using AutoBogus;
using Bogus;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class TestingBase
    {
        public Faker<Item> itemFake;
        public Faker<Item> legendaryFake;
        public Faker<Item> conjuredFake;


        public TestingBase()
        {
            itemFake = new AutoFaker<Item>()
                .RuleFor(x => x.Quality, fake => fake.Random.Int(10, 20))
                .RuleFor(x => x.SellIn, fake => fake.Random.Int(10, 20));

            legendaryFake = new AutoFaker<Item>()
                .RuleFor(x => x.Name, fake => "Sulfuras, Hand of Ragnaros")
                .RuleFor(x => x.Quality, fake => 80);

            conjuredFake = new Faker<Item>()
                .RuleFor(x => x.Name, fake => "Conjured Mana Cake")
                .RuleFor(x => x.SellIn, fake => 10)
                .RuleFor(x => x.Quality, fake => 20);
        }
    }
}
