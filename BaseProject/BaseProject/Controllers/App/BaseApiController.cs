using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BaseProject.Controllers.App
{
    public class BaseApiController : ApiController
    {
       // protected GO_TECHEntities Context;
      
       // public BaseAPIController() : base()
       // {
       //     loginBusiness = new LoginBusiness(this.GetContext());
            
       // }

       // /// <summary>
       // /// Create new context if null
       // /// </summary>
       // public GO_TECHEntities GetContext()
       // {
       //     if (Context == null)
       //     {
       //         Context = new GO_TECHEntities();
       //     }
       //     return Context;
       // }

        public string GetUserToken()
        {
            try
            {
                var user = HttpContext.Current.Request.Headers.GetValues("user").FirstOrDefault();
                return user;
            }
            catch
            {
                return null;
            }
        }
    }
}