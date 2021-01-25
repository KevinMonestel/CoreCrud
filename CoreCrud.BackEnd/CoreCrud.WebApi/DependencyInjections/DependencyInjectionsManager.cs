using Microsoft.Extensions.DependencyInjection;
using CoreCrud.Core.Customer;
using CoreCrud.Services.Customer;
using Microsoft.Extensions.Configuration;

namespace CoreCrud.WebApp.DependencyInjections
{
    public static class DependencyInjectionsManager
    {
        public static void Declare(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<CustomerService>(x => new CustomerCore(configuration.GetConnectionString("DbConnection")));
        }
    }
}
