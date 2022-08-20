using AdminDashboard.Core.Contracts.Facade;
using AdminDashboard.Core.Contracts.UnitofWork;
using AdminDashboard.Core.Domain.DTOs;
using AdminDashboard.Core.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminDashboard.Core.ApplicationService.Facade
{
    public class ProductsFacade : IProductsFacade
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;

        public ProductsFacade(IUnitofWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }
        public int Add(ProductsDTO entity)
        {
            Products productDTO = mapper.Map<ProductsDTO, Products>(entity);
            unitofWork.Products.Add(productDTO);
            unitofWork.Save();
            return productDTO.ProductID;
        }

        public IEnumerable<ProductsDTO> GetAll()
        {
            IEnumerable<Products> products = unitofWork.Products.GetAll();
            IEnumerable<ProductsDTO> productDTO = mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(products);
            return productDTO;
        }

        public ProductsDTO GetById(int id)
        {
            Products products = unitofWork.Products.GetById(id);
            ProductsDTO productDTO = mapper.Map<Products, ProductsDTO>(products);
            return productDTO;
        }

        public void Remove(ProductsDTO entity)
        {
            Products productDTO = mapper.Map<ProductsDTO, Products>(entity);
            unitofWork.Products.Remove(productDTO);
            unitofWork.Save();
        }

        public void Update(ProductsDTO entity)
        {
            Products productDTO = mapper.Map<ProductsDTO, Products>(entity);
            unitofWork.Products.Update(productDTO);
            unitofWork.Save();
        }
    }
}
