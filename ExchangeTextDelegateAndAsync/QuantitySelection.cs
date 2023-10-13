namespace ExchangeTextDelegateAndAsync
{
    public partial class QuantitySelection : Form
    {
        public decimal Num { get; set; }
        public bool Deal { get; set; }
        public QuantitySelection()
        {
            InitializeComponent();
            Deal = false;
        }

        private void QuantitySelection_Load(object sender, EventArgs e)
        {

        }

        private void buttonPlus10_Click(object sender, EventArgs e)
        {
            textBoxSum.Text = (Convert.ToDecimal(textBoxSum.Text) + 10).ToString();
        }

        private void textBoxSum_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSum_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void buttonPlus100_Click(object sender, EventArgs e)
        {
            textBoxSum.Text = (Convert.ToDecimal(textBoxSum.Text) + 100).ToString();
        }

        private void buttonMinus10_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(textBoxSum.Text) >= 10)
            {
                textBoxSum.Text = (Convert.ToDecimal(textBoxSum.Text) - 10).ToString();
            }
        }

        private void buttonMinus100_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(textBoxSum.Text) >= 100)
            {
                textBoxSum.Text = (Convert.ToDecimal(textBoxSum.Text) - 100).ToString();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(textBoxSum.Text) > 0)
            {
                Deal = true;
                Num = Convert.ToDecimal(textBoxSum.Text);
                this.Close();
            }
        }
    }
}
