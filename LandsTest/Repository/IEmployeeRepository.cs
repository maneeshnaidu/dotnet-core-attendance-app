using LandsTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandsTest.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<int> AddNewEmployee(Employee model);
    }
}