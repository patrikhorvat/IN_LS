using AutoMapper;
using InfoNovitas.LoginSample.Services.Messaging.Views.Authors;
using InfoNovitas.LoginSample.Services.Messaging.Views.Books;
using InfoNovitas.LoginSample.Services.Messaging.Views.Genres;
using InfoNovitas.LoginSample.Services.Messaging.Views.Users;

namespace InfoNovitas.LoginSample.Services
{
    public class CommonProfile: Profile
    {
        protected override void Configure()
        {
            CreateMap<UserInfo, Model.Users.UserInfo>();
            CreateMap<Author, Model.Authors.Author>();
            CreateMap<Genre, Model.Genres.Genre>();
            CreateMap<Book, Model.Books.Book>();

            CreateMap<Model.Users.UserInfo, UserInfo>();
            CreateMap<Model.Authors.Author, Author>();
            CreateMap<Model.Genres.Genre,Genre>();
            CreateMap<Model.Books.Book, Book>();
        }
    }
}
