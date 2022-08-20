using System;
using System.Collections.Generic;
using System.Text;

namespace AdminDashboard.Core.Domain.DTOs
{
    public class SellManagementDTO
    {
        public int SellManagementID { get; set; }
        public int FactorID { get; set; }
        public int ProductID { get; set; }
        public int Stock { get; set; }
        public DateTime SoldDate { get; set; }
        public string CustomerName { get; set; }
    }
}
