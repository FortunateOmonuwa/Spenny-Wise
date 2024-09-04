using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spenny_Wise.WebAPI.Data_Access.Contracts.BaseContract;
using Spenny_Wise.WebAPI.Domain.DTOs.Expense;
using Spenny_Wise.WebAPI.Domain.Models.ExpenseEntities;
using Spenny_Wise.WebAPI.Domain.Utilities;

namespace Spenny_Wise.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IBudgetandExpenseBaseContract<Expense> expense;
        // private readonly IMapper mapper;
        private readonly ModelMapper mapper;
        public ExpenseController(IBudgetandExpenseBaseContract<Expense> expense, ModelMapper mapper)
        {
            this.expense = expense;
            this.mapper = mapper;
        }

        [HttpPost("AddExpense/{userId}")]
        public async Task<IActionResult> CreateExpense(ExpenseCreate newmodel, Guid userId)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var expenseModel = mapper.ExpenseCreateMapper(newmodel);

                    var mappedExpense = await expense.Create(expenseModel, userId);
                    if(!mappedExpense.IsSuccessful)
                    {
                        return BadRequest(mappedExpense);
                    }
                    else
                    {
                         var newExpense = mapper.ExpenseGetMapper(mappedExpense.Result);
                        return Ok(newExpense);
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FetchAllExpenses/{userId}")]
        public async Task<IActionResult> GetAll(Guid userId, int page_size = 10, int page_number= 1)
        {
            try
            {
                var expenses = await expense.GetAll(userId, page_size, page_number);
                return Ok(expenses);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Authorize(Roles ="Admin")]   
        
        [HttpGet("FetchAllExpenses")]
        //[ResponseCache(Duration =300)]
        public async Task<IActionResult> GetAll( int page_size = 10, int page_number= 1)
        {
            try
            {
                
                var expenses = await expense.GetAll(page_size, page_number);
                return Ok(expenses);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
