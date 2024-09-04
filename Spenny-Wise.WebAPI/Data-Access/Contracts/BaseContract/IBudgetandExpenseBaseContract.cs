using Spenny_Wise.WebAPI.Domain.DTOs;
using Spenny_Wise.WebAPI.Domain.Models;
using Spenny_Wise.WebAPI.Domain.Utilities;

namespace Spenny_Wise.WebAPI.Data_Access.Contracts.BaseContract
{
    public interface IBudgetandExpenseBaseContract<T>
    {
        Task<ResponseDetail<T>> Create(T param, Guid userId); 
        Task<ResponseDetail<List<T>>> GetAll(Guid userId, int page_size, int page_number);
        Task<ResponseDetail<List<T>>> GetAll(int page_size, int page_number);
        Task<ResponseDetail<T>> GetById(Guid userId, string paramId);
        Task <ResponseDetail<T>> GetByCategory(string categoryId);
        Task<ResponseDetail<T>> GetByDate(string date);
        Task<ResponseDetail<bool>> Delete(Guid userId, string paramId);
        Task<ResponseDetail<bool>> Update(string paramId, T param);
    }
}
