using AutoBogus;
using Bogus;
using GildedRoseKata.Models;
using System.Collections.Generic;

namespace GildedRoseTests
{
    public class TestingBase
    {
        public Faker<NormalItem> normalItemFake;
        public Faker<LegendaryItem> legendaryFake;
        public Faker<ConjuredItem> conjuredFake;
        public Faker<BackstagePass> backstagePassFake;
        public Faker<AgedItem> agedItemFake;
        public List<Item> itemsListFake;

        public TestingBase()
        {
            normalItemFake = new AutoFaker<NormalItem>()
                .RuleFor(x => x.Quality, fake => fake.Random.Int(10, 20))
                .RuleFor(x => x.SellIn, fake => fake.Random.Int(10, 20));

            legendaryFake = new AutoFaker<LegendaryItem>()
                .RuleFor(x => x.Name, fake => "Sulfuras, Hand of Ragnaros")
                .RuleFor(x => x.Quality, fake => 80);

            conjuredFake = new AutoFaker<ConjuredItem>()
                .RuleFor(x => x.Name, fake => "Conjured Mana Cake")
                .RuleFor(x => x.SellIn, fake => 10)
                .RuleFor(x => x.Quality, fake => 20);

            backstagePassFake = new AutoFaker<BackstagePass>();
            agedItemFake = new AutoFaker<AgedItem>();
        }
    }
}
