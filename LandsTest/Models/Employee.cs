using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LandsTest.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Attendance> Attendances { get; set; }
    }
}