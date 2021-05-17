﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data;

namespace WebApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("WebApi.Data.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext");

                    b.Property<int>("PerfilId")
                        .HasColumnType("int");

                    b.Property<string>("PrimeiroNome")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("UltimoNome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("WebApi.Data.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nomePerfil")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Perfis");
                });

            modelBuilder.Entity("WebApi.Data.Funcionario", b =>
                {
                    b.HasOne("WebApi.Data.Perfil", "perfil")
                        .WithMany("funcionarios")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("perfil");
                });

            modelBuilder.Entity("WebApi.Data.Perfil", b =>
                {
                    b.Navigation("funcionarios");
                });
#pragma warning restore 612, 618
        }
    }
}
