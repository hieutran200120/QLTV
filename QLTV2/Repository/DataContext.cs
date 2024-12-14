namespace QLTV2.Repository
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using QLTV2.Models;

    public class DataContext : IdentityDbContext<AppUserModel >
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // DbSet cho các bảng
        public DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public DbSet<TuaSach> TuaSaches { get; set; }
        public DbSet<ThuVien> ThuViens { get; set; }
        public DbSet<SachTacGia> SachTacGias { get; set; }
        public DbSet<DocGia> DocGias { get; set; }
        public DbSet<CuonSach> CuonSaches { get; set; }
        public DbSet<MuonSach> MuonSaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình NhaXuatBan
            modelBuilder.Entity<NhaXuatBan>()
                .HasKey(nxb => nxb.TenNXB);

            modelBuilder.Entity<NhaXuatBan>()
                .HasMany(nxb => nxb.TuaSaches)
                .WithOne(ts => ts.NhaXuatBan)
                .HasForeignKey(ts => ts.TenNXB)
                .HasPrincipalKey(nxb => nxb.TenNXB);

            // Cấu hình TuaSach
            modelBuilder.Entity<TuaSach>()
                .HasKey(ts => ts.TuaSachID);

            // Cấu hình ThuVien
            modelBuilder.Entity<ThuVien>()
                .HasKey(tv => tv.MaThuVien);

            // Cấu hình SachTacGia
            modelBuilder.Entity<SachTacGia>()
                .HasKey(stg => new { stg.TuaSachID, stg.TenTacGia });

            modelBuilder.Entity<SachTacGia>()
                .HasOne(stg => stg.TuaSach)
                .WithMany()
                .HasForeignKey(stg => stg.TuaSachID);

            // Cấu hình DocGia
            modelBuilder.Entity<DocGia>()
                .HasKey(dg => dg.SoTheDG);

            // Cấu hình CuonSach
            modelBuilder.Entity<CuonSach>()
                .HasKey(cs => new { cs.MaTuaSach, cs.MaThuVien });

            modelBuilder.Entity<CuonSach>()
                .HasOne(cs => cs.TuaSach)
                .WithMany()
                .HasForeignKey(cs => cs.MaTuaSach);

            modelBuilder.Entity<CuonSach>()
                .HasOne(cs => cs.ThuVien)
                .WithMany()
                .HasForeignKey(cs => cs.MaThuVien);

            // Cấu hình MuonSach
            modelBuilder.Entity<MuonSach>()
                .HasKey(ms => new { ms.MaTuaSach, ms.MaThuVien, ms.SoTheDG });

            modelBuilder.Entity<MuonSach>()
                .HasOne(ms => ms.TuaSach)
                .WithMany()
                .HasForeignKey(ms => ms.MaTuaSach);

            modelBuilder.Entity<MuonSach>()
                .HasOne(ms => ms.ThuVien)
                .WithMany()
                .HasForeignKey(ms => ms.MaThuVien);

            modelBuilder.Entity<MuonSach>()
                .HasOne(ms => ms.DocGia)
                .WithMany()
                .HasForeignKey(ms => ms.SoTheDG);

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(e => new { e.LoginProvider, e.ProviderKey });

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasKey(e => new { e.UserId, e.RoleId });

            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
        }
    }

}
