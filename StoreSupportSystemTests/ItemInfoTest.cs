using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StoreSupportSystem
{
   [TestClass]
   public class ItemInfoTest
   {
      [TestMethod]
      [ExpectedException(typeof(ArgumentNullException), "An invalid ItemInfo was allowed - with default parameter values")]
      public void TestArgumentNullExceptionThrown_IfConstructedWithDefaultValues_ForParameterTypes()
      {
         ItemInfo info = new ItemInfo("", 0M, 0);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentOutOfRangeException), "An invalid ItemInfo was allowed - with negative quantity")]
      public void TestArgumentOutOfRangeExceptionThrown_IfConstructedWithNegativeQuantity()
      {
         ItemInfo info = new ItemInfo("A great item", 20M, -1);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentOutOfRangeException), "An invalid ItemInfo was allowed - with no price")]
      public void TestArgumentOutOfRangeExceptionThrown_IfConstructedWithZeroValuePrice()
      {
         ItemInfo info = new ItemInfo("A great item", 0M, 10);
      }

      [TestMethod]
      public void SucessfullInitialization_IfConstructedWithValidDescriptionAndPriceButNoQuantity()
      {
         ItemInfo info = new ItemInfo("A great item", 20M);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentNullException), "ItemInfo description was allowed to be set to zero")]
      public void CannotChangeItemInfoDescriptionToNull()
      {
         ItemInfo info = new ItemInfo("A great item", 20M);
         info.Description = "";
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentOutOfRangeException), "ItemInfo description was allowed to be set to zero")]
      public void CannotChangeItemInfoPriceToZero()
      {
         ItemInfo info = new ItemInfo("A great item", 20M);
         info.Price = 0M;
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentOutOfRangeException), "ItemInfo description was allowed to be set to zero")]
      public void CannotChangeItemInfoQuantiyToNegative()
      {
         ItemInfo info = new ItemInfo("A great item", 20M);
         info.StockQty = -20;
      }
   }
}
