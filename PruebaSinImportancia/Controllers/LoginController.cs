using PruebaSinImportancia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaSinImportancia.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Vamo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Libro lib)
        {
            try
            {





                return View();
            }
            catch 
            {

                return View();
            }

 
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Libro lib)
        {
            try
            {





                return View();
            }
            catch
            {

                return View();
            }


        }




    }
}