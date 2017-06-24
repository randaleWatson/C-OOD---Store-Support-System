using System;
using System.Collections.Generic;

namespace StoreSupportSystem
{
   public class Sale
   {
      private List<SaleLineItem> saleLineItems;
      private SaleState saleState;
      private Item currentItem;
      private int currentPurchaseQty;
      private decimal saleTotal;

      public Sale()
      {
         saleState = new ShoppingSaleState();
         saleLineItems = new List<SaleLineItem>();
      }

      public int LineItemCount()
      {
         throw new NotImplementedException();
      }

      //TODO: Fit in the logic for consulting sale state
      public void BuyItems(Item item, int purchaseQty)
      {
         currentItem = item;
         currentPurchaseQty = purchaseQty;
         saleState.BuyItems(this);

         // clear current Item and Quantity
         currentItem = null;
         currentPurchaseQty = 0;
      }

      SaleLineItem create()
      {
         return new SaleLineItem();
      }

      public void TotalSale()
      {
         saleState.TotalSale(this);
      }

      public void ReallyBuyItems()
      {
         // TODO: Use a try/catch block to handle quanity of zero or null item
         if (currentItem != null && currentPurchaseQty > 0)
         {
            SaleLineItem saleLineItem = create();
            saleLineItem.BuyItems(currentItem, currentPurchaseQty);
            saleLineItems.Add(saleLineItem);
         }
      }

      protected internal virtual void ReallyTotalSale()
      {
         foreach (SaleLineItem lineItem in saleLineItems)
         {
            decimal lineItemPurchaseCost = lineItem.Quantity * lineItem.SalePrice;
            // Add to the SaleTotal
            saleTotal += lineItemPurchaseCost;
            // Increase the amount due
            AmountDue += lineItemPurchaseCost;
         }
      }

      public SaleState SaleState
      {
         get
         {
            return saleState;
         }
         protected internal set
         {
            saleState = value;
         }
      }

      public decimal SaleTotal
      {
         get
         {
            return saleTotal;
         }
      }

      public decimal AmountDue { get; private set; }

      public void MakePayment(decimal paymentAmount)
      {
         saleState.MakePayment(paymentAmount, this);
      }

      public void ReallyMakePayment(decimal paymentAmount)
      {
         // Adjust the amount due based on payment
         AmountDue -= paymentAmount;
      }

      public void VoidSale()
      {
         saleState.VoidSale(this);
      }
   }
}