using InfoNovitas.LoginSample.Services.Messaging.Views.Genres;
using InfoNovitas.LoginSample.Web.Api.Models.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoNovitas.LoginSample.Web.Api.Mapping
{
    public static class GenresMapper


    {

        public static List<GenreViewModel> MapToViewModels(this List<Genre> views)
        {
            var result = new List<GenreViewModel>();
            if (views == null)
                return result;
            result.AddRange(views.Select(v => v.MapToViewModel()));
            return result;
        }

        public static GenreViewModel MapToViewModel(this Genre view)
        {
            if (view == null)
                return null;
            return new GenreViewModel()
            {
                Id = view.Id,
                DateCreated = view.DateCreated,
                UserCreated = view.UserCreated.MapToViewModel(),
                Name = view.Name,
                Description = view.Description,
                LastModified = view.LastModified,
                UserLastModified = view.UserLastModified.MapToViewModel()
            };
        }
    }
}