using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_budget
{
    public class TransactionType
    {
        public string TypeOperation { get; private set; }

        public TransactionType() : this("")
        {

        }
        public TransactionType(string type)
        {
            //if (string.IsNullOrWhiteSpace(TypeOperation))
            //{
                TypeOperation = type;
                //if (type == "доход" || type == "расход") TypeOperation = type;
                //else throw new Exception("Неверный тип транзакции.");
            //}
        }

        public static TransactionType Income = new TransactionType("доход");
        public static TransactionType Expense = new TransactionType("расход");

        public static TransactionType Parse(string type)
        {
            if (type == Income.TypeOperation) return Income;
            if (type == Expense.TypeOperation) return Expense;
            throw new Exception("Неверный тип транзакции.");
        }
    }

    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public TransactionType Type { get; set; }
        public string Comment { get; set; }
        //public static List<Transaction> transactions = null;
        //public void Remove()
        //{
        //    Program prog=new Program();
        //    tran.Remove(this.Id);
        //}
        public void TransactionInfo()
        {
            Console.WriteLine($"id:{Id}   Дата: {Date}, Цена: {Amount}, Категория: {Category},Тип: {Type.TypeOperation}, Коментарии: {Comment}");
        }
    }
}
