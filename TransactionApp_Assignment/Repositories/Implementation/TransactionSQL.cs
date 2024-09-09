using Microsoft.EntityFrameworkCore;
using TransactionApp_Assignment.Data;
using TransactionApp_Assignment.Models;
using TransactionApp_Assignment.Repositories.Interface;

namespace TransactionApp_Assignment.Repositories.Implementation
{
    public class TransactionSQL : ITransaction
    {
        private readonly TransactionDbContext dbContext;

        public TransactionSQL(TransactionDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddTransaction(OfficeTransactionDTO transaction)
        {
            var transactionNew = new OfficeTransactionModel
            {
                Id = Guid.NewGuid(),
                Description = transaction.Description,
                Date = DateTime.Now
            };
            var lastTransaction = await dbContext.officeTransactions.OrderByDescending(x => x.Date).FirstOrDefaultAsync();

            if (transaction.TransactionType == "Credit")
            {
                transactionNew.Credit = transaction.Amount;
                transactionNew.runningBalance = (lastTransaction?.runningBalance ?? 0) + transaction.Amount;

            }
            else if(transaction.TransactionType == "Debit")
            {
                transactionNew.Debit = transaction.Amount;
                transactionNew.runningBalance = (lastTransaction?.runningBalance ?? 0) - transaction.Amount;

            }

            await dbContext.officeTransactions.AddAsync(transactionNew);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OfficeTransactionModel>> GetTransactionModel()
        {
            return await dbContext.officeTransactions.OrderByDescending(x => x.Date).ToListAsync();
        }
    }
}
