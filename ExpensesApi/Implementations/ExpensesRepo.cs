using ExpensesApi.DTO;
using ExpensesApi.Model;
using ExpensesApi.Services;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApi.Implementations
{
    public class ExpensesRepo : IExpenseRepo
    {
        private readonly ExpensesDbContext _context;
        public ExpensesRepo(ExpensesDbContext context)
        {
            _context = context;
        }

        public void AddExpense(ExpenseDto expense)
        {
            _context.Add(expense);
            _context.SaveChanges();
        }

        public void DeleteExpense(int ExpenseId)
        {
            var expense = _context.Expenses.FirstOrDefault(x => x.ExpenseId == ExpenseId);
            if (expense == null)
            {
                return;
            }
            _context.Remove(expense);
            _context.SaveChanges();

        }

        public async Task<List<Expense>> GetAllExpenseAsync()
        {
            var expense = await _context.Expenses.Select(x =>
            new Expense
            {
                ExpenseId = x.ExpenseId,
                IsCompulsory = x.IsCompulsory,
                Date = x.Date,
                ExpenseDescription = x.ExpenseDescription,
                ExpenseTitle = x.ExpenseTitle
            }).ToListAsync();

            return expense;

        }

        public string GetOneExpense(int id)
        {
            var expense = _context.Expenses.FirstOrDefault(x => x.Id == id);
            if (expense == null) { return null; }
            return "Dleted Successfully";
        }

        public void UpdateExpense(ExpenseDto expense)
        {
            _context.Update(expense);
            _context.SaveChanges();
        }
    }
}
