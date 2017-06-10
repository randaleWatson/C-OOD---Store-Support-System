using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSupportSystem
{
   public class ItemSpecification
   {
      int upc;
      ItemInfo info;

      public ItemSpecification(int upc, ItemInfo info)
      {
         this.upc = upc;
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
               throw new IndexOutOfRangeException("Upc cannot be negative");
            }
         }
      }

      public ItemInfo Info
      {
         get
         {
            return info;
         }
         protected set
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
   }
}
