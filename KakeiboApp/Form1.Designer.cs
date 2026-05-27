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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            dtpDate = new DateTimePicker();
            txtMemo = new TextBox();
            txtAmount = new TextBox();
            cmbCategory = new ComboBox();
            cmbInout = new ComboBox();
            cmbFilterType = new ComboBox();
            btpAdd = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnAddCategory = new Button();
            txtNewCategory = new TextBox();
            label8 = new Label();
            btnUpdate = new Button();
            tabPage2 = new TabPage();
            btnEdit = new Button();
            csvButton = new Button();
            label9 = new Label();
            btnDelete = new Button();
            btnSearch = new Button();
            label7 = new Label();
            cmbFilterCategory = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            dtpTo = new DateTimePicker();
            dtpFrom = new DateTimePicker();
            dgvList = new DataGridView();
            tabPage3 = new TabPage();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            button1 = new Button();
            lblIBalance = new Label();
            lblExpense = new Label();
            lblIncome = new Label();
            dtpMonth = new DateTimePicker();
            tabPage4 = new TabPage();
            lblRemain = new Label();
            lblCurrentExpense = new Label();
            btnTargetSet = new Button();
            txtGoal = new TextBox();
            lblMontlyGoal = new Label();
            fileSystemWatcher1 = new FileSystemWatcher();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(25, 74);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(300, 31);
            dtpDate.TabIndex = 0;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // txtMemo
            // 
            txtMemo.Location = new Point(600, 209);
            txtMemo.Name = "txtMemo";
            txtMemo.Size = new Size(150, 31);
            txtMemo.TabIndex = 1;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(398, 207);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(150, 31);
            txtAmount.TabIndex = 2;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "生活費", "食費", "娯楽費", "給与", "その他" });
            cmbCategory.Location = new Point(25, 209);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(150, 33);
            cmbCategory.TabIndex = 3;
            cmbCategory.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // cmbInout
            // 
            cmbInout.FormattingEnabled = true;
            cmbInout.Items.AddRange(new object[] { "支出", "収入" });
            cmbInout.Location = new Point(240, 207);
            cmbInout.Name = "cmbInout";
            cmbInout.Size = new Size(91, 33);
            cmbInout.TabIndex = 11;
            // 
            // cmbFilterType
            // 
            cmbFilterType.Items.AddRange(new object[] { "支出", "収入" });
            cmbFilterType.Location = new Point(558, 41);
            cmbFilterType.Name = "cmbFilterType";
            cmbFilterType.Size = new Size(92, 33);
            cmbFilterType.TabIndex = 0;
            cmbFilterType.SelectedIndexChanged += cmbInout2_SelectedIndexChanged;
            // 
            // btpAdd
            // 
            btpAdd.Location = new Point(498, 314);
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
            label1.Location = new Point(25, 172);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 5;
            label1.Text = "カテゴリ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(398, 172);
            label2.Name = "label2";
            label2.Size = new Size(48, 25);
            label2.TabIndex = 6;
            label2.Text = "金額";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(600, 172);
            label3.Name = "label3";
            label3.Size = new Size(38, 25);
            label3.TabIndex = 7;
            label3.Text = "メモ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 46);
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
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(788, 416);
            tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnAddCategory);
            tabPage1.Controls.Add(txtNewCategory);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(dtpDate);
            tabPage1.Controls.Add(btpAdd);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtMemo);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(cmbCategory);
            tabPage1.Controls.Add(cmbInout);
            tabPage1.Controls.Add(txtAmount);
            tabPage1.Controls.Add(btnUpdate);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(780, 378);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "入力";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Location = new Point(191, 315);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(112, 34);
            btnAddCategory.TabIndex = 13;
            btnAddCategory.Text = "カテゴリ追加";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // txtNewCategory
            // 
            txtNewCategory.Location = new Point(25, 315);
            txtNewCategory.Name = "txtNewCategory";
            txtNewCategory.Size = new Size(150, 31);
            txtNewCategory.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(231, 172);
            label8.Name = "label8";
            label8.Size = new Size(91, 25);
            label8.TabIndex = 10;
            label8.Text = "収入/支出";
            label8.Click += label8_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(638, 314);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "更新";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click_1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnEdit);
            tabPage2.Controls.Add(csvButton);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(cmbFilterType);
            tabPage2.Controls.Add(btnDelete);
            tabPage2.Controls.Add(btnSearch);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(cmbFilterCategory);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(dtpTo);
            tabPage2.Controls.Add(dtpFrom);
            tabPage2.Controls.Add(dgvList);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(780, 378);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "一覧";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(502, 324);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(112, 34);
            btnEdit.TabIndex = 11;
            btnEdit.Text = "編集";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click_1;
            // 
            // csvButton
            // 
            csvButton.Location = new Point(367, 324);
            csvButton.Name = "csvButton";
            csvButton.Size = new Size(112, 34);
            csvButton.TabIndex = 20;
            csvButton.Text = "CSV出力";
            csvButton.UseVisualStyleBackColor = true;
            csvButton.Click += csvButton_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(558, 13);
            label9.Name = "label9";
            label9.Size = new Size(91, 25);
            label9.TabIndex = 10;
            label9.Text = "収入/支出";
            label9.Click += label9_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(638, 324);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "削除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += button2_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(656, 40);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 34);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(402, 15);
            label7.Name = "label7";
            label7.Size = new Size(64, 25);
            label7.TabIndex = 7;
            label7.Text = "カテゴリ";
            label7.Click += label7_Click;
            // 
            // cmbFilterCategory
            // 
            cmbFilterCategory.FormattingEnabled = true;
            cmbFilterCategory.Items.AddRange(new object[] { "すべて", "生活費", "食費", "娯楽費", "給与", "その他" });
            cmbFilterCategory.Location = new Point(402, 41);
            cmbFilterCategory.Name = "cmbFilterCategory";
            cmbFilterCategory.Size = new Size(150, 33);
            cmbFilterCategory.TabIndex = 6;
            cmbFilterCategory.SelectedIndexChanged += cmbFilterCategory_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(202, 15);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 5;
            label6.Text = "終了日";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 15);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 4;
            label5.Text = "開始日";
            label5.Click += label5_Click;
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(202, 43);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(191, 31);
            dtpTo.TabIndex = 3;
            dtpTo.ValueChanged += dtpTo_ValueChanged;
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(3, 43);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(191, 31);
            dtpFrom.TabIndex = 2;
            // 
            // dgvList
            // 
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvList.Location = new Point(20, 92);
            dgvList.Name = "dgvList";
            dgvList.RowHeadersWidth = 62;
            dgvList.Size = new Size(752, 226);
            dgvList.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(chart2);
            tabPage3.Controls.Add(chart1);
            tabPage3.Controls.Add(button1);
            tabPage3.Controls.Add(lblIBalance);
            tabPage3.Controls.Add(lblExpense);
            tabPage3.Controls.Add(lblIncome);
            tabPage3.Controls.Add(dtpMonth);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(780, 378);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "月次サマリ";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // chart2
            // 
            chartArea1.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea1);
            chart2.Location = new Point(17, 124);
            chart2.Name = "chart2";
            chart2.Size = new Size(490, 232);
            chart2.TabIndex = 6;
            chart2.Text = "chart2";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            chart1.Location = new Point(513, 124);
            chart1.Name = "chart1";
            chart1.Size = new Size(267, 232);
            chart1.TabIndex = 5;
            chart1.Text = "chart1";
            // 
            // button1
            // 
            button1.Location = new Point(395, 6);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 4;
            button1.Text = "集計";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblIBalance
            // 
            lblIBalance.AutoSize = true;
            lblIBalance.Location = new Point(17, 90);
            lblIBalance.Name = "lblIBalance";
            lblIBalance.Size = new Size(48, 25);
            lblIBalance.TabIndex = 3;
            lblIBalance.Text = "差額";
            // 
            // lblExpense
            // 
            lblExpense.AutoSize = true;
            lblExpense.Location = new Point(17, 65);
            lblExpense.Name = "lblExpense";
            lblExpense.Size = new Size(48, 25);
            lblExpense.TabIndex = 2;
            lblExpense.Text = "支出";
            // 
            // lblIncome
            // 
            lblIncome.AutoSize = true;
            lblIncome.Location = new Point(17, 40);
            lblIncome.Name = "lblIncome";
            lblIncome.Size = new Size(48, 25);
            lblIncome.TabIndex = 1;
            lblIncome.Text = "収入";
            // 
            // dtpMonth
            // 
            dtpMonth.CustomFormat = "yyyy/MM";
            dtpMonth.Format = DateTimePickerFormat.Custom;
            dtpMonth.Location = new Point(6, 6);
            dtpMonth.Name = "dtpMonth";
            dtpMonth.ShowUpDown = true;
            dtpMonth.Size = new Size(300, 31);
            dtpMonth.TabIndex = 0;
            dtpMonth.ValueChanged += dtpMonth_ValueChanged;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(lblRemain);
            tabPage4.Controls.Add(lblCurrentExpense);
            tabPage4.Controls.Add(btnTargetSet);
            tabPage4.Controls.Add(txtGoal);
            tabPage4.Controls.Add(lblMontlyGoal);
            tabPage4.Location = new Point(4, 34);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(780, 378);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "目標";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // lblRemain
            // 
            lblRemain.AutoSize = true;
            lblRemain.Location = new Point(41, 111);
            lblRemain.Name = "lblRemain";
            lblRemain.Size = new Size(60, 25);
            lblRemain.TabIndex = 4;
            lblRemain.Text = "残り：";
            // 
            // lblCurrentExpense
            // 
            lblCurrentExpense.AutoSize = true;
            lblCurrentExpense.Location = new Point(41, 70);
            lblCurrentExpense.Name = "lblCurrentExpense";
            lblCurrentExpense.Size = new Size(117, 25);
            lblCurrentExpense.TabIndex = 3;
            lblCurrentExpense.Text = "現在の支出：";
            // 
            // btnTargetSet
            // 
            btnTargetSet.Location = new Point(516, 31);
            btnTargetSet.Name = "btnTargetSet";
            btnTargetSet.Size = new Size(112, 34);
            btnTargetSet.TabIndex = 2;
            btnTargetSet.Text = "設定";
            btnTargetSet.UseVisualStyleBackColor = true;
            btnTargetSet.Click += btnTargetSet_Click;
            // 
            // txtGoal
            // 
            txtGoal.Location = new Point(237, 31);
            txtGoal.Name = "txtGoal";
            txtGoal.Size = new Size(238, 31);
            txtGoal.TabIndex = 1;
            // 
            // lblMontlyGoal
            // 
            lblMontlyGoal.AutoSize = true;
            lblMontlyGoal.Location = new Point(41, 31);
            lblMontlyGoal.Name = "lblMontlyGoal";
            lblMontlyGoal.Size = new Size(174, 25);
            lblMontlyGoal.TabIndex = 0;
            lblMontlyGoal.Text = "1ヵ月の支出目標金額";
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
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
        private Label lblIBalance;
        private Label lblExpense;
        private Label lblIncome;
        private DateTimePicker dtpMonth;
        private Button button1;
        private DataGridView dgvList;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private Label label5;
        private Label label7;
        private ComboBox cmbFilterCategory;
        private Label label6;
        private Button btnSearch;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button btnDelete;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private FileSystemWatcher fileSystemWatcher1;
        private ComboBox cmbInout;
        private ComboBox cmbFilterType;
        private Label label8;
        private Label label9;
        private Button btnAddCategory;
        private TextBox txtNewCategory;
        private Button btnUpdate;
        private Button btnEdit;
        private Button csvButton;
        private TabPage tabPage4;
        private Button btnTargetSet;
        private TextBox txtGoal;
        private Label lblMontlyGoal;
        private Label lblCurrentExpense;
        private Label lblRemain;
    }
}
