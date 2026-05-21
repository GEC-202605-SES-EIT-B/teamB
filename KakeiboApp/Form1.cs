using System.Linq;

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

            MessageBox.Show("集計完了");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            var from = dtpFrom.Value.Date;
            var to = dtpTo.Value.Date;

            var data = AppData.Items.Where(x =>
                x.Date.Date >= from &&
                x.Date.Date <= to
            );

            if (cmbFilterCategory.Text != "すべて")
            {
                data = data.Where(x => x.Category == cmbFilterCategory.Text);
            }

            dgvList.DataSource = null;
            dgvList.DataSource = data.ToList();

            MessageBox.Show("検索完了");

        }
    }
   }



