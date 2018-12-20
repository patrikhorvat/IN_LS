using AutoMapper;
using InfoNovitas.LoginSample.Model.Subscriber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views = InfoNovitas.LoginSample.Services.Messaging.Views;

namespace InfoNovitas.LoginSample.Services.Mapping
{
    public static class SubscribersMapper
    {
        public static Views.Subscriber.Subscriber MapToView(this Subscriber model)
        {
            return Mapper.Map<Views.Subscriber.Subscriber>(model);
        }

        public static Subscriber MapToModel(this Views.Subscriber.Subscriber view)
        {
            return Mapper.Map<Subscriber>(view);
        }

        public static List<Views.Subscriber.Subscriber> MapToViews(this IEnumerable<Subscriber> models)
        {
            var result = new List<Views.Subscriber.Subscriber>();
            if (models == null)
                return result;
            result.AddRange(models.Select(item => item.MapToView()));
            return result;
        }
    }
}
