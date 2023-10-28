using AutoMapper;
using WarehouseApp.MVC.Dto;
using WarehouseApp.MVC.Models;

namespace WarehouseApp.MVC.Helper {
    public class MappingProfiles : Profile {
        public MappingProfiles() {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Login, LoginDto>();
            CreateMap<LoginDto, Login>();
            CreateMap<Requisition, RequisitionDto>();
            CreateMap<RequisitionDto, Requisition>();
            CreateMap<Material, MaterialDto>();
            CreateMap<MaterialDto, Material>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
