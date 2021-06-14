using OrderlineConverter.OrderlineConverter.Interfaces;
using System;

namespace OrderlineConverter.OrderlineConverter.Implementations
{
    public class Item : IItem
    {
        public int Id { get; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public ItemType ItemType { get; private set; }
        public Item(int id, int quantity, string name)
        {
            Id = id;
            Quantity = quantity;
            Name = name;
            UpdateItemType();
        }

        public int AddToQuantity(int qty)
        {
            Quantity += qty;
            return Quantity;
        }

        private void UpdateItemType()
        {
            if (Id > 60000 && Id < 61000)
            {
                ItemType = ItemType.Accessory;
                return;
            }
            if (Id > 61000 && Id < 62000)
            {
                ItemType = ItemType.Headset;
                return;
            }
            if (Id > 62000 && Id < 63000)
            {
                ItemType = ItemType.Mouse;
                return;
            }
            if (Id > 63000 && Id < 64000)
            {
                ItemType = ItemType.Mousepad;
                return;
            }
            if (Id > 64000 && Id < 65000)
            {
                ItemType = ItemType.Keyboard;
                return;
            }
            ItemType = ItemType.Unknown;
        }

        public void SetItemType(ItemType itemType)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string str = "" + Id + "\t" + Quantity + "\t" + ItemType;
            if (Name != null && Name.Length > 0)
            {
                str += ", " + Name;
            }
            str += "\n";
            return str;
        }
    }
}
