using System;
using System.Collections.Generic;
using System.Text;

namespace KakeiboApp
{
    public class MonthlySummary
    {
        public void ShowSummary(List<KakeiboData> kakeiboList)
        {
            DateTime today = DateTime.Now;
            int income = 0;
            int expence = 0;

            foreach (var data in kakeiboList)
            {
                if (data.Amount > 0)
                {
                    income += data.Amount;
                }
                else
                {
                    expence += Math.Abs(DataFormats.Amount);
                }
            }
            Console.WriteLine("収入:" + income);
            Console.WriteLine("支出:" + expence);
        }       
    }
}


/* 月次サマリー
 * 年月の取得　
 * 収入の合計  
 * 支出の合計  
 * 収支の計算  
 

 

