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

        public override async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using (var conn = GetOpenConnection())
                {
                    var sql = "DELETE FROM Customer WHERE Id = @Id";

                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id, System.Data.DbType.Int32);

                    var result = await conn.ExecuteAsync(sql, parameters);

                    return result > 0 ? true : false;
                }
            }
            catch (System.Exception Ex)
            {

                throw Ex;
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

        public override async Task<bool> InsertAsync(CustomerModel entity)
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "INSERT INTO Customer(FirstName, LastName, Country, City, Phone) "
                    + "VALUES(@FirstName, @LastName, @Country, @City, @Phone)";

                var parameters = new DynamicParameters();
                parameters.Add("@FirstName", entity.FirstName, System.Data.DbType.String);
                parameters.Add("@LastName", entity.LastName, System.Data.DbType.String);
                parameters.Add("@Country", entity.Country, System.Data.DbType.String);
                parameters.Add("@City", entity.City, System.Data.DbType.String);
                parameters.Add("@Phone", entity.Phone, System.Data.DbType.String);

                var result = await conn.ExecuteAsync(sql, parameters);

                return result > 0 ? true : false;
            }
        }

        public override async Task<bool> UpdateAsync(CustomerModel entityToUpdate)
        {
            using (var conn = GetOpenConnection())
            {
                var existingEntity = await FindAsync(entityToUpdate.Id);

                var sql = "UPDATE Customer "
                    + "SET ";

                var parameters = new DynamicParameters();
                sql += "FirstName=@FirstName,";
                parameters.Add("@FirstName", entityToUpdate.FirstName, DbType.String);
                sql += "LastName=@LastName,";
                parameters.Add("@LastName", entityToUpdate.LastName, DbType.String);
                sql += "Country=@Country,";
                parameters.Add("@Country", entityToUpdate.Country, DbType.String);
                sql += "City=@City,";
                parameters.Add("@City", entityToUpdate.City, DbType.String);
                sql += "Phone=@Phone,";
                parameters.Add("@Phone", entityToUpdate.Phone, DbType.String);
                sql = sql.TrimEnd(',');
                sql += " WHERE Id=@Id";
                parameters.Add("@Id", entityToUpdate.Id, DbType.Int32);

                var result = await conn.ExecuteAsync(sql, parameters);

                return result > 0 ? true : false;
            }
        }
    }
}