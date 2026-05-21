using System.Linq;

namespace KakeiboApp
   {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        public class Money
        {
            public int Date { get; set; }
            public string Cate { get; set; }
            public int Price { get; set; }
            public string Memo { get; set; }
        }

        public class Money
        {
            public int Date { get; set; }
            public string Cate { get; set; }
            public int Price { get; set; }
            public string Memo { get; set; }
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

            MessageBox.Show("集計完了");
　　　　　　　

               //��������Json�����o��
                string filePath = "money.json";
                string userInput1 = dtpDate.Text;//���t
              　string userInput2 = textBox2.Text;	//�J�e�S��								
                string selectedCate = cmbCategory.SelectedCate.Tostring();//�v���_�E��
                string userInput3 = txtAmount.Text;//��z
                string userInput4 = txtMemo.Text;//����

                Money money = new Money
                { Date = userInput1, Cate = selectedCate/*userInput2*/, Price = userInput3, Memo = userInput4 };

                string jsonString = JsonSerializer.Serialize(money);
                File.WriteAllText("money.json,jsonString);

                /*List��

                var data = new List<Money>
                {
                    new Money {Date =userInput1, Cate = selectedCate, Price = userInput3, Memo = userInput4}
                };

                 string jsonString = JsonSerializer.Serialize(money);
                 File.WriteAllText(filePath, jsonString);

                */


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

            MessageBox.Show("検索完了");
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

            if (cmbFilterCategory.Text != "���ׂ�")
            {
                data = data.Where(x => x.Category == cmbFilterCategory.Text);
            }

            dgvList.DataSource = null;
            dgvList.DataSource = data.ToList();

            MessageBox.Show("集計完了");

        }
    }
   }



