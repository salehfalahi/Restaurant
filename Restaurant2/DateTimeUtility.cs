using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace Restaurant2

{
    public static class DateTimeUtility
    {
        public static string GetCurrentPersianDateTime()
        {
            // گرفتن زمان حال سیستم
            DateTime currentTime = DateTime.Now;

            // تبدیل زمان میلادی به شمسی
            PersianCalendar persianCalendar = new PersianCalendar();
            int year = persianCalendar.GetYear(currentTime);
            int month = persianCalendar.GetMonth(currentTime);
            int day = persianCalendar.GetDayOfMonth(currentTime);
            int hour = currentTime.Hour;
            int minute = currentTime.Minute;
            int second = currentTime.Second;

            // ایجاد یک رشته برای ذخیره در دیتابیس
            string persianDateTime = string.Format("{0}-{1}-{2} {3}:{4}:{5}", year, month, day, hour, minute, second);

            return persianDateTime;
        }
    }

}
//using Microsoft.AspNetCore.Mvc;

//public class HomeController : Controller
//{
//    public IActionResult Index()
//    {
//        // گرفتن زمان شمسی از کلاس Utility
//        string persianDateTime = DateTimeUtility.GetCurrentPersianDateTime();

//        // ارسال زمان شمسی به نمایشگاه
//        ViewData["PersianDateTime"] = persianDateTime;

//        return View();
//    }
//}
  //< h1 > زمان حال سیستم به شمسی:</ h1 >
  //  < p > @ViewData["PersianDateTime"] </ p >