namespace GildedRoseKata.Models.Helpers
{
    public interface IItemHelper
    {
        Item UpdateItem(Item item);
    }

    public class ItemHelper : Item, IItemHelper
    {
        public Item UpdateItem(Item item)
        {
            switch (item)
            {
                case AgedItem:
                    item = (item as AgedItem).UpdateItem();
                    break;

                case BackstagePass:
                    item = (item as BackstagePass).UpdateItem();
                    break;

                case ConjuredItem:
                    item = (item as ConjuredItem).UpdateItem();
                    break;

                case LegendaryItem:
                    item = (item as LegendaryItem).UpdateItem();
                    break;

                case NormalItem:
                    item = (item as NormalItem).UpdateItem();
                    break;
            }

            return item;
        }
    }

}
