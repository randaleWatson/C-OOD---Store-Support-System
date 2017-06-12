using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StoreSupportSystem
{
   [TestClass]
   public class InventoryTests
   {
      [TestMethod]
      public void TestThatNoArgConstructorHasNoItemsInTheInventory()
      {
         Inventory inventory = new Inventory();
         Assert.AreEqual(0, inventory.ItemCount);
      }

      [TestMethod]
      public void TestThatInventoryReturnsTheCorrectItem_WhenFindItemMethodCalledWithItemUpc()
      {
         Item item1 = new Item("item1", new ItemSpecification(1, new ItemInfo("Good item 1", 23.45M, 34)));
         Item item2 = new Item("item2", new ItemSpecification(2, new ItemInfo("Good item 2", 23.45M, 34)));
         Item item3 = new Item("item3", new ItemSpecification(3, new ItemInfo("Good item 3", 23.45M, 34)));
         Inventory inventory = new Inventory(item1, item2, item3);
         Item found = inventory.FindItem(2);
         Assert.AreEqual(item2, found);
      }

      [TestMethod]
      public void TestThatInventoryReturnsNull_WhenFindItemMethodCalledWithNonExistingUpc()
      {
         Item item1 = new Item("item1", new ItemSpecification(1, new ItemInfo("Good item 1", 23.45M, 34)));
         Item item2 = new Item("item2", new ItemSpecification(2, new ItemInfo("Good item 2", 23.45M, 34)));
         Item item3 = new Item("item3", new ItemSpecification(3, new ItemInfo("Good item 3", 23.45M, 34)));
         Inventory inventory = new Inventory(item1, item2, item3);
         Item found = inventory.FindItem(4);
         Assert.IsNull(found);
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException),"Duplicate Item allowed in the inventory")]
      public void TestThatInvlaidOperationExceptionThrownForaddingDuplicateItemToTheInventory()
      {
         Item item1 = new Item("item1", new ItemSpecification(1, new ItemInfo("Good item 1", 23.45M, 34)));
         Item item2 = new Item("item2", new ItemSpecification(2, new ItemInfo("Good item 2", 23.45M, 34)));
         Item item3 = new Item("item3", new ItemSpecification(1, new ItemInfo("Good item 3", 23.45M, 34)));
         Inventory inventory = new Inventory(item1, item2, item3);
         Assert.AreEqual(3, inventory.ItemCount);
      }

      [TestMethod]
      public void TestThatInitializationWithThreeItem_HasThreeItemsInTheInventory()
      {
         Item item1 = new Item("item1", new ItemSpecification(1, new ItemInfo("Good item 1", 23.45M, 34)));
         Item item2 = new Item("item2", new ItemSpecification(2, new ItemInfo("Good item 2", 23.45M, 34)));
         Item item3 = new Item("item3", new ItemSpecification(3, new ItemInfo("Good item 3", 23.45M, 34)));
         Inventory inventory = new Inventory(item1, item2, item3);
         Assert.AreEqual(3, inventory.ItemCount);
      }
   }
}
