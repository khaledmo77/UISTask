using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskUIS.Contract;
using TaskUIS.Models;
using TaskUIS.Repository;
using System.Threading.Tasks;
using TaskUIS.ViewModels;
namespace TaskUIS.Services
{
	public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _ItransactionRepository;
        public TransactionService(ITransactionRepository ItransactionRepository)
        {
            _ItransactionRepository = ItransactionRepository;
        }
        public async Task AddTransactionAsync(TransactionProductViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var transaction = new Transaction
            {
                Date = DateTime.Now,
                TotalPrice = model.Products.Sum(p => p.Quantity * p.UnitPrice),
                TransactionDetails = model.Products
                    .Where(p => p.Quantity > 0)
                    .Select(p => new TransactionDetail
                    {
                        ProductId = p.ProductId,
                        Quantity = p.Quantity,
                        UnitPrice = p.UnitPrice,
                        Total = p.Quantity * p.UnitPrice
                    }).ToList()
            };

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
        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _ItransactionRepository.GetAllTransactionsAsync();
        }

    }
}