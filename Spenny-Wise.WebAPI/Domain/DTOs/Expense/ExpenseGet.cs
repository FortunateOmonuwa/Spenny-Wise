
using Spenny_Wise.WebAPI.Domain.Models;
using Spenny_Wise.WebAPI.Domain.Models.BaseModelEntity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Spenny_Wise.WebAPI.Domain.DTOs.Expense
{
    public class ExpenseGet : BaseEntity
    {

      
        public string Price { get; set; } = "Price";
        [DataType(DataType.Date)]
        public DateTime DateOfExpense { get; set; }
        public int? CategoryId { get; set; }
    }
}
