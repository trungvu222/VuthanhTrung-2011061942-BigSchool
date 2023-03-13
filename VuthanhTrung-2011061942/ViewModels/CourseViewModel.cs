using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VuthanhTrung_2011061942.Models;

namespace VuthanhTrung_2011061942.ViewModels
{
    public class CourseViewModel
    {
        [Required] //Yêu cầu ràng buộc dữ liệu
        public string Place { get; set; }
        [Required]
        [FutureDate] // Lớn hơn ngày hiện tại
        public string Date { get; set; }
        [Required]
        [ValidTime] // Nhập đúng giờ phút
        public string Time { get; set; }
        [Required]
        public byte Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}