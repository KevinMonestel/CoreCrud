using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CoreCrud.Services.DataAccess
{
    public interface IGenericRepository<TModel>
    {
        IDbConnection GetOpenConnection();
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> FindAsync(int id);
        Task InsertAsync(TModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(TModel modelToUpdate);
    }
}