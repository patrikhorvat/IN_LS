using InfoNovitas.LoginSample.Services.Messaging.Views.Authors;
using InfoNovitas.LoginSample.Services.Messaging.Views.Genres;
using InfoNovitas.LoginSample.Services.Messaging.Views.Users;
using System;
using System.Collections.Generic;

namespace InfoNovitas.LoginSample.Services.Messaging.Views.Books
{
    public class Book
    {
        public int Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public UserInfo UserCreated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortContent { get; set; }
        public DateTime Year { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public UserInfo UserLastModified { get; set; }

        public Genre Genre { get; set; }
        public List<Author> Authors { get; set; }
    }
}
