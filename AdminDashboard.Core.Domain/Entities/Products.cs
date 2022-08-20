using System;
using System.Collections.Generic;
using System.Text;

namespace AdminDashboard.Core.Domain.Entities
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int StoreID { get; set; }
        public Store Store { get; set; }
        public int FactorID { get; set; }
        public SellManagement SellManagement { get; set; }
    }
}
