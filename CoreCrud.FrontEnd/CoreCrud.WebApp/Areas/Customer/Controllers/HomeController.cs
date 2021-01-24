using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Services.Customer;

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
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Get(int Id)
        {
            var customer = await _customerService.FindAsync(Id);
            return View(customer);
        }
        #endregion
    }
}
