using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSupportSystem
{
   [TestClass]
   public class SaleTest
   {
      Sale sale;
      Inventory inventory;

      [TestInitialize]
      public void Setup()
      {
         if(inventory == null)
         {
            Item item1 = new Item("item1", new ItemSpecification(1, new ItemInfo("Good item 1", 5.00M, 34)));
            Item item2 = new Item("item2", new ItemSpecification(2, new ItemInfo("Good item 2", 5.00M, 34)));
            Item item3 = new Item("item3", new ItemSpecification(3, new ItemInfo("Good item 3", 5.00M, 34)));
            inventory = new Inventory(item1, item2, item3);
         }
         sale = new Sale();
      }

      [TestMethod]
      public void TestThatSaleHasZeroSaleTotal_WhenInitializes()
      {
         sale.TotalSale();
         Assert.AreEqual(0, sale.SaleTotal);
      }

      [TestMethod]
      public void TestThatSaleReflectsTotal_ForThreeLineItemsWorthFiveDollarAndQuantityOfSix()
      {
         sale.BuyItems(inventory.FindItem(1), 6);
         sale.BuyItems(inventory.FindItem(2), 6);
         sale.BuyItems(inventory.FindItem(3), 6);
         sale.TotalSale();
         Assert.AreEqual(90M, sale.SaleTotal);
      }

      [TestMethod]
      public void TestThatSaleTotalDoesntIncrease_IfTotalledBackToBack()
      {
         sale.BuyItems(inventory.FindItem(1), 6);
         sale.BuyItems(inventory.FindItem(2), 6);
         sale.BuyItems(inventory.FindItem(3), 6);

         sale.TotalSale();
         sale.TotalSale();

         Assert.AreEqual(90M, sale.SaleTotal);
      }

      [TestMethod]
      public void TestThatSaleTotalISEqualledToAmountDue_AfterBeingTotalled()
      {
         sale.BuyItems(inventory.FindItem(1), 6);
         sale.BuyItems(inventory.FindItem(2), 6);
         sale.BuyItems(inventory.FindItem(3), 6);

         sale.TotalSale();

         Assert.AreEqual(sale.AmountDue, sale.SaleTotal);
      }

      [TestMethod]
      public void TestThatLineItemsCanBeAddedAfter_BeingTotalled()
      {
         sale.BuyItems(inventory.FindItem(1), 6);
         sale.BuyItems(inventory.FindItem(2), 6);
         sale.BuyItems(inventory.FindItem(3), 6);

         sale.TotalSale();

         sale.BuyItems(inventory.FindItem(3), 3);
         sale.TotalSale();

         sale.BuyItems(inventory.FindItem(2), 5);
         sale.TotalSale();

         Assert.AreNotEqual(130M, sale.SaleTotal);
      }

      [TestMethod]
      public void TestThatPaymentCannotBeMade_BeforeTotal()
      {
         sale.BuyItems(inventory.FindItem(1), 6);
         sale.BuyItems(inventory.FindItem(2), 6);
         sale.BuyItems(inventory.FindItem(3), 6);

         sale.MakePayment(40.00M);

         Assert.AreEqual(0, sale.AmountDue);
      }

      [TestMethod]
      public void TestThatAmountDueReducesToFifty_AfterPaymentOfFortyMadeAfterTotalledToNinty()
      {
         sale.BuyItems(inventory.FindItem(1), 6);
         sale.BuyItems(inventory.FindItem(2), 6);
         sale.BuyItems(inventory.FindItem(3), 6);

         sale.TotalSale();
         sale.MakePayment(40.00M);
         Assert.AreEqual(50M, sale.AmountDue);
      }

      [TestMethod]
      public void TestThatMultiplePaymentsCanBeMade_IfWhileAmountDueIsNotSatisfied()
      {
         sale.BuyItems(inventory.FindItem(1), 6);
         sale.BuyItems(inventory.FindItem(2), 6);
         sale.BuyItems(inventory.FindItem(3), 6);

         sale.TotalSale();
         sale.MakePayment(40.00M);

         sale.MakePayment(40.00M);

         Assert.AreEqual(10M, sale.AmountDue);
      }

      [TestMethod]
      public void TestThatAddingPaymentAferPayingInFullDoesNotChangeAmountDue()
      {
         sale.BuyItems(inventory.FindItem(1), 6);
         sale.BuyItems(inventory.FindItem(2), 6);
         sale.BuyItems(inventory.FindItem(3), 6);

         sale.TotalSale();
         sale.MakePayment(90.00M);

         sale.MakePayment(40.00M);

         Assert.AreEqual(0M, sale.AmountDue);
      }

      [TestMethod]
      public void TestThatItemCannotBeBought_AfterAPaymentHasBeenMade()
      {
         sale.BuyItems(inventory.FindItem(1), 6);
         sale.BuyItems(inventory.FindItem(2), 6);
         sale.BuyItems(inventory.FindItem(3), 6);

         sale.TotalSale();

         sale.MakePayment(30.00M);

         sale.BuyItems(inventory.FindItem(3), 2);
         sale.TotalSale();

         Assert.AreEqual(60M, sale.AmountDue);
      }

      // TODO: Test for voieded state
   }
}
