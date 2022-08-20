using AdminDashboard.Core.Contracts.Facade;
using AdminDashboard.Core.Contracts.UnitofWork;
using AdminDashboard.Core.Domain.DTOs;
using AdminDashboard.Core.Domain.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace AdminDashboard.Core.ApplicationService.Facade
{
    public class SellManagementFacade : ISellManagementFacade
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;

        public SellManagementFacade(IUnitofWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }
        public int Add(SellManagementDTO entity)
        {
            SellManagement sellManagementDTO = mapper.Map<SellManagementDTO, SellManagement>(entity);
            unitofWork.SellManagement.Add(sellManagementDTO);
            unitofWork.Save();
            return sellManagementDTO.SellManagementID;
        }

        public IEnumerable<SellManagementDTO> GetAll()
        {
            IEnumerable<SellManagement> sellManagement = unitofWork.SellManagement.GetAll();
            IEnumerable<SellManagementDTO> sellManagementDTO = mapper.Map<IEnumerable<SellManagement>, IEnumerable<SellManagementDTO>>(sellManagement);
            return sellManagementDTO;
        }

        public SellManagementDTO GetById(int id)
        {
            SellManagement sellManagement = unitofWork.SellManagement.GetById(id);
            SellManagementDTO sellManagementDTO = mapper.Map<SellManagement, SellManagementDTO>(sellManagement);
            return sellManagementDTO;
        }

        public void Remove(SellManagementDTO entity)
        {
            SellManagement sellManagementDTO = mapper.Map<SellManagementDTO, SellManagement>(entity);
            unitofWork.SellManagement.Remove(sellManagementDTO);
            unitofWork.Save();
        }

        public void Update(SellManagementDTO entity)
        {
            SellManagement sellManagementDTO = mapper.Map<SellManagementDTO, SellManagement>(entity);
            unitofWork.SellManagement.Update(sellManagementDTO);
            unitofWork.Save();
        }
    }
}
