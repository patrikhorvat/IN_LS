using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Repositories.Mapping
{
    public static class GenreMapper
    {
        public static Model.Genres.Genre MapToModel(this DatabaseModel.Genre_GetAllGenres_Result dbResult)
        {
            if (dbResult == null)
                return null;


            return new Model.Genres.Genre()
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
                LastModified = dbResult.LastModified,
                UserLastModified = new Model.Users.UserInfo()
                {
                    Id = dbResult.UserLastModified.GetValueOrDefault(),
                    FullName = dbResult.UserLastModifiedFullName
                }
            };
        }

        public static List<Model.Genres.Genre> MapToModels(this IEnumerable<DatabaseModel.Genre_GetAllGenres_Result> dbResults)
        {
            var result = new List<Model.Genres.Genre>();
            if (dbResults == null)
                return result;
            result.AddRange(dbResults.Select(b => b.MapToModel()));
            return result;
        }
    }
}
