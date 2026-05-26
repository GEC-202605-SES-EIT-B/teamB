using System.Linq;
using System.IO;
using System.Text.Json;
using System.Drawing.Text;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data;
using System.Configuration;
using System.Windows.Forms.Design;
using Microsoft.VisualBasic;

namespace KakeiboApp
{
    public partial class Form1 : Form
    {
        private List<Money> kakeiboList = new List<Money>();
        private Money editingItem = null;

        string filePath = "money.json";
        private string goalFilePath = "goal.json";

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
        public class GoalData
        {
            public int Year { get; set; }
            public int Month { get; set; }
            public decimal GoalAmount { get; set; }
        }

        private void btpAdd_Click(object sender, EventArgs e)
        {

            // 入力チェック
            if (string.IsNullOrWhiteSpace(txtAmount.Text) ||
                string.IsNullOrWhiteSpace(cmbCategory.Text) ||
                string.IsNullOrWhiteSpace(cmbInout.Text))
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

            string type = cmbFilterType.Text.Trim();

            if (type == "支出" || type == "収入")
            {
                data = data.Where(x => x.Inout == type);
            }
            if (string.IsNullOrWhiteSpace(cmbFilterCategory.Text))
            {
                MessageBox.Show("カテゴリを選択してください");
                return;
            }

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

            dgvList.DataSource = null;
            dgvList.DataSource = data.ToList();

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
            btnUpdate.Enabled = false; //　画面起動時に更新ボタンは操作不可

            lblMontlyGoal.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月の支出目標";


            if (File.Exists(goalFilePath)) // 目標設定があるか
            {
                string json =　File.ReadAllText(goalFilePath);

                GoalData goal =　JsonSerializer.Deserialize<GoalData>(json);

                if (goal != null)
                {
                    txtGoal.Text =　goal.GoalAmount.ToString();　//　目標金額表示

                    decimal currentExpense = kakeiboList
                        .Where(x =>
                            x.Date.Year == DateTime.Now.Year &&
                            x.Date.Month == DateTime.Now.Month &&
                            x.Inout == "支出")
                        .Sum(x => x.Price);

                    // 残り金額
                    decimal remain =　goal.GoalAmount - currentExpense;

                    lblCurrentExpense.Text = "現在の支出：" + currentExpense.ToString("#,##0") + "円";

                    lblRemain.Text = "残り予算：" + remain.ToString("#,##0") + "円";
                }
            }
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

        private void btnAddCategory_Click(object sender, EventArgs e)
        {

            string newCategory = txtNewCategory.Text.Trim();

            if (string.IsNullOrEmpty(newCategory))
            {
                MessageBox.Show("カテゴリを入力してください");
                return;
            }

            // 重複チェック
            if (!cmbCategory.Items.Contains(newCategory))
            {
                cmbCategory.Items.Add(newCategory);
                MessageBox.Show("追加完了！");
            }
            else
            {
                MessageBox.Show("そのカテゴリは既にあります");
            }

            txtNewCategory.Text = "";
        }

        // 入力画面　更新ボタン
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            // 入力チェック
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("金額を入力してください");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("カテゴリを選択してください");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbInout.Text))
            {
                MessageBox.Show("収入/支出を選択してください");
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("金額は半角数字で入力してください");
                return;
            }
            if (editingItem == null)
            {
                MessageBox.Show("編集データなし");
                return;
            }
            // 編集した情報をeditingItemへ保存
            editingItem.Date = dtpDate.Value;
            editingItem.Cate = cmbCategory.Text;
            editingItem.Inout = cmbInout.Text;
            editingItem.Price = decimal.Parse(txtAmount.Text);
            editingItem.Memo = txtMemo.Text;

            // 更新済みkakeiboListをjson保存
            var json = JsonSerializer.Serialize(kakeiboList);
            File.WriteAllText(filePath, json);

            // 一覧を再表示
            dgvList.DataSource = null;
            dgvList.DataSource = kakeiboList;

            // 編集モード終了
            editingItem = null;

            btpAdd.Enabled = true; // 登録可
            btnUpdate.Enabled = false;// 更新不可

            MessageBox.Show("更新完了");
            tabControl1.SelectedIndex = 1; // 一覧画面へ遷移
        }
        // 一覧画面　編集ボタン
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow == null)
            {
                MessageBox.Show("行を選択してください");
                return;
            }

            var selectedItem = dgvList.CurrentRow.DataBoundItem as Money;

            editingItem = kakeiboList.FirstOrDefault(x =>
                x.Date == selectedItem.Date &&
                x.Cate == selectedItem.Cate &&
                x.Price == selectedItem.Price &&
                x.Memo == selectedItem.Memo
            );

            if (editingItem == null)
            {
                MessageBox.Show("取得失敗");
                return;
            }

            // 選択した行の情報を入力欄へ表示
            dtpDate.Value = editingItem.Date;
            cmbCategory.Text = editingItem.Cate;
            cmbInout.Text = editingItem.Inout;
            txtAmount.Text = editingItem.Price.ToString();
            txtMemo.Text = editingItem.Memo;

            btpAdd.Enabled = false; //　登録不可
            btnUpdate.Enabled = true; // 更新可
            tabControl1.SelectedIndex = 0; // 入力画面へ遷移
        }





        private void csvButton_Click(object sender, EventArgs e)//CSV出力
        {

            SaveCsvFile();
        }




        private void SaveCsvFile()
        {
            const string FILE_PATH = "@kakeibo.csv";

            string msg = "";

            if (dgvList.RowCount <= 0)
            {
                msg = "出力するデータがありません。";
                MessageBox.Show(msg, "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            msg = "CSVファイルを出力しますか？";
            DialogResult result = MessageBox.Show(msg, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }

            using (StreamWriter sw = new StreamWriter(FILE_PATH, false, System.Text.Encoding.UTF8))
            {
                string s = "";

                for (int iCol = 0; iCol < dgvList.Columns.Count; iCol++)//行のループ
                {
                    String sCell = dgvList.Columns[iCol].HeaderCell.Value.ToString();

                    if (iCol > 0)
                    {
                        s += ",";
                    }

                    s += quoteCommaCheck(sCell);
                }

                sw.WriteLine(s);


                int maxRowsCount = dgvList.Rows.Count;
                if (dgvList.AllowUserToAddRows)
                {
                    maxRowsCount = maxRowsCount - 1;//追加行が含まれているため、行数を1減らす
                }

                for (int iRow = 0; iRow < maxRowsCount; iRow++)//行のループ
                {
                    s = "";

                    for (int iCol = 0; iCol < dgvList.Columns.Count; iCol++)//列のループ
                    {
                        string sCell = dgvList[iCol, iRow].Value.ToString();




                        if (iCol > 0)
                        {
                            s += ",";
                        }

                        s += quoteCommaCheck(sCell);
                    }
                    sw.WriteLine(s);
                }
            }
            msg = $"CSVファイルを出力しました。\n{FILE_PATH}";
            MessageBox.Show(msg, "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string quoteCommaCheck(string sCell)
        {

            const string QUOTE = @"""";//"
            const string COMMA = @",";//,

            string[] a = { QUOTE, COMMA };

            if (sCell.Contains(",") || sCell.Contains("\""))
            {
                sCell = sCell.Replace("\"", "\"\"");//ダブルクォーテーションをエスケープ
                sCell = $"\"{sCell}\"";//文字列全体をダブルクォーテーションで囲む
            }
            return sCell;
        }

        // 目標タブ　設定ボタン
        private void btnTargetSet_Click(object sender, EventArgs e)
        {
            // 入力金額のチェック
            if (!decimal.TryParse(txtGoal.Text, out decimal monthlyGoal))
            {
                MessageBox.Show("金額を入力してください");
                return;
            }

            //　今月の支出合計
            decimal currentExpense = kakeiboList
                .Where(x =>
                    x.Date.Year == DateTime.Now.Year &&
                    x.Date.Month == DateTime.Now.Month &&
                    x.Inout == "支出")
                .Sum(x => x.Price);

            // 目標-支出合計
            decimal remain = monthlyGoal - currentExpense;

            lblCurrentExpense.Text = "現在の支出：" + currentExpense.ToString("#,##0") + "円";
            lblRemain.Text = "残り予算：" + remain.ToString("#,##0") + "円";

            //　保存用データ
            GoalData goal = new GoalData()
            {
                Year = DateTime.Now.Year,
                Month = DateTime.Now.Month,
                GoalAmount = monthlyGoal
            };
            // json変換
            string json = JsonSerializer.Serialize(goal);
            File.WriteAllText(goalFilePath, json);
            MessageBox.Show("目標を設定しました");

        }
    }
}

