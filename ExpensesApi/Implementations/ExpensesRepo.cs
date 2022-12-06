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

        public async Task<bool> AddExpense(ExpenseDto expenseDto)
        {
            var expense = new Expense
            {
                ExpenseDescription = expenseDto.ExpenseDescription,
                ExpenseTitle = expenseDto.ExpenseTitle,
                Date = expenseDto.Date,
                IsCompulsory = expenseDto.IsCompulsory,
            };
            await _context.AddAsync(expense);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteExpense(int ExpenseId)
        {
            var expense = await _context.Expenses.FirstOrDefaultAsync(x => x.Id == ExpenseId);
            if (expense == null)
            {
                return false;
            }
            _context.Remove(expense);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<Expense>> GetAllExpenseAsync()
        {
            var expense = await _context.Expenses.Select(x =>
            new Expense
            {
                Id = x.Id,
                IsCompulsory = x.IsCompulsory,
                Date = x.Date,
                ExpenseDescription = x.ExpenseDescription,
                ExpenseTitle = x.ExpenseTitle
            }).ToListAsync();

            return expense;

        }

        public async Task<Expense> GetOneExpense(int id)
        {
            var expense = await _context.Expenses.FirstOrDefaultAsync(x => x.Id == id);
            if (expense == null) { return null; }
            return expense;
        }

        public async Task<bool> UpdateExpense(int expenseId, ExpenseDto expenseDto)
        {
            var expenseToBeUpdated = await _context.Expenses.FirstOrDefaultAsync(x => x.Id == expenseId);
            if (expenseToBeUpdated == null) { return false; }
            _context.Update(expenseToBeUpdated);
            _context.SaveChanges();
            return true;
        }
    }
}
