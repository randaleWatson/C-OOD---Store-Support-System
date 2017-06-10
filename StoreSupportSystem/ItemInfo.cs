using System;

namespace StoreSupportSystem
{
   public class ItemInfo
   {
      string description;
      int stockQty;
      decimal price;

      public ItemInfo(string description, decimal price, int stockQty = 0)
      {
         this.description = description;
         this.price = price;
         this.stockQty = stockQty;
      }

      public string Description
      {
         get
         {
            return description;
         }
         set
         {
            if (!String.IsNullOrEmpty(value))
            {
               description = value;
            }
            else
            {
               throw new ArgumentNullException("Description cannot be set to empty!");
            }
         }
      }

      public decimal Price
      {
         get
         {
            return price;
         }
         set
         {
            if (value > 0.0M)
            {
               price = value;
            }
            else
            {
               throw new ArgumentOutOfRangeException("Price cannot be equal to or less then zero");
            }
         }
      }

      public int StockQty
      {
         get
         {
            return stockQty;
         }
         set
         {
            if(value > 0)
            {
               stockQty = value;
            }
            else
            {
               throw new ArgumentOutOfRangeException("Stock quanity cannot be less then zero");
            }
         }
      }
   }
}
