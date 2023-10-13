namespace ExchangeTextDelegateAndAsync
{
    public class ExchangeRequest
    {
        public delegate void Request(decimal priceSell, decimal priceBuy);

        public Request? requestHandler { get; set; }

        public void GetPriceBuySell()
        {
            while (true)
            {
                decimal priceSell = (new Random()).Next(80, 90);
                decimal priceBuy = 0;
                do
                {
                    priceBuy = (new Random()).Next(80, 90);
                } while (priceBuy < priceSell);

                requestHandler?.Invoke(priceSell, priceBuy);

                Thread.Sleep(new Random().Next(1000, 3000));

            }
        }
    }
}
