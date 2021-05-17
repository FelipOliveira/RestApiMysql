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
        public DbSet<Perfil> Perfis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Perfil>().HasMany(p => p.funcionarios);
            //modelBuilder.Entity<Funcionario>().HasOne(f => f.perfil);
           
           
            modelBuilder.Entity<Funcionario>()
                .HasOne(f => f.perfil)
                .WithMany(p=>p.funcionarios)
                .HasForeignKey(f => f.PerfilId);
           

            modelBuilder.Entity<Perfil>()
                .Property(p => p.nomePerfil)
                .HasMaxLength(80);

            modelBuilder.Entity<Funcionario>()
                .Property(f => f.PrimeiroNome)
                .HasMaxLength(80);

           /* modelBuilder.Entity<Funcionario>()
                .HasData(
                    new Funcionario
                    {
                        Id = 1,
                        PrimeiroNome = "Joãozinho",
                        UltimoNome = "da Silva",
                        Cpf = "123456789",
                        perfil = new Perfil { Id = 1, nomePerfil = "primeiro perfil"}
                    }
                );*/
        }
    }
}
