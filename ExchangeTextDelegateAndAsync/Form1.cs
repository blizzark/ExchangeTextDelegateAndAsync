namespace ExchangeTextDelegateAndAsync
{
    public partial class Form1 : Form
    {
        private decimal Wallet { get; set; } = 1000;
        public Form1()
        {
            InitializeComponent();
            labelWallet.Text = Wallet.ToString();
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            QuantitySelection win = new QuantitySelection();
            win.ShowDialog();
            if (win.Num > Wallet)
            {

            }
        }

        private void buttonSell_Click(object sender, EventArgs e)
        {

        }
    }
}