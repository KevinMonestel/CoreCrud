using CoreCrud.ViewModels.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreCrud.Services.Customer
{
    public interface CustomerService
    {
        /// <summary>
        /// Get all
        /// </summary>
        Task<List<CustomerViewModel>> GetAll();

        /// <summary>
        /// Get
        /// </summary>
        Task<CustomerViewModel> Get(int Id);

        /// <summary>
        /// Create
        /// </summary>
        Task<bool> Create(CustomerViewModel ViewModel);

        /// <summary>
        /// Update
        /// </summary>
        Task<bool> Update(CustomerViewModel ViewModel);

        /// <summary>
        /// Delete
        /// </summary>
        Task<bool> Delete(int Id);
    }
}