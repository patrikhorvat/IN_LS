using InfoNovitas.LoginSample.Services.Messaging;
using InfoNovitas.LoginSample.Services.Messaging.Views.Subscriber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services.Subscribers
{
    public class GetSubscribersResponse: LoginSampleResponseBase<GetSubscribersRequest>
    {
        public List<Subscriber> Subscribers { get; set; }
    }
}
