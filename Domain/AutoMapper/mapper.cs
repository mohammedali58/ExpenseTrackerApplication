
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Domain.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Expense, ExpenseDto>().ReverseMap();
            CreateMap<List<Expense>, List<ExpenseDto>>().ReverseMap();
            // Additional mappings...
        }
    }
    
}


