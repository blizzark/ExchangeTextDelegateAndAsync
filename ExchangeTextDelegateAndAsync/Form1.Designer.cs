namespace ExchangeTextDelegateAndAsync
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listPriceBuyEuro = new ListBox();
            label1 = new Label();
            listPriceSellEuro = new ListBox();
            label2 = new Label();
            buttonBuy = new Button();
            buttonSell = new Button();
            label3 = new Label();
            labelWallet = new Label();
            label5 = new Label();
            listNews = new ListBox();
            SuspendLayout();
            // 
            // listPriceBuyEuro
            // 
            listPriceBuyEuro.FormattingEnabled = true;
            listPriceBuyEuro.ItemHeight = 20;
            listPriceBuyEuro.Location = new Point(12, 36);
            listPriceBuyEuro.Name = "listPriceBuyEuro";
            listPriceBuyEuro.Size = new Size(254, 444);
            listPriceBuyEuro.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 9);
            label1.Name = "label1";
            label1.Size = new Size(144, 20);
            label1.TabIndex = 1;
            label1.Text = "Цена покупки Евро";
            // 
            // listPriceSellEuro
            // 
            listPriceSellEuro.FormattingEnabled = true;
            listPriceSellEuro.ItemHeight = 20;
            listPriceSellEuro.Location = new Point(272, 36);
            listPriceSellEuro.Name = "listPriceSellEuro";
            listPriceSellEuro.Size = new Size(254, 444);
            listPriceSellEuro.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(318, 9);
            label2.Name = "label2";
            label2.Size = new Size(150, 20);
            label2.TabIndex = 3;
            label2.Text = "Цена продажи Евро";
            // 
            // buttonBuy
            // 
            buttonBuy.Location = new Point(681, 451);
            buttonBuy.Name = "buttonBuy";
            buttonBuy.Size = new Size(94, 29);
            buttonBuy.TabIndex = 4;
            buttonBuy.Text = "Купить";
            buttonBuy.UseVisualStyleBackColor = true;
            buttonBuy.Click += buttonBuy_Click;
            // 
            // buttonSell
            // 
            buttonSell.Location = new Point(542, 451);
            buttonSell.Name = "buttonSell";
            buttonSell.Size = new Size(94, 29);
            buttonSell.TabIndex = 5;
            buttonSell.Text = "Продать";
            buttonSell.UseVisualStyleBackColor = true;
            buttonSell.Click += buttonSell_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(542, 414);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 6;
            label3.Text = "Кошелёк:";
            // 
            // labelWallet
            // 
            labelWallet.AutoSize = true;
            labelWallet.Location = new Point(621, 414);
            labelWallet.Name = "labelWallet";
            labelWallet.Size = new Size(17, 20);
            labelWallet.TabIndex = 7;
            labelWallet.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(621, 9);
            label5.Name = "label5";
            label5.Size = new Size(68, 20);
            label5.TabIndex = 8;
            label5.Text = "Новости";
            // 
            // listNews
            // 
            listNews.FormattingEnabled = true;
            listNews.ItemHeight = 20;
            listNews.Location = new Point(532, 36);
            listNews.Name = "listNews";
            listNews.Size = new Size(254, 344);
            listNews.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 507);
            Controls.Add(listNews);
            Controls.Add(label5);
            Controls.Add(labelWallet);
            Controls.Add(label3);
            Controls.Add(buttonSell);
            Controls.Add(buttonBuy);
            Controls.Add(label2);
            Controls.Add(listPriceSellEuro);
            Controls.Add(label1);
            Controls.Add(listPriceBuyEuro);
            Name = "Form1";
            Text = "Биржа";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listPriceBuyEuro;
        private Label label1;
        private ListBox listPriceSellEuro;
        private Label label2;
        private Button buttonBuy;
        private Button buttonSell;
        private Label label3;
        private Label labelWallet;
        private Label label5;
        private ListBox listNews;
    }
}