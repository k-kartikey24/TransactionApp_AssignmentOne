using System.Collections;
using TransactionApp_Assignment.Models;

namespace TransactionApp_Assignment.Repositories.Interface
{
    public interface ITransaction
    {
        Task<IEnumerable<OfficeTransactionModel>> GetTransactionModel();
        Task AddTransaction(OfficeTransactionDTO transaction);

    }
}
