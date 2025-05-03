using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUIS.Models;

namespace TaskUIS.Contract
{
   public interface ITransactionRepository
    {
        Task AddTransactionAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetAllTransactionsByDateAsync(DateTime? StartTime);
        Task<Transaction> GetTransactionByIdAsync(int transactionId);
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
        Task<List<TransactionDetail>> GetTransactionDetailsAsync(int transactionId);

    }
}
