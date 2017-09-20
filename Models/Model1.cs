namespace WebApplication2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Domain_ChucDanh> Domain_ChucDanh { get; set; }
        public virtual DbSet<Domain_CuaHang> Domain_CuaHang { get; set; }
        public virtual DbSet<Domain_PhongBan> Domain_PhongBan { get; set; }
        public virtual DbSet<Domain> Domains { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain_CuaHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<Domain_PhongBan>()
                .Property(e => e.LienHe)
                .IsUnicode(false);

            modelBuilder.Entity<Domain_PhongBan>()
                .Property(e => e.PhongBanCode)
                .IsUnicode(false);
        }
    }
}
