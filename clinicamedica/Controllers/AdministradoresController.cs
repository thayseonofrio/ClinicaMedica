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
using System.Web.Security;

namespace clinicamedica.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdministradoresController : Controller
    {
        private BancoContexto db = new BancoContexto();

        // GET: Administradores
        public ActionResult Index()
        {
            return View(db.Administradores.OrderBy(a=>a.Nome).ToList());
        }

        // GET: Administradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Administradores.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // GET: Administradores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administradores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email, Senha, IDAdmin,Nome,RG,Telefone,Endereco")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                BancoContexto context = new BancoContexto();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                //Verificar se o RG já está cadastrado
                var verificarRG = db.Administradores.Where(p => p.RG.Equals(administrador.RG, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                if (verificarRG != null)
                {
                    TempData["rgInvalido"] = "O RG já está cadastrado";
                    return RedirectToAction("Create");
                }

                //Verificar se email já está cadastrado
                var verificarEmail = db.Administradores.Where(p => p.Email.Equals(administrador.Email, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                if (verificarEmail != null)
                {
                    TempData["emailInvalido"] = "O e-mail já está cadastrado";
                    return RedirectToAction("Create");
                }
                

                //criar o Usuário
                var user = new ApplicationUser();
                user.UserName = administrador.Email;
                user.Email = administrador.Email;

                string senha = administrador.Senha;

            

                var chkUser = UserManager.Create(user, senha);

                //adicionar ao Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
                db.Administradores.Add(administrador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administrador);
        }


        // GET: Administradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Administradores.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // POST: Administradores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administrador);
        }

        // GET: Administradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Administradores.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // POST: Administradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrador administrador = db.Administradores.Find(id);
            db.Administradores.Remove(administrador);
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
