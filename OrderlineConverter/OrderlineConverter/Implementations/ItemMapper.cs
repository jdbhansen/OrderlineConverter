using OrderlineConverter.OrderlineConverter.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OrderlineConverter.OrderlineConverter.Implementations
{
    public class ItemMapper : IItemMapper
    {
        private readonly Dictionary<int, IItem> ItemDictionary;

        public ItemMapper()
        {
            ItemDictionary = new Dictionary<int, IItem>();
        }
        public bool AddItem(IItem item)
        {
            if (item != null && item.Id != 0)
            {
                if (ItemDictionary.ContainsKey(item.Id))
                {
                    IItem mappedItem = ItemDictionary[item.Id];
                    _ = mappedItem.AddToQuantity(item.Quantity);
                    ItemDictionary[mappedItem.Id] = mappedItem;
                    return true;
                }
                else
                {
                    ItemDictionary.Add(item.Id, item);
                    return true;
                }
            }
            return false;
        }

        public void ClearItems()
        {
            ItemDictionary.Clear();
        }

        public List<IItem> GetItems()
        {
            if (ItemDictionary.Count == 0)
            {
                return null;
            }
            List<IItem> items = (from KeyValuePair<int, IItem>
                                 item in ItemDictionary
                                 select item.Value)
                                 .ToList();
            return items;
        }
    }
}
