namespace GildedRoseKata.Models
{
    public class NormalItem : Item
    {
        public NormalItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public Item UpdateItem()
        {
            SellIn -= 1;

            Quality -= SellIn < 0 && Quality > 1 ? 2
                : Quality > 0 ? 1 : 0;

            return this;
        }
    }
}
