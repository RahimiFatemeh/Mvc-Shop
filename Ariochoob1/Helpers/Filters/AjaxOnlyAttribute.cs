using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ariochoob1.Helpers.Filters
{
    public class AjaxOnlyAttribute : ActionFilterAttribute // we have use attribue in end of the name of class
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext) //OnActionExecuting : still not execute , it's going to execute
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            { // if that was ajax
                base.OnActionExecuting(filterContext); // be sorat adi pas midahim
            }
            else
            {
                filterContext.Result = new HttpNotFoundResult(); // not found 
            }
        }
    }
}