using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Product
    {
        public Product()
        {
           
        }

        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int? Size { get; set; }
        public string Variety { get; set; }
        public decimal? Price { get; set; }
        public string Status { get; set; }

        
    }
}
