using CoreCrud.Models.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreCrud.Services.Customer
{
    public interface CustomerService
    {
        Task<bool> DeleteAsync(int id);
        Task<CustomerModel> FindAsync(int id);
        Task<IEnumerable<CustomerModel>> GetAllAsync();
        Task<bool> InsertAsync(CustomerModel entity);
        Task<bool> UpdateAsync(CustomerModel entityToUpdate);
    }
}