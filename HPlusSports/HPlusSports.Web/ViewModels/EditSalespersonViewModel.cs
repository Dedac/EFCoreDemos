using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HPlusSports.Models;

namespace HPlusSports.Web.ViewModels
{
    public class EditSalespersonViewModel
    {
        private Salesperson person;

        public EditSalespersonViewModel(Salesperson person)
        {
            this.person = person;
        }

        public Salesperson Person { get { return person; } }
    }
}
