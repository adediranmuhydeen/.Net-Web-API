using ExpensesApi.Model;

namespace ExpensesApi.Services
{
    public interface IExpenseRepo
    {
        void AddExpense(Expense expense);
        void UpdateExpense(int expenseId);
        bool DeleteExpense(int expenseId);
        Expense GetOneExpense(int id);
        public Task<List<Expense>> GetAllExpenseAsync();

    }
}
