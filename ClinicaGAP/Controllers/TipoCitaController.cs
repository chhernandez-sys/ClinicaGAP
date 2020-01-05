using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ClinicaGAP.Models;
using ClinicaGAP.Persistence;

namespace ClinicaGAP.Controllers
{
    public class TipoCitaController : Controller
    {
        private ClinicaGAPEntities db = new ClinicaGAPEntities();

        // GET: TipoCita
        public ActionResult Index()
        {
            var unitOfWork = new UnitOfWork(db);
            var tipoCita = unitOfWork.TipoCita.GetTiposCita();
            ViewBag.ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "DESCRIPCION");

            return View(tipoCita.ToList());
        }

        // GET: TipoCita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_CITA tIPO_CITA = db.TIPO_CITA.Find(id);
            if (tIPO_CITA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_CITA);
        }

        // GET: TipoCita/Create
        public ActionResult Create()
        {
            ViewBag.ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "DESCRIPCION");
            return View();
        }

        // POST: TipoCita/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TIPO_CITA,DESCRIPCION,ESTADO")] TIPO_CITA tIPO_CITA)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_CITA.Add(tIPO_CITA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_CITA);
        }

        // GET: TipoCita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_CITA tIPO_CITA = db.TIPO_CITA.Find(id);
            if (tIPO_CITA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "DESCRIPCION", tIPO_CITA.ESTADO);
            return View(tIPO_CITA);
        }

        // POST: TipoCita/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TIPO_CITA,DESCRIPCION,ESTADO")] TIPO_CITA tIPO_CITA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_CITA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_CITA);
        }

        // GET: TipoCita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_CITA tIPO_CITA = db.TIPO_CITA.Find(id);
            if (tIPO_CITA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_CITA);
        }

        // POST: TipoCita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_CITA tIPO_CITA = db.TIPO_CITA.Find(id);
            db.TIPO_CITA.Remove(tIPO_CITA);
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