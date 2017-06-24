using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StoreSupportSystem
{
   [TestClass]
   public class ItemSpecificaionTests
   {
      private ItemInfo info;

      [TestInitialize]
      public void Initialize()
      {
         info = new ItemInfo("A super great item", 23.76M, 12);
      }

      [TestCleanup]
      public void CleanUp()
      {
         info = null;
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentOutOfRangeException), "Invalid Description allowed - when contructed with negative upc")]
      public void TestThatSpecificationCannotBeCreatedWithNegativeUpcParameter()
      {
         new ItemSpecification(-2, info);
      }

      [TestMethod]
      public void TestThatSPecificationCreatedWithZeroValueUPC()
      {
         Assert.IsNotNull(new ItemSpecification(0, info));
      }

      [TestMethod]
      public void TestThatSPecificationCreatedWithNonZeroNonNegativeValueUPC()
      {
         Assert.IsNotNull(new ItemSpecification(12, info));
      }

      //TODO: add test for duplicate item descriptions
   }
}
