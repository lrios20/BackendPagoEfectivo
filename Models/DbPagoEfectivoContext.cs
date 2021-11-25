using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PagoEfectivoApi.Models
{
    public partial class DbPagoEfectivoContext : DbContext
    {
        public DbPagoEfectivoContext()
        {
        }

        public DbPagoEfectivoContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<codePromotion> codePromotions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-KK4E0UR\\SQLEXPRESS;Initial Catalog=pagoefectivo;User ID=sa;Password=200616");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<codePromotion>(entity =>
            {
                entity.ToTable("codePromotion");

                entity.Property(e => e.code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.mail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
