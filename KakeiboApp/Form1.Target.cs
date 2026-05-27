using System;
using System.Text.Json;
using System.IO;
using System.Linq;


namespace KakeiboApp
{
    public partial class Form1
    {
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
            lblCurrentExpense.Text = "現在の支出：" + currentExpense.ToString("#,##0") + "円";

            // 目標-支出合計
            decimal remain = monthlyGoal - currentExpense;

            if (remain > 0)
            {
                lblRemain.Text = "あと " + remain.ToString("#,##0") + "円 使えます";
            }
            else if (remain == 0)
            {
                lblRemain.Text = "予算ぴったりです";
            }
            else
            {
                lblRemain.Text = Math.Abs(remain).ToString("#,##0") + "円 予算オーバーです";
            }

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
        private void UpdateGoalDisplay()
        {
            if (File.Exists(goalFilePath)) // 目標設定があるか
            {
                string json = File.ReadAllText(goalFilePath); // jsonファイル読み込み

                GoalData goal = JsonSerializer.Deserialize<GoalData>(json);

                if (goal != null)
                {
                    txtGoal.Text = goal.GoalAmount.ToString(); // 目標金額表示

                    decimal currentExpense = kakeiboList
                        .Where(x =>
                            x.Date.Year == DateTime.Now.Year &&
                            x.Date.Month == DateTime.Now.Month &&
                            x.Inout == "支出")
                        .Sum(x => x.Price);
                    lblCurrentExpense.Text = "現在の支出：" + currentExpense.ToString("#,##0") + "円";

                    // 残り金額
                    decimal remain = goal.GoalAmount - currentExpense;

                    if (remain > 0)
                    {
                        lblRemain.Text = "あと " + remain.ToString("#,##0") + "円 使えます";
                    }
                    else if (remain == 0)
                    {
                        lblRemain.Text = "予算ぴったりです";
                    }
                    else
                    {
                        lblRemain.Text = Math.Abs(remain).ToString("#,##0") + "円 予算オーバーです";
                    }
                }
            }
        }
    }
}