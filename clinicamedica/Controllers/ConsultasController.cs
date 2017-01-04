using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using clinicamedica.Models;
using PagedList;

namespace clinicamedica.Controllers
{
    [Authorize]
    public class ConsultasController : Controller
    {
        private BancoContexto db = new BancoContexto();

       
        // GET: Consultas
        public ActionResult Index(string sortOrder)
        {
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            //ViewBag.TimeSortParm = sortOrder == "Time" ? "time_desc" : "Time";
            //ViewBag.MedicoSortParm = String.IsNullOrEmpty(sortOrder) ? "med_desc" : "";
            //ViewBag.PlanoSortParm = String.IsNullOrEmpty(sortOrder) ? "plano_desc" : "";

            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.TimeSortParm = sortOrder == "Time" ? "time_desc" : "Time";
            ViewBag.MedicoSortParm = sortOrder == "Med" ? "med_desc" : "Med";
            ViewBag.PlanoSortParm = sortOrder == "Plano" ? "plano_desc" : "Plano";

            var consultas = db.Consultas.Include(c => c.medico).Include(c => c.paciente);
            var con = from c in consultas
                      select c;
            switch(sortOrder)
            {
                case "Name":
                    con = con.OrderBy(c => c.paciente.Nome);
                    break;
                case "name_desc":
                    con = con.OrderByDescending(c => c.paciente.Nome);
                    break;
                case "Med":
                    con = con.OrderBy(c => c.medico.Nome);
                    break;
                case "med_desc":
                    con = con.OrderByDescending(c => c.medico.Nome);
                    break;
                case "Plano":
                    con = con.OrderBy(c => c.PlanoDeSaude);
                    break;
                case "plano_desc":
                    con = con.OrderByDescending(c => c.PlanoDeSaude);
                    break;
                case "Date":
                    con = con.OrderBy(c => c.Data).ThenBy(c=>c.Time);
                    break;
                case "date_desc":
                    con = con.OrderByDescending(c => c.Data);
                    break;
                case "Time":
                    con = con.OrderBy(c => c.Time);
                    break;
                case "Time_desc":
                    con = con.OrderByDescending(c => c.Time);
                    break;
                default:
                    con = con.OrderBy(c => c.Data).ThenBy(c => c.Time);
                    break;
            }

            
          
            return View(con.ToList());
        }
        


        // GET: Consultas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consultas.Find(id);
            
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // GET: Consultas/Create
        [Authorize(Roles ="Admin, Secretaria")]
        public ActionResult Create()
        {
            ViewBag.IDMedico = new SelectList(db.Medicos, "IDMedico", "Nome");
            ViewBag.IDPaciente = new SelectList(db.Pacientes, "IDPaciente", "Nome");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Secretaria")]
        public ActionResult Create(Consulta consulta)
        {
            var teste = db.Consultas.Where(ag => ag.Time == consulta.Time && ag.Data == consulta.Data);
            if (teste.Any())
            {

                TempData["Erro"] = "Já há uma consulta marcada para este horário";
                return RedirectToAction("Create");
            }
            if ((consulta.Data.Date < DateTime.Now.Date) || (consulta.Data.Year > DateTime.Now.Year + 2))
            {
                TempData["DataInvalida"] = "A data inserida não é válida";
                return RedirectToAction("Create");
            }
            if (ModelState.IsValid)
            {
                db.Consultas.Add(consulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
            ViewBag.IDMedico = new SelectList(db.Medicos, "IDMedico", "Nome", consulta.IDMedico);
            ViewBag.IDPaciente = new SelectList(db.Pacientes, "IDPaciente", "Nome", consulta.IDPaciente);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        [Authorize(Roles = "Admin, Secretaria")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.IDMedico = new SelectList(db.Medicos, "IDMedico", "Nome", consulta.IDMedico);
            ViewBag.IDPaciente = new SelectList(db.Pacientes, "IDPaciente", "Nome", consulta.IDPaciente);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Secretaria")]
        public ActionResult Edit([Bind(Include = "IDConsulta,IDPaciente,IDMedico,PlanoDeSaude,Data,Time,Comparecimento")] Consulta consulta)
        {
            if ((consulta.Data.Date < DateTime.Now.Date) || (consulta.Data.Year > DateTime.Now.Year + 2))
            {
                TempData["DataInvalida"] = "A data inserida não é válida";
                return RedirectToAction("Edit");
            }

            if (ModelState.IsValid)
            {
                db.Entry(consulta).State = EntityState.Modified;
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            
            ViewBag.IDMedico = new SelectList(db.Medicos, "IDMedico", "Nome", consulta.IDMedico);
            ViewBag.IDPaciente = new SelectList(db.Pacientes, "IDPaciente", "Nome", consulta.IDPaciente);
            
            return View(consulta);
        }


        // GET: Consultas/Delete/5
        [Authorize(Roles = "Admin, Secretaria")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Secretaria")]
        public ActionResult DeleteConfirmed(int id)
        {
            Consulta consulta = db.Consultas.Find(id);
            db.Consultas.Remove(consulta);
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
