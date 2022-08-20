using AdminDashboard.Core.Domain.DTOs;
using System.Collections.Generic;

namespace AdminDashboard.Core.Contracts.Facade
{
    public interface ISellManagementFacade
    {
        SellManagementDTO GetById(int id);
        IEnumerable<SellManagementDTO> GetAll();
        int Add(SellManagementDTO entity);
        void Remove(SellManagementDTO entity);
        void Update(SellManagementDTO entity);
    }
}
