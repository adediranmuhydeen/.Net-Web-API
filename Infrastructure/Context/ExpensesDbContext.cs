using ExpensesApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApi.Context
{
    public class ExpensesDbContext : DbContext
    {
        private readonly DbContext context;
        public ExpensesDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
    }
}
