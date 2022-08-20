using AdminDashboard.Core.Domain.DTOs;
using AdminDashboard.Core.Domain.Entities;
using AutoMapper;

namespace AdminDashboard.Core.ApplicationService.Config
{
    public class SellManagementProfile : Profile
    {
        public SellManagementProfile()
        {
            CreateMap<SellManagement, SellManagementDTO>();
            CreateMap<SellManagementDTO, SellManagement>();
        }
    }
}
