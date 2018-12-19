using InfoNovitas.LoginSample.Services.Messaging.Views.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services.Messaging.Genres
{
    public class SaveGenreResponse:LoginSampleResponseBase<SaveGenreRequest>
    {
        public Genre Genre { get; set; }
    }
}
