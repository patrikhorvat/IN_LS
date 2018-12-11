using InfoNovitas.LoginSample.Web.Api.Models.Authors;
using InfoNovitas.LoginSample.Web.Api.Models.Genres;
using InfoNovitas.LoginSample.Web.Api.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoNovitas.LoginSample.Web.Api.Models.Books
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public UserViewModel UserCreated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortContent { get; set; }
        public DateTime Year { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public UserViewModel UserLastModified { get; set; }

        public GenreViewModel Genre { get; set; }
        public List<AuthorViewModel> Authors { get; set; }

        public string AuthorsList
        {
            get
            {
                if (Authors == null)
                    return null;
                return string.Join(", ", Authors.Select(a => a.FullName));
            }
        }
    }
}