using Root.Interfaces;
using Root.Models;
using Root.Services;
using Synonym.Services;
using Xunit;

namespace Synonym.Test
{
    public class TestSynonymServiceFail
    {
        [Theory]
        [InlineData(null)]
        [InlineData("saassasa")]
        public void TestGetSynonymException(string word)
        {
            IValidate validate = new ValidateWord(word);
            IGet get = new GetSynonym(word, new HttpService());
            IService service = new ServiceBase(validate, get);
            Response response = service.Action();
            Assert.NotNull(response.ErrorMessage);
        }
    }
}
