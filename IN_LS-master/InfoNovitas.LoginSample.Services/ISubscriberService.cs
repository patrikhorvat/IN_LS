
using InfoNovitas.LoginSample.Services.Subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services
{
    public interface ISubscriberService
    {
        GetSubscribersResponse GetSubscriber(GetSubscribersRequest request);
    }
}
