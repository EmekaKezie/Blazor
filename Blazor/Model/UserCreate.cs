using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Model
{
    public class UserCreate
    {
        public string username { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
    }
}
