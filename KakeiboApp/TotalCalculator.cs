using System;
using System.Collections.Generic;
using System.Text;


namespace KakeiboApp
{
    public class MonthlySummary
    {
        public int Income { get; set; }
        public int Expense { get; set; }

        public void Calculate(List<KakeiboData> kakeiboList)
        {
           
            DateTime today = DateTime.Now;

            Income = 0;
            Expense = 0;
            

            foreach (var data in kakeiboList)
            {
                if (data.Date.Year == today.Year &&
                    data.Date.Month == today.Month)
                {
                    if (data.Amount > 0)
                    {
                        Income += data.Amount;
                    }
                    else
                    {
                        Expense += Math.Abs(data.Amount);
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


/* 月次サマリー
 * 年月の取得　
 * 収入の合計  
 * 支出の合計  
 * 収支の計算  
 

 

