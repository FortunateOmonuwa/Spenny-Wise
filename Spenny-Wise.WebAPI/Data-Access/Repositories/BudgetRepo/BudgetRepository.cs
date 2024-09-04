using Spenny_Wise.WebAPI.Data_Access.Contracts;
using Spenny_Wise.WebAPI.Data_Access.Contracts.BaseContract;
using Spenny_Wise.WebAPI.Domain.Models.BudgetEntities;
using Spenny_Wise.WebAPI.Domain.Utilities;

namespace Spenny_Wise.WebAPI.Data_Access.Repositories.BudgetRepo
{
    public class BudgetRepository : IBudgetandExpenseBaseContract<Budget>
    {
        public Task<ResponseDetail<Budget>> Create(Budget param, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<bool>> Delete(Guid userId, string paramId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<List<Budget>>> GetAll(Guid userId, int page_size, int page_number)
        {
            throw new NotImplementedException();
        }
        public Task<ResponseDetail<List<Budget>>> GetAll(int page_size, int page_number)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<Budget>> GetByCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<Budget>> GetByDate(string date)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<Budget>> GetById(Guid userId, string paramId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetail<bool>> Update(string paramId, Budget param)
        {
            throw new NotImplementedException();
        }
    }
}
