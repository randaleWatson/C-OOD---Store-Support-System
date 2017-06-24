using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSupportSystem
{
   public class Inventory
   {
      private Dictionary<int, Item> items;

      public Inventory()
      {
         items = new Dictionary<int, Item>();
      }

      public Inventory(params Item[] items) : this()
      {         
         addItems(items);
      }

      public void addItems(params Item[] items)
      {
         foreach (Item item in items)
         {
            if (!this.items.ContainsKey(item.Specification.Upc))
            {
               this.items.Add(item.Specification.Upc, item);
            }
            else
            {
               throw new InvalidOperationException("Cannot add duplicate item UPC to the inventory");
            }
         }
      }

      public Item FindItem(int upc)
      {
         Item item;
         items.TryGetValue(upc, out item);
         return item;
      }

      public int ItemCount
      {
         get
         {
            return items.Count;
         }
      }
   }
}
