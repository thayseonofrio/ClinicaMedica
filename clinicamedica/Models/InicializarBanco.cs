using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using clinicamedica.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace clinicamedica.Models
{
    public class InicializarBanco : CreateDatabaseIfNotExists<BancoContexto>
    {
        protected override void Seed(BancoContexto context)
        {
            var hasher = new PasswordHasher();
            new List<Medico>
            {
                new Medico {Email="joaosilva@hotmail.com", Senha= hasher.HashPassword("joao123"), Nome = "João da Silva", RG = "000000000", Telefone = "303021112", Endereco = "Avenida Ipiranga", Especialidade = "Clínica Geral" },
                new Medico {Email="mariacarvalho@hotmail.com", Senha= hasher.HashPassword("maria123"), Nome = "Maria Carvalho", RG = "000000000", Telefone = "99078965", Endereco = "Avenida Ipiranga", Especialidade = "Cirurgia" }
            }.ForEach(p => context.Medicos.Add(p));

            new List<Paciente>
            {
                new Paciente {Nome="Mara Santos", Telefone="2354324", Endereco="Rua Lajeado", Nascimento= new DateTime(2000, 02, 19)}
            }.ForEach(p => context.Pacientes.Add(p));

            new List<Secretaria>
            {
                new Secretaria {Nome="Ana Luiza", Email="analuiza@hotmail.com", Endereco="Av Bento Gonçalves, 785", RG="3467332", Senha=hasher.HashPassword("123456"), Telefone="23533543"},
                new Secretaria {Nome="Lucia", Email="lucia@hotmail.com", Endereco="Rua Independência 533", RG="234633", Senha=hasher.HashPassword("123456"), Telefone="234532"}
            }.ForEach(p => context.Secretarias.Add(p));

            base.Seed(context);
           
        }
       
    }
}