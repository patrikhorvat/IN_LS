﻿using InfoNovitas.LoginSample.Web.Api.Models.Users;
using System;

namespace InfoNovitas.LoginSample.Web.Api.Models.Authors
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public UserViewModel UserCreated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public DateTime? DeathDate { get; set; }

        public string DeathPlace { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public UserViewModel UserLastModified { get; set; }
    }
}