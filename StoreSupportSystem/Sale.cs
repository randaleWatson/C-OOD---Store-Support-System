using System;
using System.Collections.Generic;

namespace StoreSupportSystem
{
   public class Sale
   {
      HashSet<SaleLineItem> saleLineItems;
      public void BuyItems(Item item, int purchaseQty)
      {
         SaleLineItem saleLineItem = create();
         saleLineItem.BuyItems(item, purchaseQty);
         saleLineItems.Add(saleLineItem);
      }

      SaleLineItem create()
      {
         return new SaleLineItem();
      }
   }
}