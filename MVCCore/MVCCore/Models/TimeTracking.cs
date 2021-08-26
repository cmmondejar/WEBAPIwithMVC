using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.Models
{
    public class TimeTracking
    {
        public Guid ID { get; set; }
        public string employeeName { get; set; }
        public DateTime clockInTime { get; set; }
        public DateTime clockOutTime { get; set; }
        public bool isActive { get; set; } = true;
    }
    public class EditTimeTracking
    {
        public Guid ID { get; set; }
        public string employeeName { get; set; }
        public bool isActive { get; set; } = true;
    }
}
