using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSupportSystem
{
   class ShoppingSaleState : SaleState
   {
      public override void BuyItems(decimal payAmount, Sale sale)
      {
         throw new NotImplementedException();
      }

      public override void BuyItems(Sale sale)
      {
         throw new NotImplementedException();
      }

      public override void MakePayment(decimal paymentAmount, Sale sale)
      {
         throw new NotImplementedException();
      }

      public override void TotalSale(Sale sale)
      {
         throw new NotImplementedException();
      }
   }
}
