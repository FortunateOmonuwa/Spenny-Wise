using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spenny_Wise.WebAPI.Data_Access.Contracts.BaseContract;
using Spenny_Wise.WebAPI.Domain.DTOs.Expense;
using Spenny_Wise.WebAPI.Domain.Models.ExpenseEntities;

namespace Spenny_Wise.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IBudgetandExpenseBaseContract<Expense> expense;
        private readonly IMapper mapper;
        public ExpenseController(IBudgetandExpenseBaseContract<Expense> expense, IMapper mapper)
        {
            this.expense = expense;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(ExpenseCreate model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var mapedCreate = mapper.Map<Expense>(model);

                    var newValues = await expense.Create(mapedCreate, model.Category);
                    
                    var new_expense = mapper.Map<ExpenseGet>(mapedCreate);
                    return Ok(new_expense);

                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Source);
            }
        }
    }
}
