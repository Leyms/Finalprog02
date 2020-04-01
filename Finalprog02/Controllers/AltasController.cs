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
    public class AltasController : Controller
    {
        private ClassCContext db = new ClassCContext();

        // GET: Altas
        public ActionResult Index()
        {
            var altas = db.Altas.Include(c => c.Ingresos);
            return View(altas.ToList());
        }
        public ActionResult imprimir()
        {
            var print = new ActionAsPdf("Index");
            return print;
        }

        [HttpPost]
        public ActionResult Index(string busqueda, string select, string PressBoton)
        {
            if (busqueda == string.Empty)
            {
                var altas = db.Altas.Include(c => c.Ingresos);
                return View(altas.ToList());
            }
            else if (select == string.Empty)
            {
                var altas = db.Altas.Include(c => c.Ingresos);
                return View(altas.ToList());
            }


            else if (select == "Paciente")
            {
                var altas = db.Altas.Include(c => c.Ingresos).Where(a => a.Nombre_Paciente == busqueda);
               
                //var abc = from a in db.Altas
                //          where a.Nombre_Paciente == busqueda
                //          select a;

                //return View(abc);
                ViewBag.total = altas.Sum(a => a.Monto);
                ViewBag.conteo = altas.Count();
                ViewBag.min = altas.Min(a => a.Monto);
                ViewBag.max = altas.Max(a => a.Monto);
                ViewBag.media = altas.Average(a => a.Monto);
                return View(altas.ToList());
            }
            else if (select == "Fecha")
            {
                var altas = db.Altas.Include(c => c.Ingresos).Where(a => a.Fecha_Salida == busqueda);
               

                ViewBag.total = altas.Sum(a => a.Monto);
                ViewBag.conteo = altas.Count();
                ViewBag.min = altas.Min(a => a.Monto);
                ViewBag.max = altas.Max(a => a.Monto);
                ViewBag.media = altas.Average(a => a.Monto);
                return View(altas.ToList());
            }
            //else if (PressBoton == "listacompleta")
            //{
            //    var altas = from a in db.Altas
            //              where a.Monto.Equals(true) 
            //              select a;

            //    ViewBag.total = altas.Sum(a => a.Monto);
            //    ViewBag.conteo = altas.Count();
            //    ViewBag.min = altas.Min(a => a.Monto);
            //    ViewBag.max = altas.Max(a => a.Monto);
            //    ViewBag.media = altas.Average(a => a.Monto);

            //    return View(altas);
            //}
            

            return View(db.Altas.ToList());

        }
        // GET: Altas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassAltas classAltas = db.Altas.Find(id);
            if (classAltas == null)
            {
                return HttpNotFound();
            }
            return View(classAltas);
        }

        // GET: Altas/Create
        public ActionResult Create()
        {
            ViewBag.ID_Ingreso = new SelectList(db.Ingresos, "ID_Ingresos", "ID_Ingresos");
            return View();
        }

        // POST: Altas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Altas,Nombre_Paciente,Fecha_Ingreso,Fecha_Salida,Habitacion,Monto,ID_Ingreso")] ClassAltas classAltas)
        {
            if (ModelState.IsValid)
            {
                db.Altas.Add(classAltas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Ingreso = new SelectList(db.Ingresos, "ID_Ingresos", "Fecha_Ingreso", classAltas.ID_Ingreso);
            return View(classAltas);
        }

        // GET: Altas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassAltas classAltas = db.Altas.Find(id);
            if (classAltas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Ingreso = new SelectList(db.Ingresos, "ID_Ingresos", "Fecha_Ingreso", classAltas.ID_Ingreso);
            return View(classAltas);
        }

        // POST: Altas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Altas,Nombre_Paciente,Fecha_Ingreso,Fecha_Salida,Habitacion,Monto,ID_Ingreso")] ClassAltas classAltas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classAltas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Ingreso = new SelectList(db.Ingresos, "ID_Ingresos", "Fecha_Ingreso", classAltas.ID_Ingreso);
            return View(classAltas);
        }

        // GET: Altas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassAltas classAltas = db.Altas.Find(id);
            if (classAltas == null)
            {
                return HttpNotFound();
            }
            return View(classAltas);
        }

        // POST: Altas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassAltas classAltas = db.Altas.Find(id);
            db.Altas.Remove(classAltas);
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

        [HttpPost]

        public JsonResult Nombre(int clavePaciente)
        {
            var duplicado = (from i in db.Ingresos
                             join p in db.Pacientes
                             on i.ID_Paciente equals p.ID_Paciente
                             where i.ID_Ingresos == clavePaciente
                             select p.Nombre_Paciente).ToList();
            return Json(duplicado);
        }

        public JsonResult Monto(int clavePaciente)
        {

            var duplicado = (from i in db.Ingresos
                             join h in db.Habitaciones
                             on i.ID_Habitacion equals h.ID_Habitacion
                             where i.ID_Ingresos == clavePaciente
                             select h.PrecioDia_Habitacion).ToList();
            return Json(duplicado);
        }

        public JsonResult FechaIngreso(int clavePaciente)
        {

            var duplicado = (from i in db.Ingresos
                             where i.ID_Ingresos == clavePaciente
                             select i.Fecha_Ingreso).ToList();
            return Json(duplicado);
        }

        public JsonResult NumeroHabitacion(int clavePaciente)
        {

            var duplicado = (from i in db.Ingresos
                             join h in db.Habitaciones
                             on i.ID_Habitacion equals h.ID_Habitacion
                             where i.ID_Ingresos == clavePaciente
                             select h.Num_Habitacion).ToList();
            return Json(duplicado);
        }
    }
}
