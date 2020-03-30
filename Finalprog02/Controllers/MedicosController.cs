using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Finalprog02.Models;

namespace Finalprog02.Controllers
{
    public class MedicosController : Controller
    {
        private ClassCContext db = new ClassCContext();

        // GET: Medicos
        public ActionResult Index()
        {
            return View(db.Medicos.ToList());
        }

        // GET: Medicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassMedicos classMedicos = db.Medicos.Find(id);
            if (classMedicos == null)
            {
                return HttpNotFound();
            }
            return View(classMedicos);
        }

        // GET: Medicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Medico,Nombre_Medico,Exequátur_Medico,Especialidad_Medico")] ClassMedicos classMedicos)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(classMedicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classMedicos);
        }

        // GET: Medicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassMedicos classMedicos = db.Medicos.Find(id);
            if (classMedicos == null)
            {
                return HttpNotFound();
            }
            return View(classMedicos);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Medico,Nombre_Medico,Exequátur_Medico,Especialidad_Medico")] ClassMedicos classMedicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classMedicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classMedicos);
        }

        // GET: Medicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassMedicos classMedicos = db.Medicos.Find(id);
            if (classMedicos == null)
            {
                return HttpNotFound();
            }
            return View(classMedicos);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassMedicos classMedicos = db.Medicos.Find(id);
            db.Medicos.Remove(classMedicos);
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
