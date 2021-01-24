using System.Threading.Tasks;

namespace CoreCrud.Services.Helpers
{
    public interface RequestHelperService
    {
        /// <summary>
        /// GET
        /// </summary>
        Task<string> Get(string uri, string url);

        /// <summary>
        /// POST
        /// </summary>
        Task<string> Post(string uri, string url, object objectDto);
    }
}