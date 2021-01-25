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


        [HttpPost]
        public async Task<IActionResult> Insert(CustomerModel model)
        {
            var result = await _customerService.InsertAsync(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerModel model)
        {
            var result = await _customerService.UpdateAsync(model);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _customerService.DeleteAsync(Id);
            return Ok(result);
        }
    }
}