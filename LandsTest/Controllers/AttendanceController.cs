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
    public class AttendanceController : Controller
    {
        private readonly IAttendanceRepository _attendanceRepository = null;

        public AttendanceController(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _attendanceRepository.GetAllAttendances();

            return View(data);
        }

        [HttpGet]
        public IActionResult Create(bool isSuccess = false, int attendId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.AttendId = attendId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Attendance model)
        {
            if(ModelState.IsValid)
            {
                int id = await _attendanceRepository.AddNewAttendance(model);
            
                if (id > 0)
                {
                    return RedirectToAction(nameof(Create), new { isSuccess = true, attendId = id });
                }
            }

            ModelState.AddModelError("", "Unable to add attendance.");
            return View();   

        }
    }
}