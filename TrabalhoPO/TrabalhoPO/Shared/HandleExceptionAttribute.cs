﻿using System.Net;
using System.Web.Mvc;

namespace TrabalhoPO.Shared
{
    public class HandleExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.Exception != null)
            {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        filterContext.Exception.Message,
                        filterContext.Exception.StackTrace
                    }
                };

                filterContext.ExceptionHandled = true;

                new ErrorLogger().Log(filterContext.Exception);
            }
            else
            {
                base.OnException(filterContext);
            }
        }
    }
}
