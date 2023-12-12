using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BookManager_Model.Models
{
    public partial class BookManagerDBContext : DbContext
    {
        public BookManagerDBContext()
        {
        }

        public BookManagerDBContext(DbContextOptions<BookManagerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookInStorage> BookInStorages { get; set; } = null!;
        public virtual DbSet<Storage> Storages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            string conn = configuration["ConnectionString:BookManagerDB"];
            return conn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Role).HasMaxLength(20);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Author).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ReleaseYear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<BookInStorage>(entity =>
            {
                entity.ToTable("BookInStorage");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookInStorages)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_BookInStorage_Book");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.BookInStorages)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_BookInStorage_Storage");
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.ToTable("Storage");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
