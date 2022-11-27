using ExpensesApi.DTO;
using ExpensesApi.Model;

namespace ExpensesApi.Services
{
    public interface IExpenseRepo
    {
        void AddExpense(ExpenseDto expense);
        void UpdateExpense(ExpenseDto expense);
        void DeleteExpense(int expenseId);
        string GetOneExpense(int id);
        Task<List<Expense>> GetAllExpenseAsync();

    }
}
