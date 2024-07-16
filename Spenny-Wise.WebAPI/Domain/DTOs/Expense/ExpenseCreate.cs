using Spenny_Wise.WebAPI.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Spenny_Wise.WebAPI.Domain.DTOs.Expense
{
    public class ExpenseCreate
    {
        public string Name { get; set; } 
        public string Price { get; set; }
      

        public string? Category { get; set; } 
        [DataType(DataType.Date)] 

        public DateTime DateOfExpense { get; set; }
   
    }
}
