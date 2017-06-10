using System;

namespace StoreSupportSystem
{
   public class SaleManager
   {
      Sale sale;

      public void BuyItems(Item item, int purchaseQty)
      {
         GetCurrentSale().BuyItems(item, purchaseQty);
      }
      
      public Sale GetCurrentSale()
      {
         if (sale != null)
         {
            return sale;
         }
         else
         {
            return new Sale();
         }
      }
   }
}