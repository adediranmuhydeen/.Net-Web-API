using ExpensesApi.DTO;
using ExpensesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesControler : ControllerBase
    {
        private readonly IExpenseRepo _expenseRepo;
        public ExpensesControler(IExpenseRepo expenseRepo)
        {
            _expenseRepo = expenseRepo;
        }


        [HttpPost("AddExpense")]
        public Task<IActionResult> AddExpensesAsyc(ExpenseDto expenseDto)
        {
            var expense = await _expenseRepo.AddExpense(expenseDto);
            return Ok("Expense Added Successfully");
        }
    }
}
