using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProConsulta.Models;

namespace ProConsulta.Data;

public static class SeedConstants
{
    // Roles
    public const string RoleAtendenteId = "3f2c4a8e-1b9d-4c3f-8a67-2d9f5b1c0e34";
    public const string RoleMedicoId = "e1a5d2c7-7f21-4b98-b3d0-6f4a12c9e5af";

    // User (ATENÇÃO: este é o Id do usuário)
    public const string UserAtendenteId = "a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6";

    // Stamps fixos (estáticos)
    public const string RoleAtendenteStamp = "stamp-role-atendente-001";
    public const string RoleMedicoStamp = "stamp-role-medico-001";
    public const string UserSecurityStamp = "stamp-user-proconsulta-001";
    public const string UserConcurrency = "4a4f6be0-77b6-4144-85d6-52f359b00f12";
}

public class DbInitializer
{
    private readonly ModelBuilder _modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    internal void seed()
    {
        // ROLES
        _modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = SeedConstants.RoleAtendenteId,
                Name = "Atendente",
                NormalizedName = "ATENDENTE",
                ConcurrencyStamp = SeedConstants.RoleAtendenteStamp
            },
            new IdentityRole
            {
                Id = SeedConstants.RoleMedicoId,
                Name = "Medico",
                NormalizedName = "MEDICO",
                ConcurrencyStamp = SeedConstants.RoleMedicoStamp
            }
        );

        // USUÁRIO (tipo Atendente deve herdar de IdentityUser)
        _modelBuilder.Entity<Atendente>().HasData(
            new Atendente
            {
                Id = SeedConstants.UserAtendenteId,                // ✅ Id do USUÁRIO (corrigido)
                UserName = "pro Consulta",
                NormalizedUserName = "PRO CONSULTA",
                Email = "proconsulta@hotmail.com.br",
                NormalizedEmail = "PROCONSULTA@HOTMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEJaw1R/m+bW0RbWocLmYKp6+m5ryifl1REchJtLAJDH88zwJXABebAsP1JOPrPp/mw==",
                SecurityStamp = SeedConstants.UserSecurityStamp,
                ConcurrencyStamp = SeedConstants.UserConcurrency,
                Nome = "Pro Consulta"
            }
        );

        // VÍNCULO USER ↔ ROLE (usa os mesmos IDs acima)
        _modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = SeedConstants.RoleAtendenteId,
                UserId = SeedConstants.UserAtendenteId
            }
        );

        // ESPECIALIDADES
        _modelBuilder.Entity<Especialidade>().HasData(
            new Especialidade { Id = 1, Nome = "Cardiologia", Descricao = "Especialidade médica que se dedica ao estudo, diagnóstico e tratamento das doenças do coração e do sistema circulatório." },
            new Especialidade { Id = 2, Nome = "Dermatologia", Descricao = "Especialidade médica que se ocupa do diagnóstico e tratamento das doenças da pele, cabelos e unhas." },
            new Especialidade { Id = 3, Nome = "Neurologia", Descricao = "Especialidade médica que se dedica ao estudo, diagnóstico e tratamento das doenças do sistema nervoso." },
            new Especialidade { Id = 4, Nome = "Pediatria", Descricao = "Especialidade médica que se ocupa do cuidado da saúde de crianças e adolescentes." },
            new Especialidade { Id = 5, Nome = "Psiquiatria", Descricao = "Especialidade médica que se dedica ao estudo, diagnóstico e tratamento dos transtornos mentais." },
            new Especialidade { Id = 6, Nome = "Ortopedia", Descricao = "Especialidade médica que se dedica ao diagnóstico e tratamento das doenças e lesões do sistema musculoesquelético." },
            new Especialidade { Id = 7, Nome = "Ginecologia", Descricao = "Especialidade médica que se ocupa da saúde do sistema reprodutor feminino e das mamas." },
            new Especialidade { Id = 8, Nome = "Oftalmologia", Descricao = "Especialidade médica que se dedica ao estudo, diagnóstico e tratamento das doenças dos olhos." },
            new Especialidade { Id = 9, Nome = "Endocrinologia", Descricao = "Especialidade médica que trata dos distúrbios hormonais e das glândulas endócrinas." },
            new Especialidade { Id = 10, Nome = "Gastroenterologia", Descricao = "Especialidade médica que se ocupa do diagnóstico e tratamento das doenças do sistema digestivo." },
            new Especialidade { Id = 11, Nome = "Urologia", Descricao = "Especialidade médica que trata das doenças do trato urinário e do sistema reprodutor masculino." },
            new Especialidade { Id = 12, Nome = "Oncologia", Descricao = "Especialidade médica dedicada ao estudo e tratamento do câncer." },
            new Especialidade { Id = 13, Nome = "Otorrinolaringologia", Descricao = "Especialidade médica que trata das doenças do ouvido, nariz e garganta." },
            new Especialidade { Id = 14, Nome = "Reumatologia", Descricao = "Especialidade médica que se dedica ao diagnóstico e tratamento das doenças reumáticas e autoimunes." },
            new Especialidade { Id = 15, Nome = "Nefrologia", Descricao = "Especialidade médica que trata das doenças dos rins e do sistema urinário." }
        );
    }
}
