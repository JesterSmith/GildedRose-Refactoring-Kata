namespace GildedRoseKata.Models
{
    public class ConjuredItem : Item
    {
        public ConjuredItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public Item UpdateItem()
        {
            SellIn -= 1;

            if (Quality > 0)
            {
                Quality -= 1;
                if (Quality > 0)
                {
                    Quality -= 1;
                }
            }

            if (SellIn < 0)
            {
                Quality -= 1;
                if (Quality > 0)
                {
                    Quality -= 1;
                }
            }

            return this;
        }
    }
}
