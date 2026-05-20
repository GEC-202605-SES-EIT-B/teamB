using System;
using System.Collections.Generic;
using System.Text;


namespace KakeiboApp
{
    public class MonthlySummary
    {
        public int Income { get; set; }
        public int Expense { get; set; }

        public void Calculate(int year,int month)
        { 
            Income = 0;
            Expense = 0;
            
            foreach (var data in AppData.Items)
            {
                if (data.Date.Year == year &&
                    data.Date.Month == month)
                {
                    if (data.Amount > 0)
                    {
                        Income += (int) data.Amount;
                    }
                    else
                    {
                        Expense += Math.Abs((int) data.Amount);
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