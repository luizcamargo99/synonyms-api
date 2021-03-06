using System.Net.Http;
using System.Threading.Tasks;

namespace Root.Interfaces
{
    public interface IHttpService
    {
        public HttpResponseMessage GetAsyncHtml(string url);
        public Task<string> HttpResponseToString(HttpResponseMessage httpResponse);

    }
}
