using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
namespace Family_budget
{
    public class TransactionRepository
    {
        private readonly string Path;
        public TransactionRepository(string path)
        {
            Path = path;
        }

        public bool CreateTransaction(Transaction transaction)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var transactions = db.GetCollection<Transaction>("Transaction");
                    transactions.Insert(transaction);
                }
                Console.WriteLine("Транзакция успешна добавлена");
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateTransaction(Transaction transaction)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var transactions = db.GetCollection<Transaction>("Transaction"); ;
                    transactions.Update(transaction);
                }
                Console.WriteLine("Транзакция успешна изменена");
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteTransaction(int transactionid)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var transactions = db.GetCollection<Transaction>("Transaction");
                    transactions.Delete(transactionid);
                }
                Console.WriteLine("Транзакция успешна удалена");
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Transaction> GetAllTransaction()
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var col = db.GetCollection<Transaction>("Transaction").FindAll();
                    var data = col.ToList();
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
                return null;
            }
        }

        public List<Transaction> GetTransactionByCotegory(string category)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var col = db.GetCollection<Transaction>("Transaction").FindAll().Where(q => q.Category == category);
                    return col.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Transaction GetTransactionByID(int id)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var col = db.GetCollection<Transaction>("Transaction").FindById(id);
                    return col;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}