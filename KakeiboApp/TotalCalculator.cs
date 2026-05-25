using System;
using System.Collections.Generic;
using System.Text;
using static KakeiboApp.Form1;


namespace KakeiboApp
{
    public class MonthlySummary
    {
        public int Income { get; set; }
        public int Expense { get; set; }
        public Dictionary<string, int> CategoryTotals = new Dictionary<string, int>();

        public void Calculate(List<Money> moneyList, int year,int month)
        { 
            Income = 0;
            Expense = 0;

            CategoryTotals.Clear();

            foreach (var data in moneyList)
            {
                if (data.Date.Year == year &&
                    data.Date.Month == month)
                {
                    if (data.Inout == "収入")
                    {
                        Income += (int) data.Price;
                    }
                    else if (data.Inout == "支出")
                    {
                        Expense += (int) data.Price;

                        // カテゴリ別集計
                        if (!CategoryTotals.ContainsKey(data.Cate))
                        {
                            CategoryTotals[data.Cate] = 0;
                        }
                        CategoryTotals[data.Cate] += (int)Math.Abs(data.Price);
                    } 
                }
            }  
        }  
        public int Balance
        {  get
            {
                return Income - Expense;
            }   
        }
    }
}