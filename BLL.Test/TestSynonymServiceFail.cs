using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using System;
using Xunit;

namespace BLL.Test
{
    public class TestSynonymServiceFail
    {
        [Fact]
        public void TestWordNull()
        {
            string word = null;
            IService synonymService = new SynonymService(new ValidateWordSynonym(word), new GetSynonym(word, new HttpService()));
            var response = (SynonymResponse)synonymService.Action();
            Assert.NotNull(response.ErrorMessage);
        }

        [Fact]
        public void TestWordWithoutSynonym()
        {
            string word = "saassasa";
            IService synonymService = new SynonymService(new ValidateWordSynonym(word), new GetSynonym(word, new HttpService()));
            var response = (SynonymResponse)synonymService.Action();
            Assert.NotNull(response.ErrorMessage);
        }
    }
}
