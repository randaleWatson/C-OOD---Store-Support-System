using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace StoreSupportSystem
{
   [TestClass]
   public class SaleLineItemTests
   {
      Inventory inventory;

      [TestInitialize]
      public void Setup()
      {
         Item item1 = new Item("item1", new ItemSpecification(1, new ItemInfo("Good item 1", 23.45M, 34)));
         Item item2 = new Item("item2", new ItemSpecification(2, new ItemInfo("Good item 2", 23.45M, 34)));
         Item item3 = new Item("item3", new ItemSpecification(3, new ItemInfo("Good item 3", 23.45M, 34)));
         inventory = new Inventory(item1, item2, item3);
      }

      [TestMethod]
      public void TestBuyItemsMethodReflectsCorrectQtyCount()
      {
         SaleLineItem lineItem = new SaleLineItem();
         lineItem.BuyItems(inventory.FindItem(3), 6);
         Assert.AreEqual(6, lineItem.Quantity);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentOutOfRangeException), "Allowed negative PurchaseQty")]
      public void TestArgumentOutOfRangeException_ForNegativetQtyCount()
      {
         SaleLineItem lineItem = new SaleLineItem();
         lineItem.BuyItems(inventory.FindItem(3), -3);
         Assert.AreEqual(6, lineItem.Quantity);
      }
   }
}
