using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Services.Customer;

namespace CoreCrud.WebApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("Customer")]
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
            _customerService.GetAll();
            return View();
        }
        #endregion
    }
}
