namespace ExchangeTextDelegateAndAsync
{
    partial class QuantitySelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            buttonMinus100 = new Button();
            buttonMinus10 = new Button();
            textBoxSum = new TextBox();
            buttonOk = new Button();
            buttonPlus100 = new Button();
            buttonPlus10 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(170, 20);
            label1.TabIndex = 0;
            label1.Text = "Введите нужное число:";
            // 
            // buttonMinus100
            // 
            buttonMinus100.Location = new Point(12, 58);
            buttonMinus100.Name = "buttonMinus100";
            buttonMinus100.Size = new Size(67, 65);
            buttonMinus100.TabIndex = 1;
            buttonMinus100.Text = "-100";
            buttonMinus100.UseVisualStyleBackColor = true;
            buttonMinus100.Click += buttonMinus100_Click;
            // 
            // buttonMinus10
            // 
            buttonMinus10.Location = new Point(101, 58);
            buttonMinus10.Name = "buttonMinus10";
            buttonMinus10.Size = new Size(67, 65);
            buttonMinus10.TabIndex = 2;
            buttonMinus10.Text = "-10";
            buttonMinus10.UseVisualStyleBackColor = true;
            buttonMinus10.Click += buttonMinus10_Click;
            // 
            // textBoxSum
            // 
            textBoxSum.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSum.Location = new Point(188, 66);
            textBoxSum.Name = "textBoxSum";
            textBoxSum.Size = new Size(125, 47);
            textBoxSum.TabIndex = 3;
            textBoxSum.Text = "0";
            textBoxSum.TextChanged += textBoxSum_TextChanged;
            textBoxSum.KeyPress += textBoxSum_KeyPress;
            // 
            // buttonOk
            // 
            buttonOk.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            buttonOk.Location = new Point(188, 123);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(125, 65);
            buttonOk.TabIndex = 4;
            buttonOk.Text = "Ок";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonPlus100
            // 
            buttonPlus100.Location = new Point(422, 58);
            buttonPlus100.Name = "buttonPlus100";
            buttonPlus100.Size = new Size(67, 65);
            buttonPlus100.TabIndex = 6;
            buttonPlus100.Text = "+100";
            buttonPlus100.UseVisualStyleBackColor = true;
            buttonPlus100.Click += buttonPlus100_Click;
            // 
            // buttonPlus10
            // 
            buttonPlus10.Location = new Point(333, 58);
            buttonPlus10.Name = "buttonPlus10";
            buttonPlus10.Size = new Size(67, 65);
            buttonPlus10.TabIndex = 5;
            buttonPlus10.Text = "+10";
            buttonPlus10.UseVisualStyleBackColor = true;
            buttonPlus10.Click += buttonPlus10_Click;
            // 
            // QuantitySelection
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 199);
            Controls.Add(buttonPlus100);
            Controls.Add(buttonPlus10);
            Controls.Add(buttonOk);
            Controls.Add(textBoxSum);
            Controls.Add(buttonMinus10);
            Controls.Add(buttonMinus100);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "QuantitySelection";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Выбор количества Евро";
            Load += QuantitySelection_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button buttonMinus100;
        private Button buttonMinus10;
        private TextBox textBoxSum;
        private Button buttonOk;
        private Button buttonPlus100;
        private Button buttonPlus10;
    }
}