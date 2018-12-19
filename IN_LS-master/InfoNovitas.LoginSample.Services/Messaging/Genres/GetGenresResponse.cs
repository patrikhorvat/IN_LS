using InfoNovitas.LoginSample.Services.Messaging.Views.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services.Messaging.Genres
{
    public class GetGenresResponse:LoginSampleResponseBase<GetGenresRequest>
    {
        public List<Genre> Genres { get; set; }
    }
}
