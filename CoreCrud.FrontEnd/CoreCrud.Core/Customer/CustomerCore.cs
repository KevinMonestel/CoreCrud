using CoreCrud.Services.Customer;
using CoreCrud.Services.Helpers;
using CoreCrud.ViewModels.Customer;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreCrud.Core.Customer
{
    public class CustomerCore : CustomerService
    {
        #region Attributes
        private readonly RequestHelperService _requestHelperService;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructors
        public CustomerCore(RequestHelperService requestHelperService, IConfiguration configuration)
        {
            _requestHelperService = requestHelperService;
            _configuration = configuration;
        }
        #endregion

        #region Methods
        public async Task<List<CustomerViewModel>> GetAllAsync()
        {
            return null;
        }

        public async Task<CustomerViewModel> FindAsync(int Id)
        {
            CustomerViewModel customer = null;

            var contentResult = await _requestHelperService.Get(_configuration["ApiBackEndUri"], $"api/Customer/Find?Id={Id}");

            if (!string.IsNullOrEmpty(contentResult))
            {
                customer = (CustomerViewModel)JsonConvert.DeserializeObject(contentResult, typeof(CustomerViewModel));
            }

            return customer;
        }

        public async Task<bool> CreateAsync(CustomerViewModel ViewModel)
        {
            return true;
        }

        public async Task<bool> UpdateAsync(CustomerViewModel ViewModel)
        {
            return true;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            return true;
        }
        #endregion
    }
}
