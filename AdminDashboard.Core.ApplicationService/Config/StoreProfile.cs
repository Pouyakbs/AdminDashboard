using AdminDashboard.Core.Domain.DTOs;
using AdminDashboard.Core.Domain.Entities;
using AutoMapper;

namespace AdminDashboard.Core.ApplicationService.Config
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreDTO>();
            CreateMap<StoreDTO, Store>();
        }
    }
}
