using NT1.Controllers;
using NT1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NT1.Filters
{
	public class VerificaSesion : ActionFilterAttribute
	{

        private Usuario oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                oUsuario = (Usuario)HttpContext.Current.Session["User"];
                if (oUsuario == null)
                {

                    if (filterContext.Controller is LoginController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Login/Login");
                    }



                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("Login/Login");
            }

        }
    }
}