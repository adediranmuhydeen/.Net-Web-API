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
        public async Task<IActionResult> AddExpensesAsyc([FromBody] ExpenseDto expenseDto)
        {
            _expenseRepo.AddExpense(expenseDto);
            return Ok("Expense Added Successfully");
        }

        [HttpPut("UpdateExpense")]
        public async Task<IActionResult> UpdateExpense(ExpenseDto expenseDto)
        {
            _expenseRepo.UpdateExpense(expenseDto);
            return Ok();
        }
    }
}
