using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSupportSystem
{
   public class ItemSpecification : IEqualityComparer<ItemSpecification>
   {
      private int upc;
      private ItemInfo info;

      public ItemSpecification(int upc, ItemInfo info)
      {
         Upc = upc;
         this.info = info;
      }

      public int Upc{
         get{
            return upc;
         }
         protected set
         {
            //TODO add a check for dupicate UPC code
            if (value >= 0)
            {
               upc = value;
            }
            else
            {
               throw new ArgumentOutOfRangeException("Upc cannot be negative");
            }
         }
      }

      public ItemInfo Info
      {
         get
         {
            return info;
         }
         private set
         {
            if (value != null)
            {
               info = value;
            }
            else
            {
               throw new ArgumentNullException("ItemInfo cannot be null");
            }
         }
      }

      bool IEqualityComparer<ItemSpecification>.Equals(ItemSpecification spec1, ItemSpecification spec2)
      {
         // Check for equlaity with UPC number
         if (spec1.upc.Equals(spec2.upc))
         {
            // if UPC are the same ItemInfo level details
            if((spec1.info.Price == spec2.info.Price) && (spec1.info.Description == spec2.info.Description))
            {
               return true;
            }
         }
         return false;
      }

      int IEqualityComparer<ItemSpecification>.GetHashCode(ItemSpecification spec)
      {
         return spec.upc;
      }
   }
}
