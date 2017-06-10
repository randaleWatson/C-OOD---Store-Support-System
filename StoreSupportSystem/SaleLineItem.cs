using System;

namespace StoreSupportSystem
{
   public class SaleLineItem
   {
      Item item;
      int quantity;
      decimal salePrice;
      SaleState saleState;

      public void BuyItems(Item item, int purchaseQty)
      {
         this.item = item;
         quantity = purchaseQty;
         salePrice = item.Specification.Info.Price;
      }
   }
}