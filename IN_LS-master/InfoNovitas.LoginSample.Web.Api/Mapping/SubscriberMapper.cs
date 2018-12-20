using InfoNovitas.LoginSample.Model.Subscriber;
using InfoNovitas.LoginSample.Web.Api.Models.Subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoNovitas.LoginSample.Web.Api.Mapping
{
    public static class SubscriberMapper
    {
        public static SubscriberViewModel MapToViewModel(this Subscriber view)
        {
            if (view == null)
                return null;
            return new SubscriberViewModel()
            {
                Id = view.Id,
                FName = view.FName,
                LName = view.LName,
                BooksReserved=view.BooksReserved
              
            };
        }

        public static Subscriber MapToView(this SubscriberViewModel viewModel)
        {
            if (viewModel == null)
                return null;
            return new Subscriber()
            {
                Id = viewModel.Id,
                FName = viewModel.FName,
                LName = viewModel.LName,
                BooksReserved = viewModel.BooksReserved
            };
        }

        public static List<SubscriberViewModel> MapToViewModels(this IEnumerable<Subscriber> views)
        {
            var result = new List<SubscriberViewModel>();
            if (views == null)
                return result;
            result.AddRange(views.Select(item => item.MapToViewModel()));
            return result;
        }
    }
}