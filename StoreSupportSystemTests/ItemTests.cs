using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StoreSupportSystem
{
   [TestClass]
   public class ItemTest
   {
      ItemSpecification spec;

      [TestInitialize]
      public void Setup()
      {
         ItemInfo info = new ItemInfo("Spectacular Item", 23.56M, 12);
         spec = new ItemSpecification(5, info);
      }

      [TestCleanup]
      public void CleanUp()
      {
         spec = null;
      }

      [TestMethod]
      public void TestThatItemCannotBeCreatedWithhNullOrEmptyName()
      {

      }
   }
}
