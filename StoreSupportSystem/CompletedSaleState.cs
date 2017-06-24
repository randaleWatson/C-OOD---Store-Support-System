using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSupportSystem
{
   public class CompletedSaleState : SaleState
   {
      public void BuyItems(decimal payAmount, Sale sale)
      {
         // Does nothing
      }

      public void BuyItems(Sale sale)
      {
         // Does nothing
      }

      public void MakePayment(decimal paymentAmount, Sale sale)
      {
         // Does nothing
      }

      public void TotalSale(Sale sale)
      {
         // Does nothing
      }

      public void VoidSale(Sale sale)
      {
         // Does nothing cannot void completed sale
      }
   }
}
