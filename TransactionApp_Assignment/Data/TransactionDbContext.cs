using Microsoft.EntityFrameworkCore;
using TransactionApp_Assignment.Models;

namespace TransactionApp_Assignment.Data
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {
        }

        public DbSet<OfficeTransactionModel> officeTransactions { get; set; }
    }
}
