using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class PerishableProduct : Product
    {     
        public int? ExpirationDays { get; set; }
        public bool? Refrigerated { get; set; }

    }
}
