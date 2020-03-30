using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finalprog02.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OpcionesGenerales()
        {
            return View();
        }

        public ActionResult VstMantenimientos()
        {
            return View();
        }

        public ActionResult VstProcesos()
        {
            return View();
        }
    }
}