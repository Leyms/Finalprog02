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
    public class PacientesController : Controller
    {
        private ClassCContext db = new ClassCContext();

        // GET: Pacientes
        public ActionResult Index()
        {
            return View(db.Pacientes.ToList());
        }
        public ActionResult imprimir()
        {
            var print = new ActionAsPdf("Index");
            return print;
        }
        [HttpPost]
        public ActionResult Index(string busqueda, string select , string PressBoton)
        {
            if (select == "Nombre_Paciente")
            {
                var abc = from a in db.Pacientes
                              //where a.Nombre_Paciente == busqueda
                          select a;
                abc = abc.Where(s => s.Nombre_Paciente.Contains(busqueda));
                return View(abc);
            }
            else if (select == "Cedula_Paciente")
            {
                var abc = from a in db.Pacientes
                          where a.Cedula_Paciente == busqueda
                          select a;

                return View(abc);
            }
          
            else if (PressBoton == "Asegurado")
            {
                var abc = from a in db.Pacientes
                          where a.Asegurado.Equals(true)
                          select a;
                return View(abc);
            }
            else if (PressBoton == "No Asegurado")
            {
                var abc = from a in db.Pacientes
                          where a.Asegurado.Equals(false)
                          select a;
                return View(abc);
            }

            return View(db.Pacientes.ToList());

        }
        // GET: Pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassPacientes classPacientes = db.Pacientes.Find(id);
            if (classPacientes == null)
            {
                return HttpNotFound();
            }
            return View(classPacientes);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Paciente,Nombre_Paciente,Cedula_Paciente,Asegurado")] ClassPacientes classPacientes)
        {
            if (ModelState.IsValid)
            {
                db.Pacientes.Add(classPacientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classPacientes);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassPacientes classPacientes = db.Pacientes.Find(id);
            if (classPacientes == null)
            {
                return HttpNotFound();
            }
            return View(classPacientes);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Paciente,Nombre_Paciente,Cedula_Paciente,Asegurado")] ClassPacientes classPacientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classPacientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classPacientes);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassPacientes classPacientes = db.Pacientes.Find(id);
            if (classPacientes == null)
            {
                return HttpNotFound();
            }
            return View(classPacientes);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassPacientes classPacientes = db.Pacientes.Find(id);
            db.Pacientes.Remove(classPacientes);
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
