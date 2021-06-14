using System.Collections.Generic;

namespace OrderlineConverter.Converter.Interfaces
{
    public interface IConvertStringToItems
    {
        List<IItem> ConvertToItemsWithCoords(string str, int[] coords);
        int GetOrderLineCount();
    }
}
