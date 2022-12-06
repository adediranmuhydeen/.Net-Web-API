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
        private readonly ExpensesDbContext _context;
        public ExpensesControler(IExpenseRepo expenseRepo, ExpensesDbContext context)
        {
            _expenseRepo = expenseRepo;
            _context = context;
        }


        [HttpPost("AddExpense")]
        public async Task<IActionResult> AddExpensesAsyc([FromBody] ExpenseDto expenseDto)
        {
            await _expenseRepo.AddExpense(expenseDto);
            return Ok("Expense Added Successfully");
        }

        [HttpPut("UpdateExpense")]
        public async Task<IActionResult> UpdateExpenseAsync([FromQuery] int expenseId, ExpenseDto expenseDto)
        {

            var expense = _context.Expenses.FirstOrDefault(x => x.Id == expenseId);
            if (expense == null) { return BadRequest("Expense with such ID does not exist"); }
            expense.Date = DateTime.Now;
            expense.ExpenseDescription = expenseDto.ExpenseDescription;
            expense.IsCompulsory = expenseDto.IsCompulsory;
            expense.ExpenseTitle = expenseDto.ExpenseTitle;

            await _expenseRepo.UpdateExpense(expenseId, expenseDto);
            return Ok(expense);
        }

        [HttpDelete("DeleteExpense")]
        public async Task<IActionResult> DeleteExpense([FromQuery] int expenseId)
        {
            var delet = await _expenseRepo.DeleteExpense(expenseId);
            if (delet.Equals(false))
            {
                return BadRequest("Expense with such ID does not exist");
            }

            return Ok("Expense deleted Successfully");
        }

        [HttpGet("GetAllExpenses")]
        public async Task<IActionResult> GetAllExpenses()
        {
            var result = await _expenseRepo.GetAllExpenseAsync();
            return Ok(result);
        }

        [HttpGet("GetOneExpense")]
        public async Task<IActionResult> GetOneExpense(int Id)
        {
            var get = await _expenseRepo.GetOneExpense(Id);
            if (get.Equals(false))
            {
                return BadRequest("Invalid input");
            }
            return Ok(get);
        }
    }
}
