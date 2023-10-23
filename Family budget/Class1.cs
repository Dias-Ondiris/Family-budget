using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_budget
{
    public class Super
    {
        static string path = @"C:\temp\transactions.db";
        public static TransactionRepository repository = new TransactionRepository(path);
        public List<Transaction> data = repository.GetAllTransaction();

        public void GetTransactions()
        {
            try
            {
                data = repository.GetAllTransaction();
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Транзакция {ex.Message}");
                
            }
        }

        public void Add(Transaction transaction)
        {
            //data=Add(transaction);
            //TransactionRepository repository = new TransactionRepository("C:/temp/transactions.db");
            repository.CreateTransaction(transaction);
            data = repository.GetAllTransaction();
            Budget.CheckBudgetStatus();
        }
        public void Remove(Transaction transaction)
        {
            //data.Remove(transaction);
            //TransactionRepository repository = new TransactionRepository("C:/temp/transactions.db");
            repository.DeleteTransaction(transaction.Id);
            data = repository.GetAllTransaction();
        }
        public void Remove(int id)
        {
            data.Remove(GetId(id));
            //TransactionRepository repository = new TransactionRepository("C:/temp/transactions.db");
            repository.DeleteTransaction(id);
        }
        public Transaction GetId(int id)
        {
            return data.FindAll(t => t.Id == id).FirstOrDefault();
        }
        public List<Transaction> GetAllTransactions()
        {
            repository.GetAllTransaction();
            return data.OrderBy(d => d.Date).OrderBy(d => d.Category).ToList();
        }
        public List<Transaction> GetAllTransactionsByDate()
        {
            return data.OrderBy(d => d.Date).ToList();
        }
        public List<Transaction> GetAllTransactionsByCategory()
        {
            return data.OrderBy(d => d.Category).ToList();
        }
        public double CalculateTotalByType(TransactionType type, DateTime startDate, DateTime endDate)
        {
            return data
                .Where(t => t.Type.TypeOperation == type.TypeOperation && t.Date >= startDate && t.Date <= endDate)
                .Sum(t => t.Amount);
        }
        public Dictionary<string, double> CalculateByCategory(TransactionType type, DateTime startDate, DateTime endDate)
        {
            return data
                .Where(t => t.Type == type && t.Date >= startDate && t.Date <= endDate)
                .GroupBy(t => t.Category)
                .ToDictionary(group => group.Key, group => group.Sum(t => t.Amount));
        }
        public Dictionary<string, double> CalculateByCategory(DateTime startDate, DateTime endDate)
        {
            return data
                .Where(t => t.Date >= startDate && t.Date <= endDate)
                .GroupBy(t => t.Category)
                .ToDictionary(group => group.Key, group => group.Sum(t => t.Amount));
        }
        public double CalculateByCategory(string category, TransactionType type, DateTime startDate, DateTime endDate)
        {
            return data
                .Where(t => t.Type == type && t.Category == category && t.Date >= startDate && t.Date <= endDate).Sum(t => t.Amount);
        }
        public double CalculateByCategory(string category, DateTime startDate, DateTime endDate)
        {
            return data
                .Where(t => t.Category == category && t.Date >= startDate && t.Date <= endDate).Sum(t => t.Amount);
        }
    }
}
