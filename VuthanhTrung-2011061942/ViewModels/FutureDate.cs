using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace VuthanhTrung_2011061942.ViewModels
{
    // Ràng buộc dữ liệu ngày tháng phải đúng dd/MM/yyyy không đúng sẽ báo lỗi 
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "dd/MM/yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);

            return (isValid && dateTime > DateTime.Now);
        }
    }
}