using AdminDashboard.Core.Domain.DTOs;
using AdminDashboard.Core.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminDashboard.Core.ApplicationService.Config
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Products, ProductsDTO>();
            CreateMap<ProductsDTO, Products>();
        }
    }
}
