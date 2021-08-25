using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _72HourProject.Controllers._72hrControllers
{
    public class ReplyController : Controller
    {
        // GET: Reply
        public ActionResult Index()
        {
            return View();
            Console.WriteLine("First Change");
        }
    }
}