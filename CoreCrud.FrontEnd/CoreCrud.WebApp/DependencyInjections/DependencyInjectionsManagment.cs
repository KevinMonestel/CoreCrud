using Microsoft.Extensions.DependencyInjection;
using CoreCrud.Core.Customer;
using CoreCrud.Services.Customer;

namespace CoreCrud.WebApp.DependencyInjections
{
    public static class DependencyInjectionsManagment
    {
        public static void Declare(IServiceCollection services)
        {
            services.AddSingleton<CustomerService, CustomerCore>();
        }
    }
}
