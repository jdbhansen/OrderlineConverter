using OrderlineConverter.OrderlineConverter.Interfaces;
using System;
using System.Collections.Generic;

namespace OrderlineConverter.OrderlineConverter.Implementations
{
    public class StringToItemsConverter : IConvertStringToItems
    {
        private readonly int[] idRange;
        private readonly int maxQty;
        private int orderLineCounter = 0;
        private static readonly IItemMapper ItemMapper = new ItemMapper();

        public StringToItemsConverter(int[] idRange, int maxQty)
        {
            this.idRange = idRange;
            this.maxQty = maxQty;
        }

        public int GetOrderLineCount()
        {
            return orderLineCounter;
        }

        public List<IItem> ConvertToItemsWithCoords(string str, int[] coords)
        {
            if (IsInputValid(str) && IsCoordsValid(coords))
            {
                string[] strLines = str.Split(Environment.NewLine.ToCharArray());
                return ConvertFromStringLines(strLines, coords);
            }
            return null;
        }

        private List<IItem> ConvertFromStringLines(string[] strLines, int[] coords)
        {
            ItemMapper.ClearItems();
            orderLineCounter = 0;
            for (int i = 0; i < strLines.Length; i++)
            {
                string[] strTabs = strLines[i].Split('\t');
                if (strTabs.Length >= coords.Length && IsCoordsOutOfBounds(strTabs, coords) == false)
                {
                    if (ItemMapper.AddItem(CreateItem(strTabs, coords)))
                    {
                        orderLineCounter++;
                    }
                }
            }
            return ItemMapper.GetItems();
        }

        private IItem CreateItem(string[] strTabs, int[] coords)
        {
            string idStr = strTabs[coords[0]];
            string qtyStr = strTabs[coords[1]];
            string name = strTabs[coords[2]];
            if (IsIdAndQtyInts(idStr, qtyStr))
            {
                int id = int.Parse(idStr);
                int qty = int.Parse(RemoveDotOrComma(qtyStr));
                if (id > idRange[0] && id < idRange[1] && qty <= maxQty)
                {
                    return new Item(id, qty, name);
                }
            }
            return null;
        }

        private bool IsIdAndQtyInts(string idStr, string qtyStr)
        {
            if (IsStringAnInt(idStr) && DoesStringContainDotOrComma(qtyStr))
            {
                string qtyWithoutCommaOrDot = RemoveDotOrComma(qtyStr);
                if (IsStringAnInt(qtyWithoutCommaOrDot))
                {
                    return true;
                }
            }
            return false;
        }

        private string RemoveDotOrComma(string str)
        {
            if (DoesStringContainDot(str))
            {
                return str.Substring(0, str.IndexOf("."));
            }
            if (DoesStringContainComma(str))
            {
                return str.Substring(0, str.IndexOf(","));
            }
            return "does not contain dot or comma";
        }

        private bool DoesStringContainDotOrComma(string str)
        {
            return DoesStringContainComma(str) || DoesStringContainDot(str);
        }

        private bool DoesStringContainDot(string str)
        {
            return str.Contains(".");
        }

        private bool DoesStringContainComma(string str)
        {
            return str.Contains(",");
        }

        public static bool IsStringAnInt(string str)
        {
            if (str != null && str.Length != 0)
            {
                try
                {
                    _ = int.Parse(str);
                    return true;
                }
                catch (FormatException e)
                {
                    _ = e;
                    return false;
                }
            }
            return false;
        }

        private bool IsInputValid(string str)
        {
            return str != null && str.Length > 10;
        }

        private bool IsCoordsValid(int[] coords)
        {
            return coords != null && coords.Length == 3 && coords[0] != coords[1];
        }

        private bool IsCoordsOutOfBounds(string[] strTabs, int[] coords)
        {
            for (int i = 0; i < coords.Length; i++)
            {
                try
                {
                    string result = strTabs[coords[i]];
                }
                catch (IndexOutOfRangeException e)
                {
                    _ = e;
                    return false;
                }
            }
            return true;
        }
    }
}
