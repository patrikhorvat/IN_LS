using InfoNovitas.LoginSample.Web.Api.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoNovitas.LoginSample.Web.Api.Models.Genres
{
    public class GenreViewModel
    {
        public int Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public UserViewModel UserCreated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public UserViewModel UserLastModified { get; set; }
    }
}