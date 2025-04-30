using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TaskUIS.Data;
using TaskUIS.Models;

namespace TaskUIS.Repository
{
	public class TransactionRepository
	{
        private readonly ApplicationContext _context;
        public TransactionRepository(ApplicationContext context)
        {
            _context = context;
        }
      public async  Task AddTransactionAsync(Transaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }
       public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync(DateTime? StartTime, DateTime? EndTime)
        {
            var transactions = _context.Transactions.AsQueryable();
            if (StartTime.HasValue)
            {
                transactions = transactions.Where(t => t.Date >= StartTime.Value);
            }
            if (EndTime.HasValue)
            {
                transactions = transactions.Where(t => t.Date <= EndTime.Value);
            }
            return await transactions.ToListAsync();
        }
       public async Task<Transaction> GetTransactionByIdAsync(int transactionId)
        {
            var transaction = await _context.Transactions.FindAsync(transactionId);
            if (transaction == null)
            {
                throw new KeyNotFoundException($"Transaction with ID {transactionId} not found.");
            }
            return transaction;
        }
    }
}