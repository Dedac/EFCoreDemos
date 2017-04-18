using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Salesperson
    {
        public Salesperson()
        {
            Order = new HashSet<Order>();
        }

        public int SalespersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
       
        public string SalesGroupState { get; set; }
        public int SalesGroupType { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        public virtual ICollection<Order> Order { get; set; }

        public virtual SalesGroup SalesGroup { get; set; }

    }
}
