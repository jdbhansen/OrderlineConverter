using System.Collections.Generic;

namespace OrderlineConverter.Converter.Interfaces
{
    public interface IItemMapper
    {
        bool AddItem(IItem item);
        List<IItem> GetItems();
        void ClearItems();
    }
}
