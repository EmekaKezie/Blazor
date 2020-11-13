using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Model
{
    public class User
    {
        public string login_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public DateTime entry_date { get; set; }
    }
}
