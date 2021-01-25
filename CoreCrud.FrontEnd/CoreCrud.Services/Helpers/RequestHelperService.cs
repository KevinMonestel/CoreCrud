using System.Threading.Tasks;

namespace CoreCrud.Services.Helpers
{
    public interface RequestHelperService
    {
        /// <summary>
        /// GET
        /// </summary>
        Task<string> GetAsync(string uri, string url);

        /// <summary>
        /// GET
        /// </summary>
        Task<string> DeleteAsync(string uri, string url);

        /// <summary>
        /// POST
        /// </summary>
        Task<string> PutAsync(string uri, string url, object objectDto);

        /// <summary>
        /// POST
        /// </summary>
        Task<string> PostAsync(string uri, string url, object objectDto);
    }
}