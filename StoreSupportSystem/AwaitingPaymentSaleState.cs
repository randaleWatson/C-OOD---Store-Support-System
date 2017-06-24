using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSupportSystem
{
   public class AwaitingPaymentSaleState : SaleState
   {
      public void BuyItems(decimal payAmount, Sale sale)
      {
         // Update sale records and reflect in inventory
      }

      public void BuyItems(Sale sale)
      {
         // Check that no payments have been made
         if (sale.AmountDue == sale.SaleTotal)
         {

            // Call the ReallyBuyItems method
            sale.ReallyBuyItems();

            // Switch to Shopping state since they are still buying items
            sale.SaleState = new ShoppingSaleState();
         }
         // Do nothing because payment is process
      }

      public void MakePayment(decimal paymentAmount, Sale sale)
      {
         // make the payment on the sale
         sale.ReallyMakePayment(paymentAmount);

         // Check to see if payment is greater than amount due
         if (sale.AmountDue <= 0M)
         {
            // Sale should move to Completed Sale State
            sale.SaleState = new CompletedSaleState();
         }
      }

      public void TotalSale(Sale sale)
      {
         // Do nothing sale should already be totalled by Shopping state
         // Stays in Awaiting Payment State
      }

      public void VoidSale(Sale sale)
      {
         sale.SaleState = new VoidedSaleState();
      }
   }
}
