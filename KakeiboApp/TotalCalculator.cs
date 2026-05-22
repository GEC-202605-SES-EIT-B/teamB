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

        public void Calculate(List<Money> moneyList, int year,int month)
        { 
            Income = 0;
            Expense = 0;
            
            foreach (var data in moneyList)
            {
                if (data.Date.Year == year &&
                    data.Date.Month == month)
                {
                    if (data.Price > 0)
                    {
                        Income += (int) data.Price;
                    }
                    else
                    {
                        Expense += Math.Abs((int) data.Price);
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