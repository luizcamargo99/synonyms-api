using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using Xunit;

namespace BLL.Test
{
    public class TestSynonymServiceSuccess
    {
        [Fact]
        public void TestWordAmor()
        {
            string word = "amor";
            IService synonymService = new SynonymService(new ValidateWordSynonym(word), new GetSynonym(word, new HttpService()));
            var response = (SynonymResponse)synonymService.Action();
            Assert.True(response.SynonymsList.Count > 0);
        }

        [Fact]
        public void TestWordPortanto()
        {
            string word = "Portanto";
            IService synonymService = new SynonymService(new ValidateWordSynonym(word), new GetSynonym(word, new HttpService()));
            var response = (SynonymResponse)synonymService.Action();
            Assert.True(response.SynonymsList.Count > 0);
        }
    }
}
