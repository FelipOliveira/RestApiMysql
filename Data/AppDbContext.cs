using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Perfil> Perfils { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perfil>()
                .Property(p => p.nomePerfil)
                .HasMaxLength(80);

            modelBuilder.Entity<Funcionario>()
                .Property(f => f.PrimeiroNome)
                .HasMaxLength(80);

            modelBuilder.Entity<Funcionario>()
                .HasData(
                    new Funcionario
                    {
                        Id = 1,
                        PrimeiroNome = "João",
                        UltimoNome = "Silva",
                        Cpf = "123456789",
                        //perfil = new Perfil { Id = 1, nomePerfil = "primeiro perfil"}
                    }
                );
        }
    }
}
