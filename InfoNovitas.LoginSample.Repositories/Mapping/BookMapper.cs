using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Repositories.Mapping
{
    public static class BookMapper
    {
        public static Model.Books.Book MapToModel(this DatabaseModel.Book_GetAllBooks_Result dbResult)
        {
            if (dbResult == null)
                return null;
            return new Model.Books.Book()
            {
                Id = dbResult.Id,
                DateCreated = dbResult.DateCreated,
                UserCreated = new Model.Users.UserInfo()
                {
                    Id = dbResult.UserCreated.GetValueOrDefault(),
                    FullName = dbResult.UserCreatedFullName
                },
                Name = dbResult.Name,
                Description = dbResult.Description,
                ShortContent = dbResult.ShortContent,
                Genre = new Model.Genres.Genre()
                {
                    Id = dbResult.GenreId.GetValueOrDefault(),
                    Name = dbResult.GenreName
                },
                LastModified = dbResult.LastModified,
                UserLastModified = new Model.Users.UserInfo()
                {
                    Id = dbResult.UserLastModified.GetValueOrDefault(),
                    FullName = dbResult.UserLastModifiedFullName
                }
            };
        }

        public static List<Model.Books.Book> MapToModels(this IEnumerable<DatabaseModel.Book_GetAllBooks_Result> dbResults)
        {
            var result = new List<Model.Books.Book>();
            if (dbResults == null)
                return result;
            result.AddRange(dbResults.Select(b => b.MapToModel()));
            return result;
        }
    }
}
