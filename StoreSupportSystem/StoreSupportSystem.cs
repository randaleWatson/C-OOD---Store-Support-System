using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSupportSystem
{
   public class StoreSupportSystem
   {
      SaleManager saleManager;
      Inventory inventory;

      public StoreSupportSystem(Inventory inventory)
      {
         saleManager = new SaleManager();
         this.inventory = inventory;
      }

      public void BuyItems(int upc, int purchaseQty)
      {
         try
         {
            Item item = inventory.FindItem(upc);
            saleManager.BuyItems(item, purchaseQty);
         }

         //TODO: Add a logger at some point
         catch (ItemNotFoundException)
         {
            //TODO: Add a way to catch logger
         }
      }
   }
}
