using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using clinicamedica.Models;
using clinicamedica;

namespace clinicamedica.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class BancoContexto : IdentityDbContext<ApplicationUser>
    {
       
        public BancoContexto() : base("name=ConnDB", throwIfV1Schema: false) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Secretaria> Secretarias { get; set; }
        public DbSet<Medico> Medicos { get; set; }

        public static BancoContexto Create()
        {
            return new BancoContexto();
        }


    
    }
}