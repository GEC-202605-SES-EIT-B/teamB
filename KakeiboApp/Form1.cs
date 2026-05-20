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

            MessageBox.Show("“o˜^Š®—¹");
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
