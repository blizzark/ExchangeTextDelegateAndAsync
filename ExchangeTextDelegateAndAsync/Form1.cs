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
            // �� ������� ������:
            /*������������ �������� � ���������� �������: 
             * ������� ������� � �������� ���������� 'listPriceBuyEuro' �� �� ���� ������, � ������� �� ��� ������.*/
            //---------------------------------------------------------------------------------------------------------
            // ����� ������. ����� ����� ������ ��� � ������ ExchangeRequest, ������� �� ����� ��� ����� 'listPriceBuyEuro'
            // ������ �� ����� ��� ������ ��� ��������. ����� ����������� ������� �����������, �� ����� �� ������� ������ 2 (���� ����� � �������)
            //---------------------------------------------------------------------------------------------------------
            // ����� ��� ������ ��������. ����������� ����� ����� ������������������. 3 �������� �������: �����, �������� �������� ��� �������� ������ � ������ ������ ��������� �������, �������� ����������� �������. 
            // � ������ �������� ��������. �������� ��������� � �������� ������, �.�. ��� ������ ����� ������ ������ ���� ��� ������ ����������. (�.�. ������������ �� ������ ������)
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
                    MessageBox.Show("� ��� ������������ �������!", "������!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    WalletRubles -= win.Num * EuroBuy;
                    WalletEuro += win.Num;
                    updateLabelsHandler();
                    listBoxLogs.Items.Add($"����� {win.Num} ���� �� ����� {EuroBuy}");
                    this.listBoxLogs.SelectedIndex = this.listBoxLogs.Items.Count - 1;
                }

        }

        private void buttonSell_Click(object sender, EventArgs e)
        {
            QuantitySelection win = new QuantitySelection();
            win.ShowDialog();
            if (win.Deal)
                if (win.Num > WalletEuro)
                    MessageBox.Show("� ��� ������������ �������!", "������!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    WalletEuro -= win.Num;
                    WalletRubles += win.Num * EuroSell;
                    updateLabelsHandler();
                    listBoxLogs.Items.Add($"������ {win.Num} ���� �� ����� {EuroSell}");
                    this.listBoxLogs.SelectedIndex = this.listBoxLogs.Items.Count - 1;
                }
        }
    }
}