namespace OrderlineConverter.Converter.Interfaces
{
    public interface IItem
    {
        int Id { get; }
        int Quantity { get; set; }
        string Name { get; set; }
        ItemType ItemType { get; }
        void SetItemType(ItemType itemType);
        int AddToQuantity(int qty);
    }
    public enum ItemType : int
    {
        Unknown,
        Accessory,
        Headset,
        Mouse,
        Mousepad,
        Keyboard
    }
}
