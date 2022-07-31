using Microsoft.EntityFrameworkCore;
using ProjetVideotheque3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjetVideotheque3.Services
{
    internal class VideothequeDbContext : DbContext
    {
        public string DatabasePath { get; private set; }

        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Personne> Personnes { get; set; }



        public VideothequeDbContext()
            : this(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DbFilmsXamarin.db"))
        { }
        public VideothequeDbContext(string databasePath) : base()
        {
            SQLitePCL.Batteries_V2.Init();
            DatabasePath = databasePath;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Définition d'une clé primaire composée
            //modelBuilder.Entity<Models.Author>().HasKey(a => new { a.Id, a.FirstName });
            // Définition d'un index unique
            //modelBuilder.Entity<Models.Author>().HasIndex(a => a.LastName).IsUnique();
            // Définition d'une clé étrangère
            //modelBuilder.Entity<Models.Author>().HasMany<Models.Book>().WithOne(b => b.Author).HasForeignKey(b => b.AuthorId);

        }

    }
}
