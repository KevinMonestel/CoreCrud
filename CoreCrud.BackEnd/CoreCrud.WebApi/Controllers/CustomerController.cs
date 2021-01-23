using CoreCrud.Models.Customer;
using CoreCrud.Services.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetAllAsync();
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> Find(int Id)
        {
            var result = await _customerService.FindAsync(Id);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> Insert(CustomerModel model)
        {
            await _customerService.InsertAsync(model);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Update(CustomerModel model)
        {
            await _customerService.UpdateAsync(model);
            return Ok();
        }
    }
}
