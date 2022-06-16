using BLL.Interfaces;
using BLL.Models;
using BLL.StringExtension;
using System;
using System.Net.Http;

namespace BLL.Services
{
    public class GetSynonym : IGet
    {
        private readonly ResponseSynonym _response;
        private readonly string _apiUrl = "https://www.sinonimos.com.br/[WORD]/";
        private const string _classHtmlForSearch = "class=\"sinonimo\"";
        private const string _tagLinkHtml = "</a>";
        private const int _numberToAdjustSubstring = 17;

        public GetSynonym(string word)
        {
            _response = new ResponseSynonym(word.ToLower());
        }

        public Response Action()
        {           
            try
            {
                IHttpService httpService = new HttpService();
                HttpResponseMessage httpResponse = httpService.Request(_apiUrl.Replace("[WORD]", _response.Word));

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = httpService.HttpResponseToString(httpResponse).Result;
                    var indexes = content.AllIndexesOf(_classHtmlForSearch);                    

                    foreach (var index in indexes)
                    {
                        int indexStart = index + _numberToAdjustSubstring;
                        int indexEnd = content.IndexOf(_tagLinkHtml, indexStart);
                        _response.SynonymsList.Add(content.Substring(indexStart, indexEnd - indexStart));
                    }
                }
            }
            catch (Exception ex)
            {
                _response.ErrorMessage = ex.Message;
            }
            finally
            {
                _response.Word = _apiUrl;
            }

            return _response;
        }
    }
}
