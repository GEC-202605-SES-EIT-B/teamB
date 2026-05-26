using System.Linq;
using System.IO;
using System.Text.Json;
using System.Drawing.Text;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data;

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

        /*
      
            DataTable dt = createData();

            dgvList.RowTemplate.Height = 30;

            dgvList.RowTemplate.DefaultCellStyle.Padding = new Padding(5);

            dgvList.DataSource = dt;

            dgvList.Columns["Date"].HeaderText = "日付";
            dgvList.Columns["Cate"].HeaderText = "カテゴリ";
            dgvList.Columns["Inout"].HeaderText = "収入/支出";
            dgvList.Columns["Price"].HeaderText = "金額";
            dgvList.Columns["Memo"].HeaderText = "メモ";

            dgvList.EnableHeadersVisualStyles = false;//Visualスタイルを使用しない

            dgvList.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;//列ヘッダーの背景色
            dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightSalmon;//列ヘッダーの文字色

            dgvList.RowHeadersVisible = false;//行ヘッダーを非表示
            dgvList.ColumnHeadersVisible = true;//列ヘッダーを表示

            dgvList.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;//列ヘッダーの高さを固定

            dgvList.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;//行ヘッダーの幅を固定

            dgvList.ColumnHeadersHeight = 30;//列ヘッダーの高さを30に設定

            dgvList.Columns["Date"].HeaderCell.Style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;//列ヘッダーの文字(Data)を中央揃え

            dgvList.Columns["Cate"].HeaderCell.Style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;//列ヘッダーの文字(Cate)を中央揃え

            dgvList.Columns["Inout"].HeaderCell.Style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;//列ヘッダーの文字(Inout)を中央揃え

            dgvList.Columns["Price"].HeaderCell.Style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;//列ヘッダーの文字(Price)を中央揃え

            dgvList.Columns["Memo"].HeaderCell.Style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;//列ヘッダーの文字(Memo)を中央揃え

            dgvList.AllowUserToAddRows = false;//ユーザーによる行の追加を禁止
            dgvList.AllowUserToDeleteRows = false;//ユーザーによる行の削除を禁止
            dgvList.MultiSelect = false;//複数行の選択を禁止
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//行全体を選択するモードに設定
            dgvList.AllowUserToResizeColumns = true;//ユーザーによる列のサイズ変更を許可
            dgvList.AllowUserToResizeRows = false;//ユーザーによる行のサイズ変更を禁止
            dgvList.ReadOnly = true;//ユーザーによるセルの編集を禁止

            dgvList.Columns["Date"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;//Date列のセルの文字を左揃え

            dgvList.Columns["Cate"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;//Cate列のセルの文字を中央揃え

            dgvList.Columns["Inout"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;//Inout列のセルの文字を中央揃え

            dgvList.Columns["Price"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;//Price列のセルの文字を右揃え

            dgvList.Columns["Memo"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;//Memo列のセルの文字を左揃え

            dgvList.Columns["Date"].Width = 100;//Date列の幅を100に設定
            dgvList.Columns["Cate"].Width = 100;//Cate列の幅を100に設定
            dgvList.Columns["Inout"].Width = 100;//Inout列の幅を100に設定
            dgvList.Columns["Price"].Width = 100;//Price列の幅を100に設定
            dgvList.Columns["Memo"].Width = 200;//Memo列の幅を200に設定

            dgvList.ClearSelection();//選択状態を解除

        
              */



        private DataTable createData()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Cate", typeof(string));
            dt.Columns.Add("Inout", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("Memo", typeof(string));

            foreach (var item in kakeiboList)
            {
                dt.Rows.Add(item.Date, item.Cate, item.Inout, item.Price, item.Memo);
            }
            return dt;

        }

        private void csvButton_Click(object sender, EventArgs e)//CSV出力
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

            using (StreamWriter sw = new StreamWriter(FILE_PATH, false, System.Text.Encoding.Default))
            {
                string s = "";

                for (int iCol = 0; iCol < dgvList.ColumnCount; iCol++)
                {
                    string sCell = dgvList.Columns[iCol].HeaderCell.Value.ToString();

                    if (iCol > 0)
                    {
                        s += ",";
                    }

                    s += quoteCommaCheck(sCell);

                    sw.WriteLine(s);
                }

                int maxRowCount = dgvList.RowCount;
                if (dgvList.AllowUserToAddRows)
                {
                    maxRowCount -= 1;//追加行が含まれているため、行数を1減らす
                }

                for (int iRow = 0; iRow < maxRowCount; iRow++)
                {
                    s = "";
                    for (int iCol = 0; iCol < dgvList.Columns.Count; iCol++)
                    {
                        string sCell = dgvList[iCol, iRow].Value?.ToString() ?? "";

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
            if (sCell.Contains(",") || sCell.Contains("\"") || sCell.Contains("\n"))
            {
                sCell = sCell.Replace("\"", "\"\"");//ダブルクォーテーションをエスケープ
                sCell = $"\"{sCell}\"";//文字列全体をダブルクォーテーションで囲む
            }
            return sCell;

        }
    }
}
