namespace StoreSupportSystem
{
   public interface SaleState
   {
      void BuyItems(decimal payAmount, Sale sale);
      void TotalSale(Sale sale);
      void MakePayment(decimal paymentAmount, Sale sale);
      void BuyItems(Sale sale);
      void VoidSale(Sale sale);
   }
}