﻿// <auto-generated />
using System;
using MeusJogos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeusJogos.Infra.Data.EntityFramework.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201104161757_Inicio")]
    partial class Inicio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeusJogos.Contexts.AmigoContext.Domain.Entities.Amigo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Amigos");
                });

            modelBuilder.Entity("MeusJogos.Contexts.EmprestimoContext.Domain.Entities.Emprestimo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Amigo_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataDevolucao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEmprestimo")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Jogo_Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Amigo_Id");

                    b.HasIndex("Jogo_Id");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("MeusJogos.Contexts.JogoContext.Domain.Entities.Jogo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Plataforma")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("MeusJogos.Contexts.AmigoContext.Domain.Entities.Amigo", b =>
                {
                    b.OwnsOne("MeusJogos.Contexts.AmigoContext.Domain.ValueObjects.Celular", "Celular", b1 =>
                        {
                            b1.Property<Guid>("AmigoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Ddd")
                                .IsRequired()
                                .HasColumnName("Ddd")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("Numero")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AmigoId");

                            b1.ToTable("Amigos");

                            b1.WithOwner()
                                .HasForeignKey("AmigoId");
                        });

                    b.OwnsOne("MeusJogos.Contexts.AmigoContext.Domain.ValueObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid>("AmigoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("PrimeiroNome")
                                .IsRequired()
                                .HasColumnName("PrimeiroNome")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SobreNome")
                                .IsRequired()
                                .HasColumnName("SobreNome")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AmigoId");

                            b1.ToTable("Amigos");

                            b1.WithOwner()
                                .HasForeignKey("AmigoId");
                        });
                });

            modelBuilder.Entity("MeusJogos.Contexts.EmprestimoContext.Domain.Entities.Emprestimo", b =>
                {
                    b.HasOne("MeusJogos.Contexts.AmigoContext.Domain.Entities.Amigo", "Amigo")
                        .WithMany()
                        .HasForeignKey("Amigo_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MeusJogos.Contexts.JogoContext.Domain.Entities.Jogo", "Jogo")
                        .WithMany()
                        .HasForeignKey("Jogo_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MeusJogos.Contexts.JogoContext.Domain.Entities.Jogo", b =>
                {
                    b.OwnsOne("MeusJogos.Contexts.JogoContext.Domain.ValueObjects.Titulo", "Titulo", b1 =>
                        {
                            b1.Property<Guid>("JogoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Nome")
                                .IsRequired()
                                .HasColumnName("Nome")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("JogoId");

                            b1.ToTable("Jogos");

                            b1.WithOwner()
                                .HasForeignKey("JogoId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
