using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSupportSystem
{
   class ShoppingSaleState : SaleState
   {
      public override void BuyItems(decimal payAmount, Sale sale)
      {
         // TODO: Check to see if this method is of any good
      }

      public override void BuyItems(Sale sale)
      {
         sale.ReallyBuyItems();
      }

      public override void MakePayment(decimal paymentAmount, Sale sale)
      {
         // Should do nothing because Awaing Purchase State should handle this action
         // Stay in Shopping state
      }

      public override void TotalSale(Sale sale)
      {
         sale.ReallyTotalSale();
         sale.SaleState = new AwaitingPaymentSaleState();
      }
   }
}
