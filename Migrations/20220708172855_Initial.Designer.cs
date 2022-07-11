﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebService.Financeiro.Data;

namespace WebService.Financeiro.Migrations
{
    [DbContext(typeof(WebServiceFinanceiroContext))]
    [Migration("20220708172855_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebService.Financeiro.Model.Gasto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("GastoDia")
                        .HasColumnName("gasto_dia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Local")
                        .HasColumnName("local")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnName("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pagamento")
                        .HasColumnName("pagamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnName("tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnName("valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("gastos");
                });
#pragma warning restore 612, 618
        }
    }
}