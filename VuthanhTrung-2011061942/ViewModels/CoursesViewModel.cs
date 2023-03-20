using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VuthanhTrung_2011061942.Models;

namespace VuthanhTrung_2011061942.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}