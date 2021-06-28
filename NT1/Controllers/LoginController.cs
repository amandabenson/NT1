using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NT1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string User, string Pass)
        {
            try
            {
                using (Models.NT1Entities3 db = new Models.NT1Entities3())
                {
                    var oUsuario = (from d in db.Usuarios where d.Mail == User.Trim() && d.Pw == Pass.Trim() select d).FirstOrDefault();
                    if (oUsuario == null)
                    {
                        ViewBag.Error = "Usuario o contraseña incorrecta";
                        return View();
                    }

                    Session["User"] = oUsuario;

                    }

                    return RedirectToAction("Index", "Home");

                }
            
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View();
            }


        }
    }
}