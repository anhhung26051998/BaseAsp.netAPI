
using BaseProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace APIProject.App_Start
{
    public class FilterApp: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext filterContext)
        {
            JsonResultModel errortoken = new JsonResultModel { code = 0, status = 0, message = "Token không tồn tại" };
            try
            {
                //GO_TECHEntities gt = new GO_TECHEntities();
               // var token = filterContext.Request.Headers.GetValues("token").FirstOrDefault();
                var usertoken = new Object();
                //var usertoken = gt.Customer.Where(u =>u.Token.Equals(token)&& u.IsActive == SystemParam.ACTIVE);
                if (usertoken==null)//||usertoken.Count()==0)
                {
                    
                    filterContext.Response = filterContext.Request.CreateResponse(errortoken);

                }
                else
                {
                    HttpContext.Current.Request.Headers["user"] = JsonConvert.SerializeObject(errortoken);
                }    
       
            }
            catch
            {
                filterContext.Response = filterContext.Request.CreateResponse(errortoken);
            }
        }

       
    }
}