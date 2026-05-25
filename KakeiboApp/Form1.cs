using System.Linq;
using System.IO;
using System.Text.Json;
using System.Drawing.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace KakeiboApp
   {
    public partial class Form1 : Form
    {
        private List<Money> kakeiboList = new List<Money>();

        string filePath = "money.json";
        public Form1()
        {
            InitializeComponent();

            // 起動時にjsonファイルの読み込み（データありなら保存ファイル読み込み）　


            if (!File.Exists(filePath))
            {
                MessageBox.Show("初回起動");
                return;
            }
            string readJson = File.ReadAllText(filePath);
            kakeiboList = JsonSerializer.Deserialize<List<Money>>(readJson);

            if (kakeiboList != null)
            {
                MessageBox.Show("読み込み完了:");
            }
        }

        public class Money
        {
            public DateTime Date { get; set; }
            public string Cate { get; set; }
            public string Inout { get; set; }
            public Decimal Price { get; set; }
            public string Memo { get; set; }

        }

        private void btpAdd_Click(object sender, EventArgs e)
        {

            // 入力チェック
            if (string.IsNullOrWhiteSpace(txtAmount.Text) ||
                string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("無効です");
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("金額が不正です");
                return;
            }

            var item = new ExpenseItem
            {
                Date = dtpDate.Value,
                Category = cmbCategory.Text,
                Inout = cmbCategory.Text,
                Amount = decimal.Parse(txtAmount.Text),
                Memo = txtMemo.Text
            };

            AppData.Items.Add(item);

            MessageBox.Show("登録完了");



            kakeiboList.Add(
              new Money
              {
                  Date = dtpDate.Value,
                  Cate = cmbCategory.Text,
                  Inout = cmbInout.Text,
                  Price = decimal.Parse(txtAmount.Text),
                  Memo = txtMemo.Text
              }
             );

            var jsonString = JsonSerializer.Serialize(kakeiboList);
            File.WriteAllText(filePath, jsonString);

            txtAmount.Text = "";
            txtMemo.Text = "";

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

            var data = kakeiboList.Where(x =>
                x.Date.Date >= from &&
                x.Date.Date <= to
            );

            if (cmbFilterCategory.Text != "すべて")
            {
                data = data.Where(x => x.Cate == cmbFilterCategory.Text);
            }

            dgvList.DataSource = null;
            dgvList.DataSource = data.ToList();

            MessageBox.Show("検索完了");

            //Jsonファイル読み込み

            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("ファイルが存在しません。");
                    return;
                }

                string readJson = File.ReadAllText(filePath);
                kakeiboList = JsonSerializer.Deserialize<List<Money>>(readJson);


                if (kakeiboList != null)
                {
                    MessageBox.Show("読み込み完了:");
                    dgvList.DataSource = kakeiboList;

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
        // 月次サマリー　集計ボタン
        private void button1_Click(object sender, EventArgs e)
        {
            //Jsonファイル読み込み
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("ファイルが存在しません。");
                    return;
                }

                string readJson = File.ReadAllText(filePath);
                kakeiboList = JsonSerializer.Deserialize<List<Money>>(readJson);


                if (kakeiboList != null)
                {
                    MessageBox.Show("読み込み完了:");

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



            string jsonString = File.ReadAllText("money.json");
            var moneyList = JsonSerializer.Deserialize<List<Money>>(jsonString);
            var summary = new MonthlySummary();
            summary.Calculate(moneyList, dtpMonth.Value.Year, dtpMonth.Value.Month);

            lblIncome.Text = "収入：" + summary.Income.ToString("#,##0") + "円";
            lblExpense.Text = "支出：" + summary.Expense.ToString("#,##0") + "円";
            lblIBalance.Text = "差額；" + summary.Balance.ToString("#,##0") + "円";

            // 円グラフの表示
            chart1.Series.Clear();
            chart1.Legends.Clear();

            Series series = new Series();

            series.ChartType = SeriesChartType.Pie;
            series["PieStartAngle"] = "270";

            series.Points.AddXY("収入", summary.Income);
            series.Points.AddXY("支出", summary.Expense);

            series.Points[0].Color = Color.RoyalBlue;
            series.Points[1].Color = Color.Orange;

            chart1.Series.Add(series);

            // カテゴリ別棒グラフ
            chart2.Series.Clear();

            Series barSeries = new Series("カテゴリ別");

            barSeries.ChartType = SeriesChartType.Column;
            barSeries.Color = Color.Orange;
            chart2.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
            chart2.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Meiryo", 8);
            chart2.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Meiryo", 8);

            barSeries.IsXValueIndexed = true;
            barSeries.Font = new Font("Meiryo", 7);

            foreach (var item in summary.CategoryTotals)
            {

                if (item.Key == "給与")
                {
                    continue;
                }
                int pointIndex = barSeries.Points.AddY(item.Value);

                barSeries.Points[pointIndex].AxisLabel = item.Key;
                barSeries.Points[pointIndex].Label = item.Value.ToString("#,##0円");
            }


            chart2.Series.Add(barSeries);
        }

        private void cmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow == null)
            {
                MessageBox.Show("削除する行を選択してください");
                return;
            }

            // 今表示されているデータ取得
            var currentList = dgvList.DataSource as List<Money>;

            if (currentList == null)
            {
                MessageBox.Show("データ取得エラー");
                return;
            }

            int index = dgvList.CurrentRow.Index;

            if (index < 0 || index >= currentList.Count)
            {
                MessageBox.Show("削除対象が不正です");
                return;
            }

            var result = MessageBox.Show("削除しますか？", "確認", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                return;

            // 表示リストから削除
            var itemToRemove = currentList[index];
            currentList.RemoveAt(index);

            //元のリストからも削除
            kakeiboList.Remove(itemToRemove);

            //保存
            var json = JsonSerializer.Serialize(kakeiboList);
            File.WriteAllText(filePath, json);

            //再表示
            dgvList.DataSource = null;
            dgvList.DataSource = kakeiboList;

            MessageBox.Show("削除完了");
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)//関係ない
        {

        }

        private void cmbInout2_SelectedIndexChanged(object sender, EventArgs e)//一覧画面の入出金コンボボックス
        {

        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)//関係ない
        {

        }
    }
}




