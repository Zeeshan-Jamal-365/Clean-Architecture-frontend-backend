using AutoMapper;
using Taskmanagement.Services.Model;

namespace Taskmanagement.Core.Mapper;
public class CommonMapper : Profile
{
    public CommonMapper()
    {
        CreateMap<VmProduct, Model.Product>().ReverseMap();
        CreateMap<VmCustomer, Model.Customer>().ReverseMap();
    }
}
