using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using System;
using Xunit;

namespace BLL.Test
{
    public class TestSynonymServiceFail
    {
        [Theory]
        [InlineData(null)]
        [InlineData("saassasa")]
        public void TestGetSynonymException(string word)
        {
            IValidate validate = new ValidateWordSynonym(word);
            IGet get = new GetSynonym(word, new HttpService());
            IService service = new ServiceBase(validate, get);
            Response response = service.Action();
            Assert.NotNull(response.ErrorMessage);
        }
    }
}
