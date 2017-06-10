using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSupportSystem
{
   class Inventory
   {
      Dictionary<int, Item> items;

      public Inventory()
      {
         items = new Dictionary<int, Item>();
      }

      public Inventory(Dictionary<int, Item> items)
      {
         this.items = items;
      }

      public Item FindItem(int upc)
      {
         Item item;
         if(items.TryGetValue(upc, out item))
         {
            return item;
         }
         else
         {
            throw new ItemNotFoundException($"UPC: {upc} not found!");
         }
      }
   }
}
