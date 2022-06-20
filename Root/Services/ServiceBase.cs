using Root.Interfaces;
using Root.Models;
using System;

namespace Root.Services
{
    public class ServiceBase : IService
    {
        private readonly IValidate _validate;
        private readonly IGet _get;

        public ServiceBase(IValidate validate, IGet get)
        {
            _validate = validate;
            _get = get;
        }

        public Response Action()
        {
            Response response = new Response();

            try
            {
                _validate.Validate();
                response = _get.Get();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}
