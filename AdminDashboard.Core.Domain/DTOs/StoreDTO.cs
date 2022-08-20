using System;
using System.Collections.Generic;
using System.Text;

namespace AdminDashboard.Core.Domain.DTOs
{
    public class StoreDTO
    {
        public int StoreID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
    }
}
