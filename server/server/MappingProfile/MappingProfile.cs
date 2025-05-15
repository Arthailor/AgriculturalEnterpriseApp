using AutoMapper;
using server.DTO;
using System.Net.Sockets;
using server.Models;

namespace server.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AnimalForCreationDto, Animal>();
            CreateMap<CropForCreationDto, Crop>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<FieldForCreationDto, Field>();
            CreateMap<EquipmentForCreationDto, Equipment>();
            CreateMap<PastureForCreationDto, Pasture>();
            CreateMap<RepairLogForCreationDto, RepairLog>();
            CreateMap<WarehouseForCreationDto, Warehouse>();
        }
    }
}
