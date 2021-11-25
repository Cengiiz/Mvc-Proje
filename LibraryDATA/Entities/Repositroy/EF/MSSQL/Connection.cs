using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LibraryDAL.Entities.Repository.EF.MSSQL
{
    public partial class Connection : DbContext
    {
        public Connection()
            : base("name=Connection")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books)
                .WithOptional(e => e.Author)
                .HasForeignKey(e => e.Authorldentity);

            modelBuilder.Entity<Book>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Books)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.CategoryIdentity);
        }
    }
}
