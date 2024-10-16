using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace Data.Context
{
    public class KutuphaneDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Kullanici { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }


        public KutuphaneDbContext(DbContextOptions<KutuphaneDbContext> options) : base(options)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
       .Property(b => b.Id)
       .ValueGeneratedOnAdd(); 

            // İlişkilerin tanımlanması
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Yazar)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.YazarId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.YayinEvi)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.YayinEviId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Kategori)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.KategoriId);

            modelBuilder.Entity<Book>()
    .Property(b => b.Fiyat)
    .HasColumnType("decimal(18,4)");
        }
    }
}
