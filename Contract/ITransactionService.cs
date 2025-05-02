using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUIS.Models;
using TaskUIS.ViewModels;

namespace TaskUIS.Contract
{
   public interface ITransactionService
    {
        Task AddTransactionAsync(TransactionProductViewModel model);
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync(DateTime? startDate, DateTime? endDate);
        Task<Transaction> GetTransactionByIdAsync(int transactionId);
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
        

    }
}
