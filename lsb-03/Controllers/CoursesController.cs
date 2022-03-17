using lsb_03.Models;
using lsb_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lsb_03.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: Courses
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }
    }
}