using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TaskUIS.Contract;
using TaskUIS.Data;
using TaskUIS.Models;

namespace TaskUIS.Repository
{
	public class TransactionRepository:ITransactionRepository
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
        public async Task<IEnumerable<Transaction>> GetAllTransactionsByDateAsync(DateTime? startdate)
        {
            if (startdate == null)
            {
                throw new ArgumentNullException(nameof(startdate));
            }
            return await _context.Transactions
                .Where(t => DbFunctions.TruncateTime(t.Date) == DbFunctions.TruncateTime(startdate))
                .ToListAsync();
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
        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _context.Transactions.ToListAsync();
        }
        public async Task<List<TransactionDetail>> GetTransactionDetailsAsync(int transactionId)

        {
            var transaction = await _context.Transactions
                   .Include(t => t.TransactionDetails)
                    .Include(t => t.Products)
                .FirstOrDefaultAsync(t => t.Id == transactionId);

            if (transaction == null)
            {
                throw new KeyNotFoundException($"Transaction with ID {transactionId} not found.");
            }

            return transaction.TransactionDetails.ToList();
        }

    }
}