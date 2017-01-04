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

namespace clinicamedica.Controllers
{
    [Authorize]
    public class SecretariasController : Controller
    {
        private BancoContexto db = new BancoContexto();

        // GET: Secretarias
        
        public ActionResult Index()
        {
            return View(db.Secretarias.OrderBy(s=>s.Nome).ToList());
        }

        // GET: Secretarias/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretaria secretaria = db.Secretarias.Find(id);
            if (secretaria == null)
            {
                return HttpNotFound();
            }
            return View(secretaria);
        }

        // GET: Secretarias/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Secretarias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Email, Senha, IDSecretaria,Nome,RG,Telefone,Endereco")] Secretaria secretaria)
        {
            if (ModelState.IsValid)
            {
                BancoContexto context = new BancoContexto();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                //Verificar se o RG já está cadastrado
                var verificarRG = db.Secretarias.Where(p => p.RG.Equals(secretaria.RG, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                if (verificarRG != null)
                {
                    TempData["rgInvalido"] = "O RG já está cadastrado";
                    return RedirectToAction("Create");
                }

                // Verificar se email já está cadastrado
                var verificarEmail = db.Secretarias.Where(p => p.Email.Equals(secretaria.Email, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                if (verificarEmail != null)
                {
                    TempData["emailInvalido"] = "O e-mail já está cadastrado";
                    return RedirectToAction("Create");
                }


                var user = new ApplicationUser();
                user.UserName = secretaria.Email;
                user.Email = secretaria.Email;

                string senha = secretaria.Senha;
                var chkUser = UserManager.Create(user, senha);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Secretaria");
                }
                db.Secretarias.Add(secretaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(secretaria);
        }

        // GET: Secretarias/Edit/5
        [Authorize(Roles = "Admin, Secretaria")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretaria secretaria = db.Secretarias.Find(id);
            if (secretaria == null)
            {
                return HttpNotFound();
            }
            return View(secretaria);
        }

        // POST: Secretarias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Secretaria")]
        public ActionResult Edit(Secretaria secretaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secretaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(secretaria);
        }

        // GET: Secretarias/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretaria secretaria = db.Secretarias.Find(id);
            if (secretaria == null)
            {
                return HttpNotFound();
            }
            return View(secretaria);
        }

        // POST: Secretarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Secretaria secretaria = db.Secretarias.Find(id);
            db.Secretarias.Remove(secretaria);
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
