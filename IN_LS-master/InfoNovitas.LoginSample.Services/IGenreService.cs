using InfoNovitas.LoginSample.Services.Messaging.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services
{
    public interface IGenreService
    {
        GetGenresResponse GetGenres(GetGenresRequest request);
    }
}
