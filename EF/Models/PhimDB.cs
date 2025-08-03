using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EF.Models
{
    public partial class PhimDB : DbContext
    {
        public PhimDB()
            : base("name=PhimDB")
        {
        }

        public virtual DbSet<LoaiPhim> LoaiPhim { get; set; }
        public virtual DbSet<Phim> Phim { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiPhim>()
                .Property(e => e.ID_LoaiPhim)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiPhim>()
                .HasMany(e => e.Phim)
                .WithRequired(e => e.LoaiPhim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Phim>()
                .Property(e => e.Anh)
                .IsUnicode(false);

            modelBuilder.Entity<Phim>()
                .Property(e => e.ID_LoaiPhim)
                .IsUnicode(false);
        }
    }
}
