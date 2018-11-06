using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeChat.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult AmazeUI()
        {
            return View();
        }
        public ActionResult Ionic()
        {
            return View();
        }
    }
}