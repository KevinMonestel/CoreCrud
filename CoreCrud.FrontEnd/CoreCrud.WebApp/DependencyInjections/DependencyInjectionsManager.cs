using Microsoft.Extensions.DependencyInjection;
using CoreCrud.Core.Customer;
using CoreCrud.Services.Customer;
using CoreCrud.Core.Helpers;
using CoreCrud.Services.Helpers;

namespace CoreCrud.WebApp.DependencyInjections
{
    public static class DependencyInjectionsManager
    {
        public static void Declare(IServiceCollection services)
        {
            services.AddSingleton<CustomerService, CustomerCore>();
            services.AddSingleton<RequestHelperService, RequestHelperCore>();
        }
    }
}
