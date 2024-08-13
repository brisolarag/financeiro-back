﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using financeiro_back.Context;

#nullable disable

namespace financeiro_back.Migrations
{
    [DbContext(typeof(FinanceiroContext))]
    partial class FinanceiroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("financeiro_back.Models.Operacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Operacoes", (string)null);

                    b.HasDiscriminator<string>("Tipo").HasValue("Operacao");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("financeiro_back.Models.Entradas.Entrada", b =>
                {
                    b.HasBaseType("financeiro_back.Models.Operacao");

                    b.Property<string>("DeQuem")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Entrada");
                });

            modelBuilder.Entity("financeiro_back.Models.Saidas.Saida", b =>
                {
                    b.HasBaseType("financeiro_back.Models.Operacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Pagamento")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isFatura")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Saida");
                });
#pragma warning restore 612, 618
        }
    }
}
