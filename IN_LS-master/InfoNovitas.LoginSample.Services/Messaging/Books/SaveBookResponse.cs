﻿using InfoNovitas.LoginSample.Services.Messaging.Views.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services.Messaging.Books
{
    public class SaveBookResponse: LoginSampleResponseBase<SaveBookRequest>

    {
        public Book Book { get; set; }
    }
}
