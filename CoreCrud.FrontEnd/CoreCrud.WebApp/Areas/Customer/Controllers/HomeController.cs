using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Services.Customer;
using CoreCrud.ViewModels.Customer;

namespace CoreCrud.WebApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("[area]/[controller]/[action]")]
    public class HomeController : Controller
    {
        #region Attributes
        private readonly CustomerService _customerService;
        #endregion

        #region Constructors
        public HomeController(CustomerService customerService)
        {
            _customerService = customerService;
        }
        #endregion

        #region Methods
        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllAsync();
            return View(customers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var customer = await _customerService.FindAsync(id);
            return View(customer);
        }

        public async Task<IActionResult> Create(int id = 0)
        {
            CustomerViewModel customer = new CustomerViewModel();

            if(id > 0)
            {
                customer = await _customerService.FindAsync(id);
            }

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            bool result = false;

            if (customer.Id.Equals(0))
            {
                result = await _customerService.CreateAsync(customer);
            }
            else
            {
                result = await _customerService.UpdateAsync(customer);
            }

            if (result)
            {
                return RedirectToAction("Index");
            }

            return Content("Error");
        }

        public async Task<JsonResult> Delete(int id)
        {
            var result = await _customerService.DeleteAsync(id);
            return Json(new { result });
        }
        #endregion
    }
}
