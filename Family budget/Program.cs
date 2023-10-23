using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_budget
{

    public class Program
    {
        public static Super tran = new Super();
        public static void AddTransaction()
        {
            DateTime date;
            do
            {
                try
                {
                    Console.WriteLine("Введите дату транзакции (yyyy-MM-dd):");
                    date = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch { }
            } while (true);
            double amount;
            do
            {
                try
                {
                    Console.WriteLine("Введите сумму:");
                    amount = double.Parse(Console.ReadLine());
                    break;
                }
                catch { }
            } while (true);
            Console.WriteLine("Введите категорию:");
            string category = Console.ReadLine();
            TransactionType type;
            do
            {
                try
                {
                    Console.WriteLine("Тип операции (доход/расход):");
                    type = TransactionType.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

            } while (true);
            Console.WriteLine("Введите комментарий:");
            string comment = Console.ReadLine();
            Transaction transaction = new Transaction()
            {
                Date = date,
                Amount = amount,
                Category = category,
                Type = type,
                Comment = comment
            };
            tran.Add(transaction);
        }
        public static void PrintAllTransactions()
        {
            List<Transaction> transactions = tran.GetAllTransactions();
            if (transactions != null)
            {
                foreach (Transaction transaction in transactions)
                {
                    transaction.TransactionInfo();
                }
            }
        }
        static void ShowMenu()
        {
            Console.WriteLine("Меню учета семейного бюджета:");
            Console.WriteLine("1. Добавить транзакцию");
            Console.WriteLine("2. Показать все транзакции");
            Console.WriteLine("3. Проверить статус бюджета");
            Console.WriteLine("4. Загрузить транзакции из файла");
            Console.WriteLine("5. Изменить лимит");
            Console.WriteLine("6. Удалить транзакцию по id");
            Console.WriteLine("7. Выход");
        }
        static void Main(string[] args)
        {
            //tran.repository = new TransactionRepository(path);
            //if (tran.GetTransactions()) { Console.WriteLine("Начнем"); };
            tran.GetTransactions();
            int Limit;
            do
            {
                try
                {
                    Console.WriteLine("Введите лимит  в этот месец:");
                    Limit = int.Parse(Console.ReadLine());
                    break;
                }
                catch { }
            } while (true);
            Budget.Month = DateTime.Now;
            Budget.MonthlyLimit = Limit;

            while (true)
            {
                ShowMenu();

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTransaction();
                        break;
                    case "2":
                        PrintAllTransactions();
                        break;
                    case "3":
                        Budget.CheckBudgetStatus();
                        break;
                    case "4":
                        tran.GetTransactions();
                        //if(tran.GetTransactions()) 
                            Console.WriteLine("Транзакции загружены из файла.");
                        //else Console.WriteLine("Транзакции не загружены из файла.");
                        break;
                    case "5":
                        do
                        {
                            try
                            {
                                Console.WriteLine("Введите лимит:");
                                Limit = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch { }
                        } while (true);
                        Budget.MonthlyLimit = Limit;
                        Console.WriteLine("Лимит изменен.");
                        break;
                    case "6":
                        int id;
                        do
                        {
                            try
                            {
                                Console.WriteLine("Введите id транзакции:");
                                id = int.Parse(Console.ReadLine());
                                if (tran.GetId(id) != null) tran.Remove(id);
                                else Console.WriteLine("Транзакция не найдена:");
                                break;
                            }
                            catch { }
                        } while (true);
                        break;
                    case "7":
                        return; 
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте еще раз.");
                        break;
                }
            }

            //Console.ReadKey();
        }
    }
}
