using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSupportSystem
{
   public class Item : IEqualityComparer<Item>
   {
      public string Name { get; private set; }
      public ItemSpecification Specification { get; private set; }

      public Item(string name, ItemSpecification specification)
      {
         if (String.IsNullOrEmpty(name) || specification == null)
         {
            throw new ArgumentNullException("Empty or null not allowed in constructor");
         }
         Name = name;
         Specification = specification;
      }

      bool IEqualityComparer<Item>.Equals(Item item1, Item item2)
      {
         return(item1.Specification.Equals(item2.Specification));
      }

      //TODO: Improve GetHashCodeFomrula
      int IEqualityComparer<Item>.GetHashCode(Item item)
      {
         return item.Specification.GetHashCode() + item.Name.GetHashCode();
      }
   }
}
