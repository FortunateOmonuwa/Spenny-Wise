using AutoMapper;
using Spenny_Wise.WebAPI.Domain.DTOs.Expense;
using Spenny_Wise.WebAPI.Domain.Models.ExpenseEntities;

namespace Spenny_Wise.WebAPI.Data_Access.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ExpenseCreate, Expense>().ReverseMap();
            CreateMap<Expense, ExpenseGet>().ReverseMap();
        
        }
    }
}
