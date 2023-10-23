using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_budget
{
    public class Budget
    {
        public static double MonthlyLimit { get; set; } 
        public static DateTime Month { get; set; }
        public static Super tran  = new Super();
        public static double CalculateTotalExpenses()
        {
            return tran.CalculateTotalByType(TransactionType.Expense, new DateTime(Month.Year, Month.Month, 1), new DateTime(Month.Year, Month.Month, DateTime.DaysInMonth(Month.Year, Month.Month)));
        }
        public static void CheckBudgetStatus()
        {

            // TransactionRepository.GetAllTransaction();
            double totalExpenses = CalculateTotalExpenses();
            if (totalExpenses > MonthlyLimit)
            {
                Console.WriteLine($"Остановись! Вы потратили уже {totalExpenses} из вашего месячного лимита в {MonthlyLimit}.Больше денег нет:(");
            }
            else if(totalExpenses > MonthlyLimit * 0.85)
            {
                Console.WriteLine($"Внимание! Вы потратили уже {totalExpenses} из вашего месячного лимита в {MonthlyLimit}.Тратьте с умом!!!");
            }
            else
            {
                Console.WriteLine($"Вы потратили {totalExpenses} из вашего месячного лимита в {MonthlyLimit}.");
            }
        }
    }

}
