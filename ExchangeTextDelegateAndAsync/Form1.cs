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



            updateLabelsHandler = () => {
                labelWalletRubles.Text = WalletRubles.ToString(); 
                labelWalletEuro.Text = WalletEuro.ToString();

            };

            updateLabelsHandler();
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

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

        public void CurrentPrice(decimal priceSell, decimal priceBuy)
        {
            // Не понимаю ошибку:
            /*Недопустимая операция в нескольких потоках: 
             * попытка доступа к элементу управления 'listPriceBuyEuro' не из того потока, в котором он был создан.*/
            //---------------------------------------------------------------------------------------------------------
            // понял ошибку. Вызов этого метода идёт в классе ExchangeRequest, который не знает что такое 'listPriceBuyEuro'
            // однако не понял как решить эту проблему. Можно реализовать паттерн Наблюдатель, но тогда их придётся делать 2 (курс валют и новости)
            EuroSell = priceSell;
            EuroBuy = priceBuy;
            listPriceBuyEuro.Items.Add(EuroBuy.ToString());
            listPriceSellEuro.Items.Add(EuroSell.ToString());

            this.listPriceBuyEuro.SelectedIndex = this.listPriceBuyEuro.Items.Count - 1;
            this.listPriceSellEuro.SelectedIndex = this.listPriceSellEuro.Items.Count - 1;
        }

        public void CurrentNews(string news)
        {
            listNews.Items.Add(news);
            this.listNews.SelectedIndex = this.listNews.Items.Count - 1;
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            QuantitySelection win = new QuantitySelection();
            win.ShowDialog();
            if (win.Num * EuroBuy > WalletRubles)
                MessageBox.Show("У вас недостаточно средств!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                WalletRubles -= win.Num * EuroBuy;
                WalletEuro += win.Num;
                updateLabelsHandler();
                listBoxLogs.Items.Add($"Купил {win.Num} евро по курсу {EuroBuy}");
            }

        }

        private void buttonSell_Click(object sender, EventArgs e)
        {
            QuantitySelection win = new QuantitySelection();
            win.ShowDialog();
            if (win.Num > WalletEuro)
                MessageBox.Show("У вас недостаточно средств!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                WalletEuro -= win.Num;
                WalletRubles += win.Num * EuroSell;
                updateLabelsHandler();
                listBoxLogs.Items.Add($"Продал {win.Num} евро по курсу {EuroSell}");
            }
        }
    }
}