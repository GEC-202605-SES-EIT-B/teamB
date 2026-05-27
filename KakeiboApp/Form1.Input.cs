using System.Text.Json;

namespace KakeiboApp
{
    public partial class Form1
    {
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
                Inout = cmbInout.Text,
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

            UpdateMonthlySummary();
            UpdateGoalDisplay();

            txtAmount.Text = "";
            txtMemo.Text = "";
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
            UpdateMonthlySummary();
            UpdateGoalDisplay();
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

        private void btnAddCategory_Click(object sender, EventArgs e)
        {

            string newCategory = txtNewCategory.Text.Trim();

            if (string.IsNullOrEmpty(newCategory))
            {
                MessageBox.Show("カテゴリを入力してください");
                return;
            }

            // 重複チェック
            if (!categoryList.Contains(newCategory))
            {
                categoryList.Add(newCategory);
                cmbCategory.Items.Add(newCategory);
                cmbFilterCategory.Items.Add(newCategory);
                cmbDeleteCategory.Items.Add(newCategory);
                var json = JsonSerializer.Serialize(categoryList);
                File.WriteAllText(categoryFile, json);
                MessageBox.Show("追加完了！");
            }
            else
            {
                MessageBox.Show("そのカテゴリは既にあります");
            }

            txtNewCategory.Text = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string selected = cmbDeleteCategory.Text;

            if (string.IsNullOrEmpty(selected))
            {
                MessageBox.Show("削除するカテゴリを選択してください");
                return;
            }

            // 確認
            var result = MessageBox.Show("カテゴリを削除しますか？", "確認", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                return;

            // カテゴリListから削除
            categoryList.Remove(selected);

            //コンボボックスから削除
            cmbCategory.Items.Remove(selected);
            cmbFilterCategory.Items.Remove(selected);
            cmbDeleteCategory.Items.Remove(selected);

            //データからも削除（重要）
            kakeiboList.RemoveAll(x => x.Cate == selected);

            File.WriteAllText(categoryFile, JsonSerializer.Serialize(categoryList));
            File.WriteAllText(filePath, JsonSerializer.Serialize(kakeiboList));

            //一覧更新
            dgvList.DataSource = null;
            dgvList.DataSource = kakeiboList;

            cmbDeleteCategory.SelectedIndex = -1;
            cmbDeleteCategory.Text = "";

            MessageBox.Show("カテゴリ削除完了");
        }
    }
}
