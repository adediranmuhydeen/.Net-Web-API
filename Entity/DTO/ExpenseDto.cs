namespace ExpensesApi.DTO
{
    public class ExpenseDto
    {
        public string ExpenseTitle { get; set; }
        public string ExpenseDescription { get; set; }
        public bool IsCompulsory { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
