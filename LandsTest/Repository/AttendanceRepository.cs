using LandsTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LandsTest.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AttendanceContext _context = null;

        public AttendanceRepository(AttendanceContext context)
        {
            _context = context;
        }
        public async Task<List<Attendance>> GetAllAttendances()
        {
            return await _context.Attendances.Include(a => a.Employee).AsNoTracking().ToListAsync();
        }

        public async Task<int> AddNewAttendance(Attendance model)
        {
            
            var newAttendance = new Attendance()
            {
                AttendTime = DateTime.UtcNow,
                AttendType = model.AttendType,
                EmployeeId = model.EmployeeId
            };

            await _context.Attendances.AddAsync(newAttendance);
            await _context.SaveChangesAsync();

            return newAttendance.Id;
        }
    }
}