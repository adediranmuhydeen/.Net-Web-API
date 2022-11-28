using ExpensesApi.Model;
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
        public async Task<IActionResult> AddExpensesAsyc([FromBody] Expense expenseDto)
        {
            _expenseRepo.AddExpense(expenseDto);
            return Ok("Expense Added Successfully");
        }

        [HttpPut("UpdateExpense")]
        public async Task<IActionResult> UpdateExpense(Expense expenseDto)
        {
            _expenseRepo.UpdateExpense(expenseDto);
            return Ok();
        }

        [HttpDelete("DeleteExpense")]
        public async Task<IActionResult> DeleteExpense(int expenseId)
        {
            var delet = _expenseRepo.DeleteExpense(expenseId);
            if (delet == false)
            {
                return BadRequest("Expense with such ID does not exist");
            }

            return Ok("Expense Deleted Successfully");
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
            var get = _expenseRepo.GetOneExpense(Id);
            if (get == null)
            {
                return BadRequest("Invalid input");
            }
            return Ok(get);
        }
    }
}
