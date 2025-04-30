using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskUIS.Contract;
using TaskUIS.Models;
using TaskUIS.Repository;
using System.Threading.Tasks;
namespace TaskUIS.Services
{
	public class TransactionService
	{
        private readonly ITransactionRepository _ItransactionRepository;
        public TransactionService(ITransactionRepository ItransactionRepository)
        {
            _ItransactionRepository = ItransactionRepository;
        }
        public async Task AddTransactionAsync(Transaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }
            await _ItransactionRepository.AddTransactionAsync(transaction);

        }
        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync(DateTime? StartTime, DateTime? EndTime)
        {
            return await _ItransactionRepository.GetAllTransactionsAsync(StartTime, EndTime);
        }
        public async Task<Transaction> GetTransactionByIdAsync(int transactionId)
        {
            var transaction = await _ItransactionRepository.GetTransactionByIdAsync(transactionId);
            if (transaction == null)
            {
                throw new KeyNotFoundException($"Transaction with ID {transactionId} not found.");
            }
            return transaction;
        }

    }
}