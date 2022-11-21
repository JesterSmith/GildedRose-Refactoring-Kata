using GildedRoseKata.Models;
using GildedRoseKata.Models.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            //Add Logging

            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new NormalItem("+5 Dexterity Vest", 10, 20),
                new AgedItem("Aged Brie", 2, 0),
                new NormalItem("Elixir of the Mongoose", 5, 7),
                new LegendaryItem("Sulfuras, Hand of Ragnaros", 0, 80),
                new LegendaryItem("Sulfuras, Hand of Ragnaros", -1, 80),
                new BackstagePass(
                    "Backstage passes to a TAFKAL80ETC concert",
                    15,
                    20
                ),
                new BackstagePass(
                    "Backstage passes to a TAFKAL80ETC concert",
                    10,
                    49
                ),
                new BackstagePass(
                    "Backstage passes to a TAFKAL80ETC concert",
                    5,
                    49
                ),
                new ConjuredItem("Conjured Mana Cake", 3, 6),
                new ConjuredItem("Conjured Health Potion", 5, 20)
            };

            var itemHelper = services.BuildServiceProvider()
                .GetService<IItemHelper>();

            var app = new GildedRose(itemHelper, Items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IItemHelper, ItemHelper>();
        }
    }
}
