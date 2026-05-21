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

            MessageBox.Show("ìoò^äÆóπ");

            //Ç±Ç±Ç©ÇÁJsonèëÇ´èoÇµ
                string filePath = "money.json";
                string userInput1 = dtpDate.Text;//ì˙ït
              //string userInput2 = textBox2.Text;	//ÉJÉeÉSÉä								
                string selectedCate = cmbCategory.SelectedCate.Tostring();//ÉvÉãÉ_ÉEÉì
                string userInput3 = txtAmount.Text;//ã‡äz
                string userInput4 = txtMemo.Text;//ÉÅÉÇ

                Money money = new Money
                { Date = userInput1, Cate = selectedCate/*userInput2*/, Price = userInput3, Memo = userInput4 };

                string jsonString = JsonSerializer.Serialize(money);
                File.WriteAllText("money.json,jsonString);

                /*Listï“

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
    }
}
