using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicaGAP.Models;

namespace ClinicaGAP.Controllers
{
    public class CitaController : Controller
    {
        private ClinicaGAPEntities db = new ClinicaGAPEntities();

        // GET: Cita
        public ActionResult Index()
        {
            var cITA = db.CITA.Include(c => c.ESTADO1).Include(c => c.PACIENTE).Include(c => c.TIPO_CITA1);
            return View(cITA.ToList());
        }

        // GET: Cita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITA cITA = db.CITA.Find(id);
            if (cITA == null)
            {
                return HttpNotFound();
            }
            return View(cITA);
        }

        // GET: Cita/Create
        public ActionResult Create()
        {
            ViewBag.ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "DESCRIPCION");
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "CEDULA");
            ViewBag.TIPO_CITA = new SelectList(db.TIPO_CITA, "ID_TIPO_CITA", "DESCRIPCION");
            return View();
        }

        // POST: Cita/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CITA,FECHA_CITA,TIPO_CITA,DESCRIPCION,ESTADO,ID_PACIENTE")] CITA cITA)
        {
            if (CitaEsElMismoDia(cITA.ID_PACIENTE, cITA.FECHA_CITA) == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.CITA.Add(cITA);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "DESCRIPCION", cITA.ESTADO);
                ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "CEDULA", cITA.ID_PACIENTE);
                ViewBag.TIPO_CITA = new SelectList(db.TIPO_CITA, "ID_TIPO_CITA", "DESCRIPCION", cITA.TIPO_CITA);
            }
            return View(cITA);
        }

        // GET: Cita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITA cITA = db.CITA.Find(id);
            if (cITA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "DESCRIPCION", cITA.ESTADO);
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "CEDULA", cITA.ID_PACIENTE);
            ViewBag.TIPO_CITA = new SelectList(db.TIPO_CITA, "ID_TIPO_CITA", "DESCRIPCION", cITA.TIPO_CITA);
            return View(cITA);
        }

        // POST: Cita/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CITA,FECHA_CITA,TIPO_CITA,DESCRIPCION,ESTADO,ID_PACIENTE")] CITA cITA)
        {
            if (CitaConMenosDe24HorasYEstado(cITA.ESTADO, cITA.FECHA_CITA) == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(cITA).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "DESCRIPCION", cITA.ESTADO);
                ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "CEDULA", cITA.ID_PACIENTE);
                ViewBag.TIPO_CITA = new SelectList(db.TIPO_CITA, "ID_TIPO_CITA", "DESCRIPCION", cITA.TIPO_CITA);
            }
            return View(cITA);
        }

        // GET: Cita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITA cITA = db.CITA.Find(id);
            if (cITA == null)
            {
                return HttpNotFound();
            }
            return View(cITA);
        }

        // POST: Cita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CITA cITA = db.CITA.Find(id);
            db.CITA.Remove(cITA);
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

        public Boolean CitaConMenosDe24HorasYEstado(int IdEstado, DateTime FechaCita)
        {
            List<ESTADO> Estado = db.ESTADO.ToList();
            var FechaActual = DateTime.Now;
            TimeSpan DifFechas = FechaCita - FechaActual;
            int Dias = DifFechas.Days;
            var DescripcionEstado = Estado.Where(s => s.ID_ESTADO == IdEstado).Select(s => s.DESCRIPCION).FirstOrDefault();

            if (Dias < 1 && DescripcionEstado == "Cancelada")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean CitaEsElMismoDia(int IdPaciente, DateTime FechaCita) 
        {
            List<CITA> Citas = db.CITA.ToList();
            var OtraCita = Citas.Where(s => s.ID_PACIENTE == IdPaciente).Select(s => s.FECHA_CITA).FirstOrDefault();

            if ((OtraCita.Day == FechaCita.Day) && (OtraCita.Month == FechaCita.Month) && (OtraCita.Year == FechaCita.Year))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}