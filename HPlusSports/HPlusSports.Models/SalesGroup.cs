using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class SalesGroup
    {
        public SalesGroup()
        {
            Salespeople = new HashSet<Salesperson>();
        }
        public int Id { get; set; }
        public string State { get; set; }
        public int Type { get; set; }

        public virtual ICollection<Salesperson> Salespeople { get; set; }

    }
}
