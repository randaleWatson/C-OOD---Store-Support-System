namespace StoreSupportSystem
{
   public abstract class SaleState
   {
      public abstract void BuyItems(decimal payAmount, Sale sale);
      public abstract void TotalSale(Sale sale);
      public abstract void MakePayment(decimal paymentAmount, Sale sale);
      public abstract void BuyItems(Sale sale);
   }
}