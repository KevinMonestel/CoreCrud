using CoreCrud.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CoreCrud.Core.Helpers
{
    public class RequestHelperCore : RequestHelperService
    {
        /// <summary>
        /// GET
        /// </summary>
        public async Task<string> Get(string uri, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string contentResult = await response.Content.ReadAsStringAsync();

                        return contentResult;
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// POST
        /// </summary>
        public async Task<string> Post(string uri, string url, object objectDto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (HttpResponseMessage response = await client.PostAsJsonAsync(url, objectDto))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string contentResult = await response.Content.ReadAsStringAsync();

                        return contentResult;
                    }
                    return null;
                }
            }
        }
    }
}