using BLL.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class HttpService : HttpClient, IHttpService
    {     
        public HttpResponseMessage Request (string url)
        {
            BaseAddress = new Uri(url);
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return GetAsync(url).Result;
        }

        async public Task<string> HttpResponseToString (HttpResponseMessage httpResponse)
        {
            return await httpResponse.Content.ReadAsStringAsync();
        }
    }
}
