using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBtest.Models
{
    public class Request
    {
        public int RequestId { get; set; }
        public int ReqPrjId { get; set; }
        public int ReqStatus { get; set; }
        public string Comment { get; set; }

        public List<User> Users { get; set; }
        public Request()
        {
            Users = new List<User>();
        }
    }
}
