using static System.Net.Mime.MediaTypeNames;

namespace ExchangeTextDelegateAndAsync
{
    public partial class Form1 : Form
    {
        private decimal WalletRubles { get; set; } = 10000;
        private decimal WalletEuro { get; set; } = 0;

        private decimal EuroSell { get; set; }
        private decimal EuroBuy { get; set; }

        private delegate void Update();
        private Update updateLabelsHandler;
        public Form1()
        {
            InitializeComponent();



            updateLabelsHandler = () =>
            {
                labelWalletRubles.Text = WalletRubles.ToString();
                labelWalletEuro.Text = WalletEuro.ToString();

            };

            updateLabelsHandler();

            ExchangeRequest exchangeRequest = new ExchangeRequest();
            RequestNews requestNews = new RequestNews();

            requestNews.requestHandler = CurrentNews;
            exchangeRequest.requestHandler = CurrentPrice;

            Thread ThreadPrice = new Thread(exchangeRequest.GetPriceBuySell);
            Thread ThreadNews = new Thread(requestNews.GetNews);

            ThreadPrice.IsBackground = true;
            ThreadNews.IsBackground = true;

            ThreadPrice.Start();
            ThreadNews.Start();



        }
        private delegate void SafeCallDelegate(decimal priceSell, decimal priceBuy);


        public void SetExchangeRateBuy(decimal priceSell, decimal priceBuy)
        {
            if (listPriceBuyEuro.InvokeRequired)
            {
                var d = new SafeCallDelegate(SetExchangeRateBuy);
                listPriceBuyEuro.Invoke(d, new object[] { priceSell, priceBuy });
            }
            else
            {
                listPriceBuyEuro.Items.Add(priceBuy.ToString());
                this.listPriceBuyEuro.SelectedIndex = this.listPriceBuyEuro.Items.Count - 1;
            }
        }

        public void SetExchangeRateSell(decimal priceSell, decimal priceBuy)
        {
            if (listPriceSellEuro.InvokeRequired)
            {
                var d = new SafeCallDelegate(SetExchangeRateSell);
                listPriceSellEuro.Invoke(d, new object[] { priceSell, priceBuy });
            }
            else
            {
                listPriceSellEuro.Items.Add(priceSell.ToString());
                this.listPriceSellEuro.SelectedIndex = this.listPriceSellEuro.Items.Count - 1;
            }
        }

        public void CurrentPrice(decimal priceSell, decimal priceBuy)
        {
            // Не понимаю ошибку:
            /*Недопустимая операция в нескольких потоках: 
             * попытка доступа к элементу управления 'listPriceBuyEuro' не из того потока, в котором он был создан.*/
            //---------------------------------------------------------------------------------------------------------
            // понял ошибку. Вызов этого метода идёт в классе ExchangeRequest, который не знает что такое 'listPriceBuyEuro'
            // однако не понял как решить эту проблему. Можно реализовать паттерн Наблюдатель, но тогда их придётся делать 2 (курс валют и новости)
            //---------------------------------------------------------------------------------------------------------
            // понял как решить проблему. оказывается такой вызов непотокобезопасный. 3 варианта решения: игнор, создание делегата для слежения какому к какому потому относится элемент, создание обработчика событий. 
            // я выбрал создание делегата. Пришлось запихнуть в отельные методы, т.к. при вызове этого метода иногда курс мог успеть измениться. (т.е. отображались бы старые данные)
            EuroSell = priceSell;
            EuroBuy = priceBuy;

            SetExchangeRateBuy(priceSell, priceBuy);
            SetExchangeRateSell(priceSell, priceBuy);
        }
        private delegate void SafeCallDelegateForNews(string text);
        public void CurrentNews(string news)
        {

            if (listNews.InvokeRequired )
            {
                var d = new SafeCallDelegateForNews(CurrentNews);
                listNews.Invoke(d, new object[] { news });

            }
            else
            {
                listNews.Items.Add(news);
                this.listNews.SelectedIndex = this.listNews.Items.Count - 1;
            }
               
            
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            QuantitySelection win = new QuantitySelection();
            win.ShowDialog();
            if (win.Deal)
                if (win.Num * EuroBuy > WalletRubles)
                    MessageBox.Show("У вас недостаточно средств!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    WalletRubles -= win.Num * EuroBuy;
                    WalletEuro += win.Num;
                    updateLabelsHandler();
                    listBoxLogs.Items.Add($"Купил {win.Num} евро по курсу {EuroBuy}");
                    this.listBoxLogs.SelectedIndex = this.listBoxLogs.Items.Count - 1;
                }

        }

        private void buttonSell_Click(object sender, EventArgs e)
        {
            QuantitySelection win = new QuantitySelection();
            win.ShowDialog();
            if (win.Deal)
                if (win.Num > WalletEuro)
                    MessageBox.Show("У вас недостаточно средств!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    WalletEuro -= win.Num;
                    WalletRubles += win.Num * EuroSell;
                    updateLabelsHandler();
                    listBoxLogs.Items.Add($"Продал {win.Num} евро по курсу {EuroSell}");
                    this.listBoxLogs.SelectedIndex = this.listBoxLogs.Items.Count - 1;
                }
        }
    }
}