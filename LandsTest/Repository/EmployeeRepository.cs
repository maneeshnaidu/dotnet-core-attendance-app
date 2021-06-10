using LandsTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LandsTest.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AttendanceContext _context = null;

        public EmployeeRepository(AttendanceContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();            
        }

        public async Task<int> AddNewEmployee(Employee model)
        {
            var newEmployee = new Employee()
            {
                FirstName = model.FirstName,
                LastName = model.LastName                
            };

            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            return newEmployee.Id;
        }
        
    }
}