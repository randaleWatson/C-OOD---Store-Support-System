using System;

namespace StoreSupportSystem
{
   public class SaleManager
   {
      Sale sale;

      public SaleManager()
      {
         sale = GetCurrentSale();
      }

      public void BuyItems(Item item, int purchaseQty)
      {
         sale.BuyItems(item, purchaseQty);
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