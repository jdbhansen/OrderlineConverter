using System.Collections.Generic;

namespace OrderlineConverter.OrderlineConverter.Interfaces
{
    public interface IConvertStringToItems
    {
        List<IItem> ConvertToItemsWithCoords(string str, int[] coords);
        int GetOrderLineCount();
    }
}
