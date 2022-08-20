using System;
using System.Collections.Generic;
using System.Text;

namespace AdminDashboard.Core.Domain.Entities
{
    public class SellManagement
    {
        public SellManagement()
        {
            FactorID = new Guid();
            SoldDate = DateTime.Now;
        }
        public int SellManagementID { get; set; }
        public Guid FactorID { get; set; }
        public int ProductID { get; set; }
        public int Stock { get; set; }
        public Products Products { get; set; }
        public DateTime SoldDate { get; set; }
        public string CustomerName { get; set; }
    }
}
