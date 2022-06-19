using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SynonymController : ControllerBase
    {
        [HttpGet]
        public Response Get(string word)
        {
            IValidate validate = new ValidateWordSynonym(word);
            IGet get = new GetSynonym(word, new HttpService());
            IService service = new ServiceBase(validate, get);
            Response response = service.Action();
            return response;
        }
    }
}
