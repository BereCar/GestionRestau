﻿// <auto-generated />
using System;
using GestionRestau.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestionRestau.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210426142934_SecondMigratin")]
    partial class SecondMigratin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsommationProduit", b =>
                {
                    b.Property<int>("ConsommationsIDConsommation")
                        .HasColumnType("int");

                    b.Property<int>("ProduitsIDProduit")
                        .HasColumnType("int");

                    b.HasKey("ConsommationsIDConsommation", "ProduitsIDProduit");

                    b.HasIndex("ProduitsIDProduit");

                    b.ToTable("ConsommationProduit");
                });

            modelBuilder.Entity("GestionRestau.Models.Consommation", b =>
                {
                    b.Property<int>("IDConsommation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateConsommation")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDProduit")
                        .HasColumnType("int");

                    b.Property<int>("IDTable")
                        .HasColumnType("int");

                    b.Property<bool>("Paye")
                        .HasColumnType("bit");

                    b.Property<int>("QuantiteConsommation")
                        .HasColumnType("int");

                    b.Property<int?>("tableconsoIDTable")
                        .HasColumnType("int");

                    b.HasKey("IDConsommation");

                    b.HasIndex("tableconsoIDTable");

                    b.ToTable("Consommations");
                });

            modelBuilder.Entity("GestionRestau.Models.Produit", b =>
                {
                    b.Property<int>("IDProduit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategorieProduit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CentreDeRevenuProduit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionProduit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameProduit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NbPersonnesProduit")
                        .HasColumnType("int");

                    b.Property<float>("PrixProduit")
                        .HasColumnType("real");

                    b.Property<string>("StatutProduit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDProduit");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("GestionRestau.Models.Serveur", b =>
                {
                    b.Property<int>("IDServeur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameServeur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneServeur")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDServeur");

                    b.ToTable("Serveurs");
                });

            modelBuilder.Entity("GestionRestau.Models.Table", b =>
                {
                    b.Property<int>("IDTable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmplacementTable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDServeur")
                        .HasColumnType("int");

                    b.Property<int>("NbPlacesTable")
                        .HasColumnType("int");

                    b.Property<int>("NumeroTable")
                        .HasColumnType("int");

                    b.Property<bool>("OccupationTable")
                        .HasColumnType("bit");

                    b.Property<int?>("serveurIDServeur")
                        .HasColumnType("int");

                    b.HasKey("IDTable");

                    b.HasIndex("serveurIDServeur");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("ConsommationProduit", b =>
                {
                    b.HasOne("GestionRestau.Models.Consommation", null)
                        .WithMany()
                        .HasForeignKey("ConsommationsIDConsommation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionRestau.Models.Produit", null)
                        .WithMany()
                        .HasForeignKey("ProduitsIDProduit")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionRestau.Models.Consommation", b =>
                {
                    b.HasOne("GestionRestau.Models.Table", "tableconso")
                        .WithMany("Consommations")
                        .HasForeignKey("tableconsoIDTable");

                    b.Navigation("tableconso");
                });

            modelBuilder.Entity("GestionRestau.Models.Table", b =>
                {
                    b.HasOne("GestionRestau.Models.Serveur", "serveur")
                        .WithMany("Tables")
                        .HasForeignKey("serveurIDServeur");

                    b.Navigation("serveur");
                });

            modelBuilder.Entity("GestionRestau.Models.Serveur", b =>
                {
                    b.Navigation("Tables");
                });

            modelBuilder.Entity("GestionRestau.Models.Table", b =>
                {
                    b.Navigation("Consommations");
                });
#pragma warning restore 612, 618
        }
    }
}
