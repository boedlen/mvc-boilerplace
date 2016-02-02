using mvc_boilerplate.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_boilerplate.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Json()
        {
            return JsonResponse.Ok(new {
                id = 123,
                name = "John Doe",
                attribute3 = new {
                    attribute4 = 4,
                    attribute5 = 5
                },

            });
        }

        public ActionResult Json2()
        {
            return JsonResponse.Error(new
            {
                id = 123,
                name = "John Doe",
                attribute3 = new
                {
                    attribute4 = 4,
                    attribute5 = 5
                },

            });
        }
    }
}