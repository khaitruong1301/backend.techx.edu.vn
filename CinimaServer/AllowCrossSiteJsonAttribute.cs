using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace CinimaServer
{
    public class AllowCrossSiteJsonAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    var response = filterContext.HttpContext.Response;
        //    response.AddHeader("Access-Control-Allow-Origin", "*");
        //    response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
        //    response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");


        //    base.OnActionExecuting(filterContext);
            
        //}

    }
}