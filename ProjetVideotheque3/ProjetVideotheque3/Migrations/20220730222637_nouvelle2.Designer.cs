﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetVideotheque3.Services;

namespace ProjetVideotheque3.Migrations
{
    [DbContext(typeof(VideothequeDbContext))]
    [Migration("20220730222637_nouvelle2")]
    partial class nouvelle2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("ProjetVideotheque3.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Affiche")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateSortie")
                        .HasColumnType("TEXT");

                    b.Property<int>("Duree")
                        .HasColumnType("INTEGER");

                    b.Property<double>("IMDbNote")
                        .HasColumnType("REAL");

                    b.Property<string>("LienBandeAnnonce")
                        .HasColumnType("TEXT");

                    b.Property<int>("Note")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Synopsis")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("ProjetVideotheque3.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Libelle")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("ProjetVideotheque3.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Contenu")
                        .HasColumnType("BLOB");

                    b.Property<bool>("EstImagePrincipale")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdFilm")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdFilm");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ProjetVideotheque3.Models.Personne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Personnes");
                });

            modelBuilder.Entity("ProjetVideotheque3.Models.Image", b =>
                {
                    b.HasOne("ProjetVideotheque3.Models.Film", "Film")
                        .WithMany("Images")
                        .HasForeignKey("IdFilm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");
                });

            modelBuilder.Entity("ProjetVideotheque3.Models.Film", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
