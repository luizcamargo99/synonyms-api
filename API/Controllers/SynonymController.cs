using Root.Interfaces;
using Root.Models;
using Root.Services;
using Microsoft.AspNetCore.Mvc;
using Synonym.Services;

namespace API.Controllers
{
    [ApiController]
    public class SynonymController : ControllerBase
    {
        private const string RouteEnglish = "synonyms/{word}";
        private const string RoutePortuguese = "sinonimos/{word}";

        [HttpGet]
        [Route(RouteEnglish)]
        [Route(RoutePortuguese)]
        public Response Get(string word)
        {
            IValidate validate = new ValidateWord(word);
            IGet get = new GetSynonym(word, new HttpService());
            IService service = new ServiceBase(validate, get);
            return service.Action();
        }
    }
}
