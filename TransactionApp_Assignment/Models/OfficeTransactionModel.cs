namespace TransactionApp_Assignment.Models
{
    public class OfficeTransactionModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }=DateTime.Now;
        public string Description { get; set; }

        public decimal Credit { get; set; }
        public decimal Debit { get; set; }

        public decimal runningBalance { get; set; }
    }
}
