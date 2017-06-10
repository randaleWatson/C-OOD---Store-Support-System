using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSupportSystem
{
   public class Item
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
   }
}
