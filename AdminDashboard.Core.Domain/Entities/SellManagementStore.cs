using System;
using System.Collections.Generic;
using System.Text;

namespace AdminDashboard.Core.Domain.Entities
{
    public class SellManagementStore
    {
        public int SellManagementStoreID { get; set; }
        public int StoreID { get; set; }
        public Store Store { get; set; }
        public int SellManagementID { get; set; }
        public SellManagement SellManagement { get; set; }
    }
}
