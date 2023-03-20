using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VuthanhTrung_2011061942.Models;
using VuthanhTrung_2011061942.ViewModels;

namespace VuthanhTrung_2011061942.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Courses
        // Create để view ra khóa học
        [Authorize] //Xác thực quyền để tạo tài khoản mới có thể thêm khóa học
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }
        // View trả về Controller trả về cơ sở dữ liệu models để add thêm khóa học
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken] // dữ liệu được gửi lên server với mỗi lần đăng nhập sẽ có mã khác nhau
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid) //kiểm tra dữ liệu nhập phía sever nếu nhập sai thì sẽ trả về trang đang thao tác (create)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();

            var courses = _dbContext.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Course)
                .Include(l => l.Lecturer)
                .Include(l => l.Category)
                .ToList();

            var viewModel = new CoursesViewModel
            {
                UpcommingCourses = courses,
                ShowAction = User.Identity.IsAuthenticated
            };

            return View(viewModel);
        }
    }
}