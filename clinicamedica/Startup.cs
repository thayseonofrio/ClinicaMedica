using System;
using Microsoft.Owin;
using Owin;
using clinicamedica.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using clinicamedica;

[assembly: OwinStartupAttribute(typeof(clinicamedica.Startup))]
namespace clinicamedica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            BancoContexto context = new BancoContexto();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
               
            }

            if(!roleManager.RoleExists("Medico"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Medico";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Secretaria"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Secretaria";
                roleManager.Create(role);
            }

            

        }
    }
}
