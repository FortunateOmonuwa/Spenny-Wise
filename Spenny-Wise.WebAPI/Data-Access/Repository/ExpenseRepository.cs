using Spenny_Wise.WebAPI.Data_Access.Contracts;
using Spenny_Wise.WebAPI.Domain.DTOs;
using Spenny_Wise.WebAPI.Domain.Models;
using Spenny_Wise.WebAPI.Domain.Utilities;

namespace Spenny_Wise.WebAPI.Data_Access.Repository
{
    public class ExpenseRepository : IBudgetandExpenseBaseContract<Expense>
    {
        public Task<ResponseDetail<Expense>> Create(Expense param)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<bool>> Delete(string paramId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<List<Expense>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<Expense>> GetByCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<Expense>> GetById(string paramId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<bool>> Update(string paramId, Expense param)
        {
            throw new NotImplementedException();
        }
    }
}
