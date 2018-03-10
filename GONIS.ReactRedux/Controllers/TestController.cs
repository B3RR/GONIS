using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GONIS.ReactRedux.Controllers
{
    class Test
    {
        public int? Id { get; set; }
        public string Text { get; set; }
    }
    public class TestController : Controller
    {
        [HttpGet]
        public JsonResult GetList()
        {
            try
            {
                var test = new List<Test>();
                var rnd = new Random();
                test.Add(new Test { Id = null, Text = $"Hello {User.Identity.Name}, IsAuthenticated={User.Identity.IsAuthenticated}" });
                for (var i = 0; i <= 10; i++)
                {
                    var temp = rnd.Next(i);
                    test.Add(new Test { Id = i, Text = $"{DateTime.UtcNow.AddDays(temp).AddHours(temp).AddSeconds(temp).AddMonths(temp).ToString()}" });
                }
                return Json(test);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }

        }
    }
}