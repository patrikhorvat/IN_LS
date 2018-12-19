using InfoNovitas.LoginSample.Services.Messaging.Views.Books;
using InfoNovitas.LoginSample.Web.Api.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoNovitas.LoginSample.Web.Api.Mapping
{
    public static class BooksMapper
    {
        public static List<BookViewModel> MapToViewModels(this List<Book> views)
        {
            var result = new List<BookViewModel>();
            if (views == null)
                return result;
            result.AddRange(views.Select(v => v.MapToViewModel()));
            return result;
        }

        public static BookViewModel MapToViewModel(this Book view)
        {
            if (view == null)
                return null;
            return new BookViewModel()
            {
                Id = view.Id,
                DateCreated = view.DateCreated,
                UserCreated = view.UserCreated.MapToViewModel(),
                Name = view.Name,
                Description = view.Description,
                ShortContent = view.ShortContent,
                Genre = view.Genre.MapToViewModel(),
                LastModified = view.LastModified,
                UserLastModified = view.UserLastModified.MapToViewModel()
            };
        }
    }
}