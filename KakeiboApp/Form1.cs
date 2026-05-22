using System.Linq;
using System.IO;
using System.Text.Json;

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
            public DateTime Date { get; set; }
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

            /*
            string filePath = "money.json";
            DateTime userInput1 = dtpDate.Value;
            string selectedCate = cmbCategory.SelectedCate.Tostring();
            int userInput3 = decimal.Parse(txtAmount.Text), //txtAmount.Text;
            string userInput4 = txtMemo.Text;
          
            Money money = new Money
            { Date = userInput1, Cate = selectedCate, Price = userInput3, Memo = userInput4 };
            */

            Money money = new Money
            { Date = dtpDate.Value, Cate = cmbCategory.Text, Price = decimal.Parse(txtAmount.Text), Memo = txtMemo.Text };

            string jsonString = JsonSerializer.Serialize(money);
            File.WriteAllText("money.json",jsonString);

                
                /*Listver

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

            //Jsonファイル読み込み
            /*
            string jsonstring = File.ReadAllText("money.json");
            Money money = JsonSerializer.Deserialize<Money>(jsonstring);

            var kakeiboList = new List<money>();

            kakeiboList.Add({ money.Date});
            kakeiboList.Add({ money.Cate});
            kakeiboList.Add({ money.Price});
            kakeiboList.Add({ money.Memo});

            MessageBox.Show("読み込み完了");
            */
            //Jsonファイル読み込み(予備)

            string filePath = "money.json";

            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("ファイルが存在しません。");
                    return;
                }

                string readJson = File.ReadAllText(filePath);
                var loadedMoney = JsonSerializer.Deserialize<List<Money>>(readJson);

                if (loadedMoney != null)
                {
                    MessageBox.Show("読み込み完了:");
                   
            
                    /*
                    foreach (var kakeibo in loadedMoney)
                    {
                        Console.WriteLine($"Date: {kakeibo.Date}, Cate: {kakeibo.Cate},Price: {kakeibo.Price},Memo: {kakeibo.Memo}");
                    }
                    */
                }
                else
                {
                    MessageBox.Show("データが空です");
                }
            }
            
            catch (JsonException jex)
            {
                    MessageBox.Show($"JSON形式エラー: {jex.Message}");
            }
            
            catch (Exception ex)
            {
                    MessageBox.Show($"読み込みエラー: {ex.Message}");
            }
            


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
            /*
            //Jsonファイル読み込み
            string jsonstring = File.ReadAllText("money.json");
            Money money = JsonSerializer.Deserialize<Money>(jsonstring);

            var kakeiboList = new List<money>();

            kakeiboList.Add({ money.Date});
            kakeiboList.Add({ money.Cate});
            kakeiboList.Add({ money.Price});
            kakeiboList.Add({ money.Memo});

            MessageBox.Show("読み込み完了");
            */
            //Jsonファイル読み込み(予備)

            string filePath = "people.json";
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("ファイルが存在しません。");
                    return;
                }

                string readJson = File.ReadAllText(filePath);
                var loadedMoney = JsonSerializer.Deserialize<List<Money>>(readJson);

                if (loadedMoney != null)
                {
                    MessageBox.Show("読み込み完了:");
                   
                    /*
                    foreach (var kakeibo in loadedMoney)
                    {
                        Console.WriteLine($"Date: {kakeibo.Date}, Cate: {kakeibo.Cate},Price: {kakeibo.Price},Memo: {kakeibo.Memo}");
                    }
                    */
                }
                else
                {
                    MessageBox.Show("データが空です");
                }
            }
            
            catch (JsonException jex)
            {
                    MessageBox.Show($"JSON形式エラー: {jex.Message}");
            }
            
            catch (Exception ex)
            {
                    MessageBox.Show($"読み込みエラー: {ex.Message}");
            }
            



        }
    }
   }



