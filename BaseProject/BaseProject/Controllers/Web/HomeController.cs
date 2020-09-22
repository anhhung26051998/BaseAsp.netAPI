using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaseProject.Controllers.Web
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }
        public void test()
        {

            throw new Exception("test");
        }
    }
}