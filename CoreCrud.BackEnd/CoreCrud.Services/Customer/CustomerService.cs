using CoreCrud.Models.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreCrud.Services.Customer
{
    public interface CustomerService
    {
        Task DeleteAsync(int id);
        Task<CustomerModel> FindAsync(int id);
        Task<IEnumerable<CustomerModel>> GetAllAsync();
        Task InsertAsync(CustomerModel entity);
        Task UpdateAsync(CustomerModel entityToUpdate);
    }
}