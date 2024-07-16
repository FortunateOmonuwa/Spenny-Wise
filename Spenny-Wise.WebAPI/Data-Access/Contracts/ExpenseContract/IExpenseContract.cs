using Spenny_Wise.WebAPI.Domain.DTOs.Expense;
using Spenny_Wise.WebAPI.Domain.Models.ExpenseEntities;
using Spenny_Wise.WebAPI.Domain.Utilities;

namespace Spenny_Wise.WebAPI.Data_Access.Contracts.ExpenseContract
{
    public interface IExpenseContract
    {
        Task<ResponseDetail<Expense>> CreateExpense(Expense expense_create_model);
        Task<ResponseDetail<ExpenseGet>> GetExpense(string expense_id);
        Task<ResponseDetail<IEnumerable<ExpenseGet>>> GetAllExpenses();
        Task<ResponseDetail<ExpenseGet>> GetByCategory(string categoryId);
        Task<ResponseDetail<ExpenseGet>> GetByDate(string date);
        Task<ResponseDetail<bool>> Delete(string paramId);
        Task<ResponseDetail<bool>> Update(string paramId, ExpenseCreate param);
    }
}
