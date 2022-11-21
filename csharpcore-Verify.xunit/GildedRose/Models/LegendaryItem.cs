namespace GildedRoseKata.Models
{
    public class LegendaryItem : Item
    {
        public LegendaryItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public Item UpdateItem()
        {
            return this;
        }
    }
}
