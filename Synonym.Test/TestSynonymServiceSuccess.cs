using Root.Interfaces;
using Root.Models;
using Root.Services;
using Synonym.Services;
using Xunit;

namespace Synonym.Test
{
    public class TestSynonymServiceSuccess
    {
        [Theory]
        [InlineData("amor")]
        [InlineData("Portanto")]
        [InlineData("testE")]
        public void TestGetSynonym(string word)
        {
            IValidate validate = new ValidateWord(word);
            IGet get = new GetSynonym(word, new HttpService());
            IService service = new ServiceBase(validate, get);
            Response response = service.Action();
            Assert.Null(response.ErrorMessage);
        }
    }
}
