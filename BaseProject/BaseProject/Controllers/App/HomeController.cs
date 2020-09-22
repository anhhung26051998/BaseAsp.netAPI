
using APIProject.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BaseProject.Controllers.App
{
    public class HomeController : BaseApiController
    {
        // GET: HomeApi
        [HttpGet]
        public string Index( int? Id)
        {

            int[] mynumbers = new int[] { 1, 2, 3 };
            int i = mynumbers[Id.Value];
            return i.ToString();
        }
        [HttpGet]
        [FilterApp]
        public string Test()
        {

            return GetUserToken();
        }
    }
}