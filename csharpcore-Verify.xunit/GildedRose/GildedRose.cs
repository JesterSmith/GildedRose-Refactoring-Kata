using GildedRose.Models;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string BACKSTAGE_PASSED = "Backstage passes to a TAFKAL80ETC concert";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        private const string CONJURED_KEYWORD = "Conjured";

        IList<Item> Items;
        int ItemsLength;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            this.ItemsLength = Items.Count;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < ItemsLength; i++)
            {

                if (Items[i].Name != AGED_BRIE && Items[i].Name != BACKSTAGE_PASSED)
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != SULFURAS)
                        {
                            Items[i].Quality = Items[i].Quality - 1;

                            if (Items[i].Quality > 0 && Items[i].Name.Contains(CONJURED_KEYWORD, System.StringComparison.InvariantCultureIgnoreCase))
                            {
                                Items[i].Quality -= 1;
                            }
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == BACKSTAGE_PASSED)
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != SULFURAS)
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != AGED_BRIE)
                    {
                        if (Items[i].Name != BACKSTAGE_PASSED)
                        {
                            if (Items[i].Quality > 0 && Items[i].Name != SULFURAS)
                            {
                                Items[i].Quality = Items[i].Quality - 1;
                                if (Items[i].Quality > 0 && Items[i].Name.Contains(CONJURED_KEYWORD, System.StringComparison.InvariantCultureIgnoreCase))
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
