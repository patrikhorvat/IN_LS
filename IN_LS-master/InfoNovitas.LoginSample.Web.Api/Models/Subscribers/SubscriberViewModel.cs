using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoNovitas.LoginSample.Web.Api.Models.Subscribers
{
    public class SubscriberViewModel
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public int BooksReserved { get; set; }
    }
}