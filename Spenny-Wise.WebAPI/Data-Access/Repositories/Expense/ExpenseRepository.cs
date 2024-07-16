using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using Spenny_Wise.WebAPI.Data_Access.Contracts;
using Spenny_Wise.WebAPI.Data_Access.Contracts.BaseContract;
using Spenny_Wise.WebAPI.Data_Access.Contracts.ExpenseContract;
using Spenny_Wise.WebAPI.Domain.DTOs;
using Spenny_Wise.WebAPI.Domain.DTOs.Expense;
using Spenny_Wise.WebAPI.Domain.Models.ExpenseEntities;
using Spenny_Wise.WebAPI.Domain.Utilities;

namespace Spenny_Wise.WebAPI.Data_Access.Repositories
{
    public class ExpenseRepository :  IExpenseContract
    {
        private readonly ILogger<ExpenseRepository> logger;
        private readonly SpennyContext context;
        private readonly ExceptionHandler exceptionHandler;
        private readonly IMapper mapper;
        public ExpenseRepository(ILogger<ExpenseRepository> logger, SpennyContext context, ExceptionHandler exceptionHandler, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.exceptionHandler = exceptionHandler;
            this.mapper = mapper;
        }
        public async Task<ResponseDetail<Expense>> Create(Expense param, string category)
        {
            var response = new ResponseDetail<Expense>();
            try
            {
                if(param is null)
                {
                    logger.LogInformation("Some parameters were null/ not filled");
                    return response.FailedResultData(param);
                    throw new ArgumentNullException(nameof(param));
                }
                else
                {
                    var check_category = await context.ExpenseCategories.FirstOrDefaultAsync(x => x.Name == category);
                    if(check_category is null)
                    {
                        var newCategory = new ExpenseCategory
                        {
                            Name = category
                        };

                        await context.ExpenseCategories.AddAsync(newCategory);
                        await context.SaveChangesAsync();
                        param.CategoryId = newCategory.Id;
                    }
                    else
                    {
                        param.CategoryId = check_category.Id;
                    }

               
                    await context.Expenses.AddAsync(param);
                    await context.SaveChangesAsync();
                    logger.LogInformation($"Operation successful. Expense successfully created \n\n\n ${param}");
                    return response.SuccessResultData(param);
                }
            }
            catch(Exception ex) 
            {
                exceptionHandler.LogException(ex);
                throw new Exception($"{ex.GetType().Name} \n\n\n {ex.Message} \n\n\n {ex.Source}");
            }
        }

        public Task<ResponseDetail<Expense>> Create(Expense param)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<ExpenseGet>> CreateExpense(Expense expense_create_model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<bool>> Delete(string paramId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<IEnumerable<ExpenseGet>>> GetAllExpenses()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<ExpenseGet>> GetByCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<ExpenseGet>> GetByDate(string date)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<ExpenseGet>> GetExpense(string expense_id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<bool>> Update(string paramId, ExpenseCreate param)
        {
            throw new NotImplementedException();
        }

        Task<ResponseDetail<Expense>> IExpenseContract.CreateExpense(Expense expense_create_model)
        {
            throw new NotImplementedException();
        }


        //public Task<ResponseDetail<bool>> Delete(string paramId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ResponseDetail<List<Expense>>> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ResponseDetail<IEnumerable<ExpenseGet>>> GetAllExpenses()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ResponseDetail<Expense>> GetByCategory(string categoryId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ResponseDetail<Expense>> GetByDate(string date)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ResponseDetail<Expense>> GetById(string paramId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ResponseDetail<ExpenseGet>> GetExpense(string expense_id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ResponseDetail<bool>> Update(string paramId, Expense param)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ResponseDetail<bool>> Update(string paramId, ExpenseCreate param)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<ResponseDetail<ExpenseGet>> IExpenseContract.GetByCategory(string categoryId)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<ResponseDetail<ExpenseGet>> IExpenseContract.GetByDate(string date)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
