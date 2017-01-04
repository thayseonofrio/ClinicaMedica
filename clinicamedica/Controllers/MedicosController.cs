using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using clinicamedica.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;

namespace clinicamedica.Controllers
{
    [Authorize]
    public class MedicosController : Controller
    {
        private BancoContexto db = new BancoContexto();

        // GET: Medicos
        public ActionResult Index(string searchString)
        {
            var medicos = from m in db.Medicos
                            select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                medicos = medicos.Where(p => p.Nome.Contains(searchString));
            }

            medicos = medicos.OrderBy(m => m.Nome);
            return View(medicos.ToList());
        }


        public ActionResult _ListaConsultas(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }

            return PartialView(medico);
        }
        // GET: Medicos/Details/5


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
           
            return View(medico);
        }

        
        // GET: Medicos/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Email, Senha, IDMedico,IDPaciente,Nome,RG,Telefone,Endereco,Especialidade")] Medico medico)
        {
            if (ModelState.IsValid)
            {

                BancoContexto context = new BancoContexto();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                //Verificar se o RG já está cadastrado
                var verificarRG = db.Medicos.Where(p => p.RG.Equals(medico.RG, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                if (verificarRG != null)
                {
                    TempData["rgInvalido"] = "O RG já está cadastrado";
                    return RedirectToAction("Create");
                }

                // Verificar se email já está cadastrado
                var verificarEmail = db.Medicos.Where(p => p.Email.Equals(medico.Email, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                if (verificarEmail != null)
                {
                    TempData["emailInvalido"] = "O e-mail já está cadastrado";
                    return RedirectToAction("Create");
                }


                var user = new ApplicationUser();
                user.UserName = medico.Email;
                user.Email = medico.Email;

                string senha = medico.Senha;
                var chkUser = UserManager.Create(user, senha);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Medico");
                }
                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medico);
        }

        // GET: Medicos/Edit/5
        [Authorize(Roles = "Admin, Medico")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Medico")]
        public ActionResult Edit(Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medico);
        }

        // GET: Medicos/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = db.Medicos.Find(id);
            db.Medicos.Remove(medico);
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
