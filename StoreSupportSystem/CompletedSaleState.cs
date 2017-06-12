using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSupportSystem
{
   public class CompletedSaleState : SaleState
   {
      public override void BuyItems(decimal payAmount, Sale sale)
      {
         // Does nothing
      }

      public override void BuyItems(Sale sale)
      {
         // Does nothing
      }

      public override void MakePayment(decimal paymentAmount, Sale sale)
      {
         // Does nothing
      }

      public override void TotalSale(Sale sale)
      {
         // Does nothing
      }
   }
}
