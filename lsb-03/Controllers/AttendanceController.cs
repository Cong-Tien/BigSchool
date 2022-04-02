using lsb_03.DTOs;
using lsb_03.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace lsb_03.Controllers
{
    [Authorize]
    public class AttendanceController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendanceController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseID == attendanceDto.CourseId))
                return BadRequest("The Attendance already exists");
            var attendance = new Attendance
            {
                CourseID = attendanceDto.CourseId,
                AttendeeId = userId
            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
           return Ok();
         }
    }
}
