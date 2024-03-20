using Spenny_Wise.WebAPI.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Spenny_Wise.WebAPI.Domain.DTOs
{
    public class ExpenseCreate
    {
        public int? UserId { get; set; }
        public string Category { get; set; } = "New Category";
        [DataType(DataType.Date)]
        public DateTime DateOfExpense { get; set; }
        public List<ExpenseItemCreate> ExpenseItems { get; set; } = [];
    }
}
