using System;
using System.IO;
using System.Text.Json;


namespace KakeiboApp
{

	public class Money
	{
		public int Date { get; set; }
		public string Cate { get; set; }
		public int Price { get; set; }
		public string Memo { get; set; }
	}


	class Program
	{
		static void Save()
		{
			string filePath = "money.json";

			
			string userInput1 = dtpDate.Text;//日付
			//string userInput2 = textBox2.Text;	//カテゴリ								
			string selectedCate = cmbCategory.SelectedCate.Tostring();//プルダウン
			string userInput3 = txtAmount.Text;//金額
			string userInput4 = txtMemo.Text;//メモ

			Money money = new Money
			{ Date = userInput1, Cate = selectedCate/*userInput2*/, Price = userInput3, Memo = userInput4 };

			string jsonString = JsonSerializer.Serialize(money);
			File.WriteAllText("money.json,jsonString);

			Console.WriteLine("保存完了");

			/*List編
			
			var data = new List<Money>
			{
				new Money {Date =userInput1, Cate = selectedCate, Price = userInput3, Memo = userInput4}
			};
		
             string jsonString = JsonSerializer.Serialize(money);
             File.WriteAllText(filePath, jsonString);
             Console.WriteLine($"JSONファイルに書き出しました: {filePath}");

			*/

			//Jsonファイル読み込み
			string jsonstring = File.ReadAllText("money.json");
			Money money = JsonSerializer.Deserialize<Money>(jsonstring);

			var kakeiboList = new List<money>();

			kakeiboList.Add({ money.Date});
            kakeiboList.Add({ money.Cate});
            kakeiboList.Add({ money.Price});
            kakeiboList.Add({ money.Memo});

			Console.WriteLine("読み込み処理完了");

            /*Jsonファイル読み込み(予備)
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("ファイルが存在しません。");
                    return;
                }

                string readJson = File.ReadAllText(filePath);
                var loadedMoney = JsonSerializer.Deserialize<List<Money>>(readJson);

                if (loadedMoney != null)
                {
                    Console.WriteLine("読み込み完了:");
                    foreach (var kakeibo in loadedMoney)
                    {
                        Console.WriteLine($"Date: {kakeibo.Date}, Cate: {kakeibo.Cate},Price: {kakeibo.Price},Memo: {kakeibo.Memo}");
                    }
                }
                else
                {
                    Console.WriteLine("データが空です。");
                }
            }
            
            catch (JsonException jex)
            {
                    Console.WriteLine($"JSON形式エラー: {jex.Message}");
            }
            
            catch (Exception ex)
            {
                    Console.WriteLine($"読み込みエラー: {ex.Message}");
            }
            */
        }
    }
}
