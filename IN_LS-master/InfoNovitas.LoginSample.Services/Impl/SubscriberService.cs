using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoNovitas.LoginSample.Model.Subscriber;
using InfoNovitas.LoginSample.Services.Mapping;
using InfoNovitas.LoginSample.Services.Subscribers;

namespace InfoNovitas.LoginSample.Services.Impl
{
    public class SubscriberService : ISubscriberService
    {

        private ISubscriberRepository _repository;

        public SubscriberService(ISubscriberRepository repository)
        {
            _repository = repository;
        }

        public GetSubscribersResponse GetSubscriber(GetSubscribersRequest request)
        {
            var response = new GetSubscribersResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                response.Subscribers = _repository.FindAll().MapToViews();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
