using Microsoft.AspNetCore.Mvc;
using TransactionApp_Assignment.Data;
using TransactionApp_Assignment.Models;
using TransactionApp_Assignment.Repositories.Interface;

namespace TransactionApp_Assignment.Controllers
{
    public class TransactionController : Controller
    {
        private readonly TransactionDbContext dbContext;
        private readonly ITransaction transaction;

        public TransactionController(TransactionDbContext dbContext, ITransaction transaction)
        {
            this.dbContext = dbContext;
            this.transaction = transaction;
        }

        [HttpGet]
        public  async Task<IActionResult>  Index()
        {
            var transactions=await transaction.GetTransactionModel();
            return View(transactions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OfficeTransactionDTO transactionModel)
        {
            if (ModelState.IsValid)
            {
                await transaction.AddTransaction(transactionModel);
                return RedirectToAction(nameof(Index));
            }
            return View(transactionModel);
        }

    }
}
