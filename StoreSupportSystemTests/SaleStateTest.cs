using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSupportSystem
{
   [TestClass]
   public class SaleStateTest
   {
      private Sale sale;
      private Inventory inventory;

      [TestInitialize]
      public void Setup()
      {
         if (inventory == null)
         {
            Item item1 = new Item("item1", new ItemSpecification(1, new ItemInfo("Good item 1", 5.00M, 34)));
            Item item2 = new Item("item2", new ItemSpecification(2, new ItemInfo("Good item 2", 5.00M, 34)));
            Item item3 = new Item("item3", new ItemSpecification(3, new ItemInfo("Good item 3", 5.00M, 34)));
            inventory = new Inventory(item1, item2, item3);
         }
         sale = new Sale();
      }

     [TestMethod]
      public void TestThatInitialSaleStateIsShoppingSaleState()
      {
         Assert.IsTrue(sale.SaleState is ShoppingSaleState);
      }

      [TestMethod]
      public void TestThatSaleStateSwitchesToAwaitingPaymentState_WhenTotalled()
      {
         sale.BuyItems(inventory.FindItem(2),3);
         sale.TotalSale();
         Assert.IsTrue(sale.SaleState is AwaitingPaymentSaleState);
      }

      [TestMethod]
      public void TestThatSaleStateSwitchesToAwaitingPaymentState_ThenToShoppingState_WhenTotalledAndItemBought()
      {
         sale.BuyItems(inventory.FindItem(2), 3);
         sale.TotalSale();
         sale.BuyItems(inventory.FindItem(2), 3);
         Assert.IsTrue(sale.SaleState is ShoppingSaleState);
      }

      [TestMethod]
      public void TestThatSaleStateSwitchesToCompletedState_WhenAFullPaymentIsMadeAfterBeingTotalled()
      {
         sale.BuyItems(inventory.FindItem(2), 3);
         sale.TotalSale();
         sale.MakePayment(15M);
         Assert.IsTrue(sale.SaleState is CompletedSaleState);
      }

      [TestMethod]
      public void TestThatSaleStateIsAwaitingPaymentState_WhenAPartialPaymentIsMadeAfterBeingTotalled()
      {
         sale.BuyItems(inventory.FindItem(2), 3);
         sale.TotalSale();
         sale.MakePayment(10M);
         Assert.IsTrue(sale.SaleState is AwaitingPaymentSaleState);
      }

      [TestMethod]
      public void TestThatSaleStateIsShoppingState_WhenPaymentIsMadeAndNotTotalled()
      {
         sale.BuyItems(inventory.FindItem(2), 3);
         sale.MakePayment(10M);
         Assert.IsTrue(sale.SaleState is ShoppingSaleState);
      }

      [TestMethod]
      public void TestThatSaleStateIsCompletedState_WhenFullPaymentIsMadeAfterBeingTotalled_AndAttemptedToBuyItem()
      {
         sale.BuyItems(inventory.FindItem(2), 3);
         sale.TotalSale();
         sale.MakePayment(15M);
         sale.BuyItems(inventory.FindItem(3), 12);
         Assert.IsTrue(sale.SaleState is CompletedSaleState);
      }

      [TestMethod]
      public void TestThatSaleStateIsCompletedState_WhenFullPaymentIsMadeAfterBeingTotalled_AndAttemptedToBuyItemAndRetotalled()
      {
         sale.BuyItems(inventory.FindItem(2), 3);
         sale.TotalSale();
         sale.MakePayment(15M);
         sale.BuyItems(inventory.FindItem(3), 12);
         sale.TotalSale();
         Assert.IsTrue(sale.SaleState is CompletedSaleState);
      }

      [TestMethod]
      public void TestThatSaleStateIsVoid_WhenVoidedFromShoopingSaleState()
      {
         sale.BuyItems(inventory.FindItem(2), 3);
         sale.VoidSale();
         Assert.IsTrue(sale.SaleState is VoidedSaleState);
      }

      [TestMethod]
      public void TestThatSaleStateIsVoid_WhenVoidedFromAwaitingPaymentSaleState()
      {
         sale.BuyItems(inventory.FindItem(2), 3);
         sale.TotalSale();
         sale.VoidSale();
         Assert.IsTrue(sale.SaleState is VoidedSaleState);
      }

      [TestMethod]
      public void TestThatSaleStateIsCompleted_WhenVoidedFromCompletedSaleState()
      {
         sale.BuyItems(inventory.FindItem(2), 3);
         sale.TotalSale();
         sale.MakePayment(15M);
         sale.VoidSale();
         Assert.IsTrue(sale.SaleState is CompletedSaleState);
      }

      [TestMethod]
      public void TestThatSaleStateIsVoided_WhenVoidedFromVoidedSaleState()
      {
         sale.BuyItems(inventory.FindItem(2), 3);
         sale.TotalSale();
         sale.VoidSale();
         sale.VoidSale();
         Assert.IsTrue(sale.SaleState is VoidedSaleState);
      }
   }
}
