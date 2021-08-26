using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.Models
{
    public class EmployeeInfo
    {
        public int ID { get; set; }
        public string role { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }

    }
    public class UserInfo
    {
        public string userLogin{ get; set; }
        public string password { get; set; }

    }
}
