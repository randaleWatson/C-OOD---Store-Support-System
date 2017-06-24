using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSupportSystem
{
   public class ShoppingSaleState : SaleState
   {
      public void BuyItems(decimal payAmount, Sale sale)
      {
         // TODO: Check to see if this method is of any good
      }

      public void BuyItems(Sale sale)
      {
         sale.ReallyBuyItems();
      }

      public void MakePayment(decimal paymentAmount, Sale sale)
      {
         // Should do nothing because Awaing Purchase State should handle this action
         // Stay in Shopping state
      }

      public void TotalSale(Sale sale)
      {
         sale.ReallyTotalSale();
         sale.SaleState = new AwaitingPaymentSaleState();
      }

      public void VoidSale(Sale sale)
      {
         sale.SaleState = new VoidedSaleState();
      }
   }
}
