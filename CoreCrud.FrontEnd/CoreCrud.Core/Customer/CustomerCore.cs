using CoreCrud.Services.Customer;
using CoreCrud.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreCrud.Core.Customer
{
    public class CustomerCore : CustomerService
    {
        #region Attributes

        #endregion

        #region Constructors
        public CustomerCore()
        {

        }
        #endregion

        #region Methods
        public async Task<List<CustomerViewModel>> GetAll()
        {
            return null;
        }

        public async Task<CustomerViewModel> Get(int Id)
        {
            return null;
        }

        public async Task<bool> Create(CustomerViewModel ViewModel)
        {
            return true;
        }

        public async Task<bool> Update(CustomerViewModel ViewModel)
        {
            return true;
        }

        public async Task<bool> Delete(int Id)
        {
            return true;
        }
        #endregion
    }
}
