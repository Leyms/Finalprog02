using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Finalprog02.Models;
using Rotativa;

namespace Finalprog02.Controllers
{
    public class HabitacionesController : Controller
    {
        private ClassCContext db = new ClassCContext();

        // GET: Habitaciones
        public ActionResult Index()
        {
            return View(db.Habitaciones.ToList());
        }
        public ActionResult imprimir()
        {
            var print = new ActionAsPdf("Index");
            return print;
        }

        [HttpPost]
        public ActionResult Index(string select)
        {

            if (select == "Doble")
            {
                var abc = from a in db.Habitaciones
                          where a.Tipo_Habitacion == Tipo_Habitacion.Doble
                          select a;
                return View(abc);
            }
            else if (select == "Suite")
            {
                var abc = from a in db.Habitaciones
                          where a.Tipo_Habitacion == Tipo_Habitacion.Suite
                          select a;

                return View(abc);
            }
            else if (select == "privada")
            {
                var abc = from a in db.Habitaciones
                          where a.Tipo_Habitacion == Tipo_Habitacion.privada
                          select a;

                return View(abc);
            }

            return View(db.Habitaciones.ToList());

        }
        // GET: Habitaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassHabitaciones classHabitaciones = db.Habitaciones.Find(id);
            if (classHabitaciones == null)
            {
                return HttpNotFound();
            }
            return View(classHabitaciones);
        }

        // GET: Habitaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Habitaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Habitacion,Num_Habitacion,Tipo_Habitacion,PrecioDia_Habitacion")] ClassHabitaciones classHabitaciones)
        {
            if (ModelState.IsValid)
            {
                db.Habitaciones.Add(classHabitaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classHabitaciones);
        }

        // GET: Habitaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassHabitaciones classHabitaciones = db.Habitaciones.Find(id);
            if (classHabitaciones == null)
            {
                return HttpNotFound();
            }
            return View(classHabitaciones);
        }

        // POST: Habitaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Habitacion,Num_Habitacion,Tipo_Habitacion,PrecioDia_Habitacion")] ClassHabitaciones classHabitaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classHabitaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classHabitaciones);
        }

        // GET: Habitaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassHabitaciones classHabitaciones = db.Habitaciones.Find(id);
            if (classHabitaciones == null)
            {
                return HttpNotFound();
            }
            return View(classHabitaciones);
        }

        // POST: Habitaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassHabitaciones classHabitaciones = db.Habitaciones.Find(id);
            db.Habitaciones.Remove(classHabitaciones);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
