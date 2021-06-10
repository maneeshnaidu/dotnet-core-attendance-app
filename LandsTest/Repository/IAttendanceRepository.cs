using LandsTest.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandsTest.Repository
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAllAttendances();
        Task<int> AddNewAttendance(Attendance model);
    }
}