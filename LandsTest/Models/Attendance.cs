using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandsTest.Models
{
    public class Attendance
    {
        public int Id { get; set;}
        public DateTime AttendTime { get; set;}
        public string AttendType { get; set;}
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}