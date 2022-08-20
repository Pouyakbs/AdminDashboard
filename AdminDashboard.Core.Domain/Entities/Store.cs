using System;
using System.Collections.Generic;
using System.Text;

namespace AdminDashboard.Core.Domain.Entities
{
    public class Store
    {
        public int StoreID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public List<Products> Products { get; set; }
        public int Stock { get; set; }
    }
}
