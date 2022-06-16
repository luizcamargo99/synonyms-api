using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SynonymController : ControllerBase
    {
        [HttpGet]
        public SynonymResponse Get(string word)
        {
            IService synonymService = new SynonymService(new ValidateWordSynonym(word), new GetSynonym(word, new HttpService()));
            SynonymResponse response = (SynonymResponse)synonymService.Action();
            response.Word = word;
            return response;
        }
    }
}
