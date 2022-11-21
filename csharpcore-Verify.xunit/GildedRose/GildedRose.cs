using GildedRoseKata.Models;
using GildedRoseKata.Models.Helpers;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        readonly IItemHelper _itemHelper;
        readonly IList<Item> _items;
        readonly int _itemsLength;
        public GildedRose(IItemHelper itemHelper, IList<Item> Items)
        {
            _itemHelper = itemHelper;
            _items = Items;
            _itemsLength = Items.Count;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < _itemsLength; i++)
            {
                _items[i] = _itemHelper.UpdateItem(_items[i]);
            }
        }
    }
}
