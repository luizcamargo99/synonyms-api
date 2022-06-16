using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using System;
using Xunit;

namespace BLL.Test
{
    public class TestGetSynonymSuccess
    {
        [Fact]
        public void TestWord1()
        {
            IGet getSynonym = new GetSynonym("amor"); 
            var response = (ResponseSynonym)getSynonym.Action();
            Assert.True(response.SynonymsList.Count > 0);
        }

        [Fact]
        public void TestWord2()
        {
            IGet getSynonym = new GetSynonym("portanto");
            var response = (ResponseSynonym)getSynonym.Action();
            Assert.True(response.SynonymsList.Count > 0);
        }
    }
}
