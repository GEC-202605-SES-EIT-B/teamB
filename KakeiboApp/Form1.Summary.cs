using System;
using System.Text.Json;
using System.Drawing;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace KakeiboApp
{
    public partial class Form1
    {
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

            UpdateMonthlySummary();
        }
        // 月次サマリー　自動更新メゾット
        private void UpdateMonthlySummary()
        {
            if (!File.Exists(filePath)) //money.jsonファイルの存在確認
            {
                return;
            }
            string jsonString = File.ReadAllText(filePath); // jsonファイル読み込み

            var moneyList = JsonSerializer.Deserialize<List<Money>>(jsonString); // jsonからlistに変換
            if (moneyList == null) //　変換に失敗したら終了
            {
                return;
            }
            var summary = new MonthlySummary(); // 集計クラス作成
            summary.Calculate(moneyList, dtpMonth.Value.Year, dtpMonth.Value.Month);
            // label表示
            lblIncome.Text = "収入：" + summary.Income.ToString("#,##0") + "円";
            lblExpense.Text = "支出：" + summary.Expense.ToString("#,##0") + "円";
            lblIBalance.Text = "差額；" + summary.Balance.ToString("#,##0") + "円";

            // 円グラフ
            chart1.Series.Clear(); // 初期化
            chart1.Legends.Clear();

            Series series = new Series(); // グラフデータ作成

            series.ChartType = SeriesChartType.Pie;
            series["PieStartAngle"] = "270";

            series.Points.AddXY("収入", summary.Income);
            series.Points.AddXY("支出", summary.Expense);

            series.Points[0].Color = Color.RoyalBlue;
            series.Points[1].Color = Color.Orange;

            chart1.Series.Add(series); // 円グラフ表示

            // カテゴリ別棒グラフ
            chart2.Series.Clear(); // 初期化

            Series barSeries = new Series("カテゴリ別");

            barSeries.ChartType = SeriesChartType.Column;
            barSeries.Color = Color.Orange;
            chart2.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
            chart2.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Meiryo", 8);
            chart2.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Meiryo", 8);

            barSeries.IsXValueIndexed = true;
            barSeries.Font = new Font("Meiryo", 7);

            foreach (var item in summary.CategoryTotals) // 給与以外の支出を表示
            {
                if (item.Key == "給与")
                {
                    continue;
                }
                int pointIndex = barSeries.Points.AddY(item.Value);

                barSeries.Points[pointIndex].AxisLabel = item.Key;
                barSeries.Points[pointIndex].Label = item.Value.ToString("#,##0円");
            }


            chart2.Series.Add(barSeries); // 棒グラフ表示
        }
    }
}
