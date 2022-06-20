using BLL.Interfaces;
using BLL.Models;
using BLL.StringExtension;
using System.Net.Http;

namespace BLL.Services
{
    public class GetSynonym : IGet
    {
        private readonly IHttpService _httpService;
        private readonly string _word;

        private const string _apiUrl = "https://www.sinonimos.com.br/";
        private const string _classHtmlForSearch = "class=\"sinonimo\"";
        private const string _tagLinkHtml = "</a>";
        private const int _numberToAdjustSubstring = 17;

        public GetSynonym(string word, IHttpService httpService)
        {
            _word = word;
            _httpService = httpService;
        }

        public Response Get()
        {
            SynonymResponse response = new SynonymResponse{ Word = _word };
            string newWord = _word.TrimStart().TrimEnd().Replace(" ", "-");
            HttpResponseMessage httpResponse = _httpService.GetAsyncHtml(string.Concat(_apiUrl, newWord));

            if (httpResponse.IsSuccessStatusCode == false)
            {
                throw new HttpRequestException($"No synonyms found for {_word}");
            }

            var content = _httpService.HttpResponseToString(httpResponse).Result;
            var indexes = content.AllIndexesOf(_classHtmlForSearch);

            foreach (var index in indexes)
            {
                int indexStart = index + _numberToAdjustSubstring;
                int indexEnd = content.IndexOf(_tagLinkHtml, indexStart);
                response.Synonyms.Add(content.Substring(indexStart, indexEnd - indexStart));
            }

            return response;
        }
    }
}
