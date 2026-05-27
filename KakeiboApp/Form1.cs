using System.Data;
using System.Text.Json;

namespace KakeiboApp
{
    public partial class Form1 : Form
    {
        private List<Money> kakeiboList = new List<Money>();
        private Money editingItem = null;
        private List<string> categoryList = new List<string>();
        string categoryFile = "category.json";

        string filePath = "money.json";
        private string goalFilePath = "goal.json";

        public Form1()
        {
            InitializeComponent();

            // 起動時にjsonファイルの読み込み（データありなら保存ファイル読み込み）　
            if (File.Exists(filePath))
            {
                string readJson = File.ReadAllText(filePath);
                kakeiboList = JsonSerializer.Deserialize<List<Money>>(readJson);
            }

            if (File.Exists(categoryFile))
            {
                var json = File.ReadAllText(categoryFile);
                categoryList = JsonSerializer.Deserialize<List<string>>(json);

                if (categoryList != null)
                {
                    foreach (var c in categoryList)
                    {
                        if (!cmbCategory.Items.Contains(c))
                        {
                            cmbCategory.Items.Add(c);
                        }
                        if (!cmbFilterCategory.Items.Contains(c))
                        {
                            cmbFilterCategory.Items.Add(c);
                        }
                        if (!cmbDeleteCategory.Items.Contains(c))
                        {
                            cmbDeleteCategory.Items.Add(c);
                        }
                    }
                }

                if (kakeiboList != null)
                {
                    var categories = kakeiboList
                        .Select(x => x.Cate)
                        .Distinct();

                    foreach (var c in categories)
                    {

                        if (!cmbCategory.Items.Contains(c))
                        {
                            cmbCategory.Items.Add(c);
                        }
                    }
                }
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

        private void cmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // 起動時読み込み
        private void Form1_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false; //　画面起動時に更新ボタンは操作不可
            lblMontlyGoal.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月の支出目標";
            UpdateGoalDisplay();
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
                    maxRowsCount = maxRowsCount;//追加行が含まれているため、行数を1減らす
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
        private void cmbDeleteCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


