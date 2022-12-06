using ExpensesApi.DTO;
using ExpensesApi.Model;

namespace ExpensesApi.Services
{
    public interface IExpenseRepo
    {
        Task<bool> AddExpense(ExpenseDto expenseDto);
        Task<bool> UpdateExpense(int expenseId, ExpenseDto expenseDto);
        Task<bool> DeleteExpense(int expenseId);
        Task<Expense> GetOneExpense(int id);
        Task<List<Expense>> GetAllExpenseAsync();

    }
}
