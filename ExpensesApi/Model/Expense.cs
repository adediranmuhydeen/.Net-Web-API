using System.ComponentModel.DataAnnotations;

namespace ExpensesApi.Model
{
    public class Expense
    {
        /// <summary>
        /// The main model
        /// </summary>
        [Key]
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public string ExpenseTitle { get; set; }
        public string ExpenseDescription { get; set; }
        public bool IsCompulsory { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
