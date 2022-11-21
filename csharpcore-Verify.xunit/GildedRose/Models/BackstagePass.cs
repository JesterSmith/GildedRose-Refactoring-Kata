namespace GildedRoseKata.Models
{
    public class BackstagePass : Item
    {
        public BackstagePass(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public Item UpdateItem()
        {
            SellIn -= 1;
            if (SellIn < 0)
            {

                Quality -= Quality;
            }
            else if (Quality < 50)
            {
                Quality += 1;

                if (SellIn < 11)
                {
                    if (Quality < 50)
                    {
                        Quality += 1;
                    }
                }

                if (SellIn < 6)
                {
                    if (Quality < 50)
                    {
                        Quality += 1;
                    }
                }
            }
            return this;
        }
    }
}
