using System;
using System.IO;
using System.Text.Json;

public class Money
{
	public int Date {get; set; }
	public string Cate {get; set; }
	public int Price {get; set; }
	public string Memo {get; set; }
}


class Program
{
	static void Main()
	{
		string userInput1 = textBox1.Text;//日付
		string userInput2 = textBox2.Text;//カテゴリ
      /*ドロップダウン処理
		string selectedCate = comboBox1.SelectedCate.Tostring();
	　*/
        string userInput3 = textBox3.Text;//金額
		string userInput4 = textBox4.Text;//メモ

		Money money = new Money 
		{Date = userInput1, Cate = userInput2/*selectedCate*/　, Price = userInput3, Memo = userInput4};

		string jsonString = JsonSerializer.Serialize(money);
		File.WriteAllText("money.json,jsonString);

		Console.WriteLine("保存完了");
	}
}
