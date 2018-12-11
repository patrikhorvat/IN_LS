using InfoNovitas.LoginSample.Services.Messaging.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services
{
    public interface IBookService
    {
        GetBooksResponse GetBooks(GetBooksRequest request);
    }
}
