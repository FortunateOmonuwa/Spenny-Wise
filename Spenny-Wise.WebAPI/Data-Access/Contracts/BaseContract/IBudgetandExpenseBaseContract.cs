using Spenny_Wise.WebAPI.Domain.DTOs;
using Spenny_Wise.WebAPI.Domain.Models;
using Spenny_Wise.WebAPI.Domain.Utilities;

namespace Spenny_Wise.WebAPI.Data_Access.Contracts.BaseContract
{
    public interface IBudgetandExpenseBaseContract<T>
    {
        Task<ResponseDetail<T>> Create(T param);
        Task<ResponseDetail<T>> Create(T param, string Category);
        Task<ResponseDetail<List<T>>> GetAll();
        Task<ResponseDetail<T>> GetById(string paramId);
        Task <ResponseDetail<T>> GetByCategory(string categoryId);
        Task<ResponseDetail<T>> GetByDate(string date);
        Task<ResponseDetail<bool>> Delete(string paramId);
        Task<ResponseDetail<bool>> Update(string paramId, T param);
    }
}
