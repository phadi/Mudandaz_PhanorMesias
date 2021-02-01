using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Mudandaz_PhanorMesias.Models
{
    public partial class sbMudanzaPMContext : DbContext
    {
        public sbMudanzaPMContext()
        {
        }

        public sbMudanzaPMContext(DbContextOptions<sbMudanzaPMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbModule> TbModules { get; set; }
        public virtual DbSet<TbUser> TbUsers { get; set; }
        public virtual DbSet<TnUserAuthorization> TnUserAuthorizations { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=PMESIAS-PC\\SQLEXPRESS;Database=sbMudanzaPM;user id=sa;pwd=Chacho410*;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TbModule>(entity =>
            {
                entity.HasKey(e => e.ModuleId);

                entity.ToTable("tbModule");

                entity.Property(e => e.ModuleId).HasColumnName("moduleId");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Module)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("module");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tbUser");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("login");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<TnUserAuthorization>(entity =>
            {
                entity.HasKey(e => e.UserAuthorizationId);

                entity.ToTable("tnUserAuthorization");

                entity.Property(e => e.UserAuthorizationId).HasColumnName("userAuthorizationId");

                entity.Property(e => e.Module).HasColumnName("module");

                entity.Property(e => e.User).HasColumnName("user");

                entity.HasOne(d => d.ModuleNavigation)
                    .WithMany(p => p.TnUserAuthorizations)
                    .HasForeignKey(d => d.Module)
                    .HasConstraintName("FK_tnUserAuthorization_tbModule");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.TnUserAuthorizations)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("FK_tnUserAuthorization_tbUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
