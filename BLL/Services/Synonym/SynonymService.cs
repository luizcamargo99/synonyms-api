using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SynonymService : IService
    {
        private readonly IValidate _validateSynonym;
        private readonly IGet _getSynonym;

        public SynonymService (IValidate validateSynonym, IGet getSynonym)
        {
            _validateSynonym = validateSynonym;
            _getSynonym = getSynonym;
        }

        public Response Action ()
        {
            SynonymResponse response = new SynonymResponse();

            try
            {
                _validateSynonym.Validate();
                response = (SynonymResponse)_getSynonym.Get();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;

        }
    }
}
