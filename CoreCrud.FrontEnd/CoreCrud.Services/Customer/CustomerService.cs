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
        Task<List<CustomerViewModel>> GetAllAsync();

        /// <summary>
        /// Get
        /// </summary>
        Task<CustomerViewModel> FindAsync(int Id);

        /// <summary>
        /// Create
        /// </summary>
        Task<bool> CreateAsync(CustomerViewModel ViewModel);

        /// <summary>
        /// Update
        /// </summary>
        Task<bool> UpdateAsync(CustomerViewModel ViewModel);

        /// <summary>
        /// Delete
        /// </summary>
        Task<bool> DeleteAsync(int Id);
    }
}