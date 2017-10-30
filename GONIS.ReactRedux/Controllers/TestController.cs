using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GONIS.ReactRedux.Controllers
{
    class Test
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
    public class TestController : Controller
    {
        [HttpGet]
        public JsonResult GetList()
        {
            var test = new List<Test>();
            var rnd = new Random();
            for (var i = 0; i <= 10; i++)
            {
                var temp = rnd.Next(i);
                test.Add(new Test { Id = i, Text = $"{temp} - {DateTime.UtcNow.AddDays(temp).AddHours(temp).AddSeconds(temp).AddMonths(temp).ToString()}" });
            }
            return Json(test);
        }
    }
}