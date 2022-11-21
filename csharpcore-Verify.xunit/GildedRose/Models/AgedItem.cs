namespace GildedRoseKata.Models
{
    public class AgedItem : Item
    {
        public AgedItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public Item UpdateItem()
        {
            SellIn -= 1;
            Quality += Quality < 49 && SellIn < 0 ?
                2 :
                Quality < 50 ? 1 : 0;

            return this;
        }
    }
}
