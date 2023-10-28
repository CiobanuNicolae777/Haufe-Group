using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls.Expressions;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        Database1 db = new Database1();

        public ActionResult Home()
        {
            return View();
        }


        [HttpGet]
        public ActionResult AdaugareTrotinete()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AdaugareTrotinete(AdaugareTrotinete ut)
        {


            db.AdaugareTrotinete.Add(ut);
            db.SaveChanges();

            return RedirectToAction("ActualizareDate");
        }


        [HttpGet]
        public ActionResult GestionareTrotinete()
        {
            return View();
        }


        [HttpPost]
        public ActionResult GestionareTrotinete(GestionareTrotinete ut)
        {


            db.GestionareTrotinete.Add(ut);
            db.SaveChanges();

            return RedirectToAction("GestionareDate");
        }


        [HttpGet]
        public ActionResult GestionareDate()
        {
            var obj = db.GestionareTrotinete.ToList();
            return View(obj);
        }





        [HttpGet]
        public ActionResult ActualizareDate(string search, string searchType)
        {
            IEnumerable<AdaugareTrotinete> model;

            ViewBag.SearchType = searchType;

            if (!string.IsNullOrEmpty(search) && !string.IsNullOrEmpty(searchType))
            {
                switch (searchType)
                {
                    case "Oras":
                        model = db.AdaugareTrotinete.Where(a => a.Oras.Equals(search));
                        break;
                    case "Nr de Trotinete":
                        model = db.AdaugareTrotinete.Where(a => a.NrTrotinete.Equals(search));
                        break;
                    default:
                        model = db.AdaugareTrotinete.ToList();
                        break;
                }
            }
            else
            {
                model = db.AdaugareTrotinete.ToList();
            }

            ViewBag.Search = search;

            return View(model);
        }



        [HttpGet]
        public ActionResult Rezervari()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Rezervari(Rezervari ut2)
        {


            db.Rezervari.Add(ut2);
            db.SaveChanges();

            return RedirectToAction("ActualizareRezervari");
        }




        [HttpGet]
        public ActionResult ActualizareRezervari()
        {
            var obj = db.Rezervari.ToList();
            return View(obj);
        }








        [HttpGet]
        public ActionResult Editează(int id)
        {
            var obj = db.AdaugareTrotinete.Find(id);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editează([Bind(Include = "Id, Oras, NrTrotinete")] AdaugareTrotinete ut)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee = db.AdaugareTrotinete.Find(ut.Id);

                if (existingEmployee != null)
                {

                    existingEmployee.Oras = ut.Oras;
                    existingEmployee.NrTrotinete = ut.NrTrotinete;

                    db.SaveChanges();

                    return RedirectToAction("ActualizareDate");
                }
            }

            return View(ut);
        }





    }
}