using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PG2024.Controllers
{
    public class CerrarController : Controller
    {
        public ActionResult Logoff()
        {

            Session["User"] = null;
            return RedirectToAction("Index", "Access");

        }
    }
}