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
            cmbCategory = new ComboBox();
            btpAdd = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(8, 47);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(300, 31);
            dtpDate.TabIndex = 0;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // txtMemo
            // 
            txtMemo.Location = new Point(606, 235);
            txtMemo.Name = "txtMemo";
            txtMemo.Size = new Size(150, 31);
            txtMemo.TabIndex = 1;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(356, 235);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(150, 31);
            txtAmount.TabIndex = 2;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "生活費", "食費", "娯楽費", "給与", "その他" });
            cmbCategory.Location = new Point(17, 235);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(182, 33);
            cmbCategory.TabIndex = 3;
            // 
            // btpAdd
            // 
            btpAdd.Location = new Point(644, 315);
            btpAdd.Name = "btpAdd";
            btpAdd.Size = new Size(112, 34);
            btpAdd.TabIndex = 4;
            btpAdd.Text = "登録";
            btpAdd.UseVisualStyleBackColor = true;
            btpAdd.Click += btpAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(80, 189);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 5;
            label1.Text = "カテゴリ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(406, 189);
            label2.Name = "label2";
            label2.Size = new Size(48, 25);
            label2.TabIndex = 6;
            label2.Text = "金額";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(653, 189);
            label3.Name = "label3";
            label3.Size = new Size(38, 25);
            label3.TabIndex = 7;
            label3.Text = "メモ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(106, 19);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 8;
            label4.Text = "日付";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(788, 416);
            tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dtpDate);
            tabPage1.Controls.Add(btpAdd);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtMemo);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(cmbCategory);
            tabPage1.Controls.Add(txtAmount);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(780, 378);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "入力";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(780, 378);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "一覧";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(780, 378);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "月次サマリ";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpDate;
        private TextBox txtMemo;
        private TextBox txtAmount;
        private ComboBox cmbCategory;
        private Button btpAdd;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
    }
}
