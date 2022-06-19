using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using Xunit;

namespace BLL.Test
{
    public class TestSynonymServiceSuccess
    {
        [Theory]
        [InlineData("amor")]
        [InlineData("Portanto")]
        [InlineData("testE")]
        public void TestGetSynonym(string word)
        {
            IValidate validate = new ValidateWordSynonym(word);
            IGet get = new GetSynonym(word, new HttpService());
            IService service = new ServiceBase(validate, get);
            Response response = service.Action();
            Assert.Null(response.ErrorMessage);
        }
    }
}
