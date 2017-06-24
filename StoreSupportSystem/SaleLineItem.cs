using System;

namespace StoreSupportSystem
{
   public class SaleLineItem
   {
      private Item item;
      private int quantity;
      private decimal salePrice;

      public void BuyItems(Item item, int purchaseQty)
      {
         Item = item;
         Quantity = purchaseQty;
         SalePrice = item.Specification.Info.Price;
      }

      public Item Item
      {
         get
         {
            return item;
         }
         private set
         {
            item = value;
         }
      }
      public int Quantity
      {
         get
         {
            return quantity;
         }
         private set
         {
            if (value > 0)
            {
               quantity = value;
            }
            else
            {
               throw new ArgumentOutOfRangeException("Quantity cannot be less than or equal to zero");
            }
         }
      }
      public decimal SalePrice
      {
         get
         {
            return salePrice;
         }
         private set
         {
            if (value >= 0)
            {
               salePrice = value;
            }
            else
            {
               throw new ArgumentOutOfRangeException("Price cannot be less than zero");
            }
         }
      }
   }
}