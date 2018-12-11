using AutoMapper;
using InfoNovitas.LoginSample.Model.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views = InfoNovitas.LoginSample.Services.Messaging.Views;

namespace InfoNovitas.LoginSample.Services.Mapping
{
    public static class GenresMapper
    {
        public static Views.Genres.Genre MapToView(this Genre model)
        {
            return Mapper.Map<Views.Genres.Genre>(model);
        }

        public static List<Views.Genres.Genre> MapToViews(this IEnumerable<Genre> models)
        {
            var result = new List<Views.Genres.Genre>();
            if (models == null)
                return result;
            result.AddRange(models.Select(item => item.MapToView()));
            return result;
        }
    }
}
