using Root.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Root.Services
{
    public class HttpService : IHttpService
    {     
        public HttpResponseMessage GetAsyncHtml(string url)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(url);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            return httpClient.GetAsync(url).Result;
        }

        async public Task<string> HttpResponseToString(HttpResponseMessage httpResponse)
        {
            return await httpResponse.Content.ReadAsStringAsync();
        }
    }
}
