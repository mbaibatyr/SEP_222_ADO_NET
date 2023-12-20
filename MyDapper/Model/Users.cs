using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDapper.Model
{
    public class Users
    {
        public int id { get; set; }
        public string last_name { get; set; }
        public string iin { get; set; }
        public string name { get; set; }        
    }

    public class Users2
    {
        public int id { get; set; }
        public string last_name { get; set; }
        public string iin { get; set; }        
        public string category_id { get; set; }
    }
}
