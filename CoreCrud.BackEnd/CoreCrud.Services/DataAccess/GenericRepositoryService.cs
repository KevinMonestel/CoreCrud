using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CoreCrud.Services.DataAccess
{
    public interface GenericRepositoryService<TModel>
    {
        IDbConnection GetOpenConnection();
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> FindAsync(int id);
        Task<bool> InsertAsync(TModel model);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(TModel modelToUpdate);
    }
}