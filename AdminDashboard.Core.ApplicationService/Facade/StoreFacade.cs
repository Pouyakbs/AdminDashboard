using AdminDashboard.Core.Contracts.Facade;
using AdminDashboard.Core.Contracts.UnitofWork;
using AdminDashboard.Core.Domain.DTOs;
using AdminDashboard.Core.Domain.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace AdminDashboard.Core.ApplicationService.Facade
{
    public class StoreFacade : IStoreFacade
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;

        public StoreFacade(IUnitofWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }
        public int Add(StoreDTO entity)
        {
            Store storeDTO = mapper.Map<StoreDTO, Store>(entity);
            unitofWork.Store.Add(storeDTO);
            unitofWork.Save();
            return storeDTO.StoreID;
        }

        public IEnumerable<StoreDTO> GetAll()
        {
            IEnumerable<Store> store = unitofWork.Store.GetAll();
            IEnumerable<StoreDTO> storeDTO = mapper.Map<IEnumerable<Store>, IEnumerable<StoreDTO>>(store);
            return storeDTO;
        }

        public StoreDTO GetById(int id)
        {
            Store store = unitofWork.Store.GetById(id);
            StoreDTO storeDTO = mapper.Map<Store, StoreDTO>(store);
            return storeDTO;
        }

        public void Remove(StoreDTO entity)
        {
            Store storeDTO = mapper.Map<StoreDTO, Store>(entity);
            unitofWork.Store.Remove(storeDTO);
            unitofWork.Save();
        }

        public void Update(StoreDTO entity)
        {
            Store storeDTO = mapper.Map<StoreDTO, Store>(entity);
            unitofWork.Store.Update(storeDTO);
            unitofWork.Save();
        }
    }
}
