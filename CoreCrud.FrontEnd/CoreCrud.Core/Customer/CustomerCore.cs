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
        private string ApiBackEndUri = string.Empty;
        #endregion

        #region Constructors
        public CustomerCore(RequestHelperService requestHelperService, IConfiguration configuration)
        {
            _requestHelperService = requestHelperService;
            _configuration = configuration;
            ApiBackEndUri = _configuration["ApiBackEndUri"];
        }
        #endregion

        #region Methods
        public async Task<List<CustomerViewModel>> GetAllAsync()
        {
            List<CustomerViewModel> customers = new List<CustomerViewModel>();

            var contentResult = await _requestHelperService.GetAsync(ApiBackEndUri, "api/Customer/GetAll");

            if (!string.IsNullOrEmpty(contentResult))
            {
                customers = (List <CustomerViewModel>)JsonConvert.DeserializeObject(contentResult, typeof(List<CustomerViewModel>));
            }

            return customers;
        }

        public async Task<CustomerViewModel> FindAsync(int Id)
        {
            CustomerViewModel customer = null;

            var contentResult = await _requestHelperService.GetAsync(ApiBackEndUri, $"api/Customer/Find?Id={Id}");

            if (!string.IsNullOrEmpty(contentResult))
            {
                customer = (CustomerViewModel)JsonConvert.DeserializeObject(contentResult, typeof(CustomerViewModel));
            }

            return customer;
        }

        public async Task<bool> CreateAsync(CustomerViewModel ViewModel)
        {
            bool result = false;

            var contentResult = await _requestHelperService.PostAsync(ApiBackEndUri, "api/Customer/Insert", ViewModel);

            if (!string.IsNullOrEmpty(contentResult))
            {
                result = (bool)JsonConvert.DeserializeObject(contentResult, typeof(bool));
            }

            return result;
        }

        public async Task<bool> UpdateAsync(CustomerViewModel ViewModel)
        {
            bool result = false;

            var contentResult = await _requestHelperService.PutAsync(ApiBackEndUri, "api/Customer/Update", ViewModel);

            if (!string.IsNullOrEmpty(contentResult))
            {
                result = (bool)JsonConvert.DeserializeObject(contentResult, typeof(bool));
            }

            return result;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            bool result = false;

            var contentResult = await _requestHelperService.DeleteAsync(ApiBackEndUri, $"api/Customer/Delete?Id={Id}");

            if (!string.IsNullOrEmpty(contentResult))
            {
                result = (bool)JsonConvert.DeserializeObject(contentResult, typeof(bool));
            }

            return result;
        }
        #endregion
    }
}
