using System;
using System.Collections.Generic;

namespace StoreSupportSystem
{
   //TODO: Incorporate SaleState
   public class Sale
   {
      List<SaleLineItem> saleLineItems;
      SaleState saleState;
      Item currentItem;
      int currentPurchaseQty;
      decimal saleTotal;

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
      }

      SaleLineItem create()
      {
         return new SaleLineItem();
      }

      public void TotalSale()
      {
         saleState.TotalSale(this);
      }

      //TODO: flesh out Really buy items method
      public void ReallyBuyItems()
      {
         SaleLineItem saleLineItem = create();
         saleLineItem.BuyItems(currentItem, currentPurchaseQty);
         saleLineItems.Add(saleLineItem);
         currentItem = null;
         currentPurchaseQty = 0;
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
   }
}