using AutoBogus;
using Bogus;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class TestingBase
    {
        public Faker<Item> itemFake;


        public TestingBase()
        {
            itemFake = new AutoFaker<Item>()
                  .RuleFor(x => x.Quality, fake => fake.Random.Int(10, 20))
                  .RuleFor(x => x.SellIn, fake => fake.Random.Int(10, 20));
        }
    }
}
