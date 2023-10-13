using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeTextDelegateAndAsync
{
    public class ExchangeRequest
    {
        public delegate void Request(decimal priceSell, decimal priceBuy);

        public Request? requestHandler { get; set; }

        public (decimal, decimal) GetPriceBuy()
        {
            while (true)
            {
                decimal priceSell = (new Random()).Next(80, 90);
                decimal priceBuy = 0;
                do
                {
                    priceBuy = (new Random()).Next(80, 90);
                } while (priceBuy > priceSell);
               
                requestHandler?.Invoke(priceSell, priceBuy);

                Thread.Sleep(new Random().Next(1000, 3000));

            }
        }
    }
}
