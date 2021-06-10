using LandsTest.Models;
using LandsTest.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LandsTest.Controllers
{
    [Route("[controller]/[action]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository = null;
        public EmployeeController(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }
        public async Task<IActionResult> Index()
        {
            var data = await employeeRepository.GetEmployeesAsync();
            return View(data);            
        }

        [HttpGet]
        public IActionResult Create(bool isSuccess = false, int empId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.EmpId = empId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee model)
        {
            int id = await employeeRepository.AddNewEmployee(model);

            return RedirectToAction(nameof(Create), new { isSuccess = true, bookId = id });            
        }


    }
}