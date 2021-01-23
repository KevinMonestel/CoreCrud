using CoreCrud.DataAccess;
using CoreCrud.DataAccess.Repositories;
using CoreCrud.Models.Customer;
using CoreCrud.Services.Customer;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CoreCrud.Core.Customer
{
    public class CustomerCore : SqlRepository<CustomerModel>, CustomerService
    {
        public CustomerCore(string connectionString) : base(connectionString) { }

        public override async Task DeleteAsync(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "DELETE FROM CustomerModel WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, System.Data.DbType.Int32);
                await conn.QueryFirstOrDefaultAsync<CustomerModel>(sql, parameters);
            }
        }

        public override async Task<IEnumerable<CustomerModel>> GetAllAsync()
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "SELECT * FROM Customer";
                return await conn.QueryAsync<CustomerModel>(sql);
            }
        }

        public override async Task<CustomerModel> FindAsync(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "SELECT * FROM Customer WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, System.Data.DbType.Int32);
                return await conn.QueryFirstOrDefaultAsync<CustomerModel>(sql, parameters);
            }
        }

        public override async Task InsertAsync(CustomerModel entity)
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "INSERT INTO CustomerModel(Name) "
                    + "VALUES(@Name)";

                var parameters = new DynamicParameters();
                parameters.Add("@Name", entity.FirstName, System.Data.DbType.String);

                await conn.QueryAsync(sql, parameters);
            }
        }

        public override async Task UpdateAsync(CustomerModel entityToUpdate)
        {
            using (var conn = GetOpenConnection())
            {
                var existingEntity = await FindAsync(entityToUpdate.Id);

                var sql = "UPDATE CustomerModel "
                    + "SET ";

                var parameters = new DynamicParameters();
                if (existingEntity.FirstName != entityToUpdate.FirstName)
                {
                    sql += "Name=@Name,";
                    parameters.Add("@Name", entityToUpdate.FirstName, DbType.String);
                }

                sql = sql.TrimEnd(',');

                sql += " WHERE Id=@Id";
                parameters.Add("@Id", entityToUpdate.Id, DbType.Int32);

                await conn.QueryAsync(sql, parameters);
            }
        }
    }
}