namespace KakeiboApp
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
            dtpDate = new DateTimePicker();
            txtMemo = new TextBox();
            txtAmount = new TextBox();
            comboBox1 = new ComboBox();
            btpAdd = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(32, 47);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(300, 31);
            dtpDate.TabIndex = 0;
            // 
            // txtMemo
            // 
            txtMemo.Location = new Point(638, 286);
            txtMemo.Name = "txtMemo";
            txtMemo.Size = new Size(150, 31);
            txtMemo.TabIndex = 1;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(343, 286);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(150, 31);
            txtAmount.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "生活費", "食費", "娯楽費", "給与", "その他" });
            comboBox1.Location = new Point(12, 286);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 3;
            // 
            // btpAdd
            // 
            btpAdd.Location = new Point(657, 387);
            btpAdd.Name = "btpAdd";
            btpAdd.Size = new Size(112, 34);
            btpAdd.TabIndex = 4;
            btpAdd.Text = "登録";
            btpAdd.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 240);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 5;
            label1.Text = "カテゴリ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(375, 240);
            label2.Name = "label2";
            label2.Size = new Size(48, 25);
            label2.TabIndex = 6;
            label2.Text = "金額";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(680, 240);
            label3.Name = "label3";
            label3.Size = new Size(38, 25);
            label3.TabIndex = 7;
            label3.Text = "メモ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(125, 9);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 8;
            label4.Text = "日付";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btpAdd);
            Controls.Add(comboBox1);
            Controls.Add(txtAmount);
            Controls.Add(txtMemo);
            Controls.Add(dtpDate);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpDate;
        private TextBox txtMemo;
        private TextBox txtAmount;
        private ComboBox comboBox1;
        private Button btpAdd;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
