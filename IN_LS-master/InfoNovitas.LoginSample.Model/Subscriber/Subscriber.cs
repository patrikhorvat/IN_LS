using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Model.Subscriber
{
    public class Subscriber
    {
        public int Id { get; set; }
        public string FName { get; set; }

        public string LName { get; set; }

        public int BooksReserved { get; set; }
    }
}
