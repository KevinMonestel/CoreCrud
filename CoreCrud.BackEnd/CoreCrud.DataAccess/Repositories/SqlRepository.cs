using CoreCrud.Services.DataAccess;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CoreCrud.DataAccess.Repositories
{
    /// <summary>
    /// The concrete implementation of a SQL repository
    /// </summary>
    public abstract class SqlRepository<TModel> : GenericRepositoryService<TModel>
        where TModel : class
    {
        private string _connectionString;
        private DbConnectionTypesEnum _dbType;

        public SqlRepository(string connectionString)
        {
            _dbType = DbConnectionTypesEnum.SQL;
            _connectionString = connectionString;
        }

        public IDbConnection GetOpenConnection()
        {
            return DbConnectionFactory.GetDbConnection(_dbType, _connectionString);
        }

        public abstract Task<bool> DeleteAsync(int id);
        public abstract Task<IEnumerable<TModel>> GetAllAsync();
        public abstract Task<TModel> FindAsync(int id);
        public abstract Task<bool> InsertAsync(TModel model);
        public abstract Task<bool> UpdateAsync(TModel modelToUpdate);
    }
}