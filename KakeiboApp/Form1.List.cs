using System;
using System.Text.Json;
using System.Linq;
using System.IO;


namespace KakeiboApp
{
    public partial class Form1
    {
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
            dgvList.DataSource = data.OrderBy(x => x.Date).ToList();

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
            UpdateMonthlySummary();
            UpdateGoalDisplay();
        }
    }
}