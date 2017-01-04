namespace clinicamedica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administradors",
                c => new
                    {
                        IDAdmin = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        RG = c.String(nullable: false, maxLength: 10),
                        Telefone = c.String(nullable: false, maxLength: 15),
                        Endereco = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDAdmin);
            
            CreateTable(
                "dbo.Consultas",
                c => new
                    {
                        IDConsulta = c.Int(nullable: false, identity: true),
                        IDPaciente = c.Int(nullable: false),
                        IDMedico = c.Int(nullable: false),
                        PlanoDeSaude = c.String(),
                        Data = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Comparecimento = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IDConsulta)
                .ForeignKey("dbo.Medicos", t => t.IDMedico, cascadeDelete: true)
                .ForeignKey("dbo.Pacientes", t => t.IDPaciente, cascadeDelete: true)
                .Index(t => t.IDPaciente)
                .Index(t => t.IDMedico);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        IDMedico = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                        RG = c.String(nullable: false, maxLength: 10),
                        Telefone = c.String(nullable: false, maxLength: 15),
                        Endereco = c.String(nullable: false),
                        Especialidade = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDMedico);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        IDPaciente = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Telefone = c.String(nullable: false, maxLength: 15),
                        Nascimento = c.DateTime(nullable: false),
                        Endereco = c.String(),
                        Observacao = c.String(),
                    })
                .PrimaryKey(t => t.IDPaciente);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Secretarias",
                c => new
                    {
                        IDSecretaria = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        RG = c.String(nullable: false, maxLength: 10),
                        Telefone = c.String(nullable: false, maxLength: 15),
                        Endereco = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDSecretaria);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Consultas", "IDPaciente", "dbo.Pacientes");
            DropForeignKey("dbo.Consultas", "IDMedico", "dbo.Medicos");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Consultas", new[] { "IDMedico" });
            DropIndex("dbo.Consultas", new[] { "IDPaciente" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Secretarias");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Medicos");
            DropTable("dbo.Consultas");
            DropTable("dbo.Administradors");
        }
    }
}
