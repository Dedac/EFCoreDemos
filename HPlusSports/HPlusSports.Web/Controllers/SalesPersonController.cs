using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HPlusSports.Core;
using HPlusSports.Web.ViewModels;
using HPlusSports.Models;
using HPlusSports.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HPlusSports.Web.Controllers
{
    public class SalesPersonController : Controller
    {
        ISalesPersonService _salesPersonService;
        ISalesPersonRepository _salesPersonRepo;
        public SalesPersonController(ISalesPersonService salesPersonServiceService, ISalesPersonRepository salesPersonRepo)
        {
            _salesPersonService = salesPersonServiceService;
            _salesPersonRepo = salesPersonRepo;
        }

        public async Task<ActionResult> Index()
        {
            var salesPeople = await _salesPersonRepo.GetWithOrders();
            return View(salesPeople);
        }

        public async Task<ActionResult> Edit(int Id)
        {
            var person = await _salesPersonRepo.GetByID(Id);

            return View(new EditSalespersonViewModel(person));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditSalespersonViewModel vm)
        {
            ValidateBusinessModel(vm.GetPerson(), ModelState);
            if (!ModelState.IsValid) return View(vm);

            await _salesPersonService.UpdateSalesPersonContact(vm.GetPerson());

            return Redirect("/SalesPerson/Index");
        }

        private void ValidateBusinessModel<T>(T model, ModelStateDictionary modelState)
        {
            var vc = new ValidationContext(model);
            var validations = new List<ValidationResult>();
            if (!Validator.TryValidateObject(model, vc, validations))
            {
                foreach (var validation in validations)
                    ModelState.AddModelError(validation.MemberNames.First(), validation.ErrorMessage);
            }
        }
    }
}