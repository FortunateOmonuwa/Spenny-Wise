using AutoMapper;
using Spenny_Wise.WebAPI.Data_Access.DataAccessHelpers;
using Spenny_Wise.WebAPI.Domain.DTOs.Expense;
using Spenny_Wise.WebAPI.Domain.Models.ExpenseEntities;

namespace Spenny_Wise.WebAPI.Domain.Utilities
{
    public class ModelMapper
    {
        private readonly IMapper mapper;
        private readonly DBAccessHelper helper;
        public ModelMapper(IMapper mapper, DBAccessHelper helper) 
        { 
            this.mapper = mapper;
            this.helper = helper;
        }
        public Expense ExpenseCreateMapper(ExpenseCreate expenseCreate) 
        {
            var expense = mapper.Map<Expense>(expenseCreate);
            return expense;
        }

        public ExpenseGet ExpenseGetMapper(Expense model)
        {
           var category = helper.GetCategory(model.CategoryId).Result;
            var expense = new ExpenseGet
            {
                CategoryId = model.CategoryId,
                CategoryName = category.Name ?? "no selected category",
                Name = model.Name,
                Id = model.Id,
                DateOfExpense = model.DateOfExpense,
                Price = model.Price,
            };

            return expense;
        }
    }
}
