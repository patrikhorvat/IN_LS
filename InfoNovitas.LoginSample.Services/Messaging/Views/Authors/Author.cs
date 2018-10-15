using InfoNovitas.LoginSample.Services.Messaging.Views.Users;
using System;

namespace InfoNovitas.LoginSample.Services.Messaging.Views.Authors
{
    public class Author
    {
        public int Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public UserInfo UserCreated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public DateTime? DeathDate { get; set; }

        public string DeathPlace { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public UserInfo UserLastModified { get; set; }
    }
}
