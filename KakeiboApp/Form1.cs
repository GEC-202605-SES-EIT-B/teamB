namespace KakeiboApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btpAdd_Click(object sender, EventArgs e)
        {

            var item = new ExpenseItem
            {
                Date = dtpDate.Value,
                Category = cmbCategory.Text,
                Amount = decimal.Parse(txtAmount.Text),
                Memo = txtMemo.Text
            };

            AppData.Items.Add(item);

            MessageBox.Show("登録完了");
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpMonth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            dgvList.DataSource = null;
            dgvList.DataSource = AppData.Items;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}



