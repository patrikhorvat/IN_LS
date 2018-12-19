﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services.Messaging
{
    public class LoginSampleResponseBase<T>
    {
        public T Request { get; set; }
        public Guid ResponseToken { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
