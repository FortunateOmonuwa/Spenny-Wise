using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Spenny_Wise.WebAPI.Data_Access.Contracts;
using Spenny_Wise.WebAPI.Data_Access.Contracts.BaseContract;
using Spenny_Wise.WebAPI.Data_Access.Contracts.ExpenseContract;
using Spenny_Wise.WebAPI.Data_Access.DataAccessHelpers;
using Spenny_Wise.WebAPI.Domain.DTOs;
using Spenny_Wise.WebAPI.Domain.DTOs.Expense;
using Spenny_Wise.WebAPI.Domain.Models.ExpenseEntities;
using Spenny_Wise.WebAPI.Domain.Utilities;

namespace Spenny_Wise.WebAPI.Data_Access.Repositories
{
    public class ExpenseRepository :  IBudgetandExpenseBaseContract<Expense>
    {
        private readonly ILogger<ExpenseRepository> logger;
        private readonly SpennyContext context;
        private readonly ExceptionHandler exceptionHandler;
        private readonly IMapper mapper;
        private readonly DBAccessHelper dBAccessHelper;
        private readonly IMemoryCache memoryCache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        public ExpenseRepository(ILogger<ExpenseRepository> logger,
            SpennyContext context, 
            ExceptionHandler exceptionHandler, 
            IMapper mapper, 
            DBAccessHelper dBAccessHelper,
            IMemoryCache memoryCache)
        {
            this.logger = logger;
            this.context = context;
            this.exceptionHandler = exceptionHandler;
            this.mapper = mapper;
            this.dBAccessHelper = dBAccessHelper;
            this.memoryCache = memoryCache;
        }
        public async Task<ResponseDetail<Expense>> Create(Expense param, Guid userId)
        {
            var response = new ResponseDetail<Expense>();
            try
            {

                var user = await context.Users.Include(x => x.Expenses).FirstOrDefaultAsync(x => x.Id == userId) ?? throw new ArgumentNullException();
                var category_id = param.CategoryId;
                var category = await dBAccessHelper.GetCategory(category_id);
                if(category != null)
                {
                    param.CategoryId = category.Id;
                }
                else
                {
                    param.CategoryId =  0;
                }
                user.Expenses.Add(param);
                if(await context.SaveChangesAsync() > 0)
                {

                    return response.SuccessResultData(param);
                }
                else
                {
                    return response.FailedResultData(param);
                }
               
                
            }
            catch(Exception ex) 
            {
                exceptionHandler.LogException(ex);
                throw new Exception($"{ex.GetType().Name} \n\n\n {ex.Message} \n\n\n {ex.Source}");
            }
        }

        //public Task<ResponseDetail<Expense>> Create(Expense param)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<ResponseDetail<bool>> Delete(Guid userId, string paramId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDetail<List<Expense>>> GetAll(Guid userId, int page_size, int page_number)
        {
            var response = new ResponseDetail<List<Expense>>();
            try
            {
                var user_expenses = new List<Expense>();
                string cacheKey = "AllExpenses";
                var cache = memoryCache.TryGetValue(cacheKey, out List<Expense>? expenses);
                if (!cache)
                {
                    expenses = await context.Expenses              
                    .ToListAsync();

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));
                    memoryCache.Set(cacheKey, expenses, cacheEntryOptions);
                }
                user_expenses = expenses
                    .Where(e=> e.UserId == userId)
                    .Skip((page_number - 1) * page_size).Take(page_size)
                    .ToList();
                response = response.SuccessResultData([.. user_expenses]);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
        public async Task<ResponseDetail<List<Expense>>> GetAll(int page_size, int page_number)
        {
            
            var response = new ResponseDetail<List<Expense>>();
            try
            {
                string cacheKey = "AllExpenses";
                var cache = memoryCache.TryGetValue(cacheKey, out List<Expense>? expenses);
                if (!cache)
                {
                    expenses = await context.Expenses.ToListAsync();

                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5));
                    memoryCache.Set(cacheKey, expenses, cacheEntryOptions);
                }
                var paginated_expense = expenses.Skip((page_number - 1) * page_size).Take(page_size);
                response = response.SuccessResultData([.. paginated_expense]);
                
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<ResponseDetail<Expense>> GetByCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<Expense>> GetByDate(string date)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<Expense>> GetById(Guid userId, string paramId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<bool>> Update(string paramId, Expense param)
        {
            throw new NotImplementedException();
        }
    }
}
