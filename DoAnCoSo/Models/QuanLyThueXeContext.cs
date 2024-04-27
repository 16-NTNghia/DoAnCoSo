using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DoAnCoSo.Models
{
	public class QuanLyThueXeContext : DbContext
	{
		public QuanLyThueXeContext(DbContextOptions<QuanLyThueXeContext>options) : base(options)
		{ 
		}

		public DbSet<TaiKhoan> TaiKhoans { get; set; }
		public DbSet<ChucVu> ChucVus { get; set; }
		public DbSet<Quyen>	quyens { get; set; }
		public DbSet<PhanQuyen>	phanQuyens { get; set; }
		public DbSet<HinhAnhXe> hinhAnhXes { get; set; }
		public DbSet<LoaiXe> loaiXes { get; set; }
		public DbSet<DiaDiem> diaDiems { get; set; }
		public DbSet<HangXe> hangXes { get; set; }
		public DbSet<Xe> xes { get; set; }
		public DbSet<DatLichThueXe> datLichThueXes { get; set; }
		public DbSet<HoaDon> hoaDons { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Thiết lập mối quan hệ một-nhiều giữa TaiKhoan và ChucVu
			modelBuilder.Entity<TaiKhoan>(entity =>
			{
				entity.HasKey(t => t.Email);

				entity.HasOne(t => t.ChucVu)
					.WithMany(c => c.TaiKhoans)
					.HasForeignKey(t => t.ID_ChucVu);

				entity.Property(t => t.MatKhau)
					.IsUnicode(false);

				entity.HasIndex(t => t.SoDienThoai)
					.IsUnique();

				entity.HasIndex(t => t.CanCuocCongDan)
					.IsUnique();

				entity.HasIndex(t => t.GiayPhepLaiXe)
					.IsUnique();
			});

			modelBuilder.Entity<ChucVu>(entity =>
			{
				entity.HasKey(cv => cv.ID_ChucVu);

				entity.Property(cv => cv.ID_ChucVu)
					.ValueGeneratedOnAdd();

			});

			modelBuilder.Entity<Quyen>(entity =>
			{
				entity.HasKey(q => q.ID_Quyen);

				entity.Property(q => q.ID_Quyen)
					.ValueGeneratedOnAdd();
			});

			// Thiết lập mối quan hệ một-nhiều giữa PhanQuyen và Quyen
			modelBuilder.Entity<PhanQuyen>(entity =>
			{
				entity.HasKey(pq => new { pq.Id_Quyen, pq.Id_ChucVu });
				
				entity.HasOne(pq => pq.Quyen)
					.WithMany(q => q.PhanQuyens)
					.HasForeignKey(pq => pq.Id_Quyen);
				
				entity.HasOne(pq => pq.ChucVu)
					.WithMany(c => c.PhanQuyens)
					.HasForeignKey(pq => pq.Id_ChucVu);
				
			});

			modelBuilder.Entity<HinhAnhXe>(entity =>
			{
				entity.HasKey(hax => hax.ID_HinhAnh);

				entity.Property(hax => hax.ID_HinhAnh)
					.ValueGeneratedOnAdd();

				entity.HasOne(hax => hax.xe)
					.WithMany(x => x.hinhAnhXes)
					.HasForeignKey(hax => hax.BienSoXe);

			});

			modelBuilder.Entity<HangXe>(entity =>
			{
				entity.HasKey(hx => hx.ID_HangXe);

				entity.Property(hx => hx.ID_HangXe)
					.ValueGeneratedOnAdd();
			});

			modelBuilder.Entity<LoaiXe>(entity =>
			{
				entity.HasKey(lx => lx.ID_LoaiXe);

				entity.Property(lx => lx.ID_LoaiXe)
					.ValueGeneratedOnAdd();
			});

			modelBuilder.Entity<DiaDiem>(entity =>
			{
				entity.HasKey(dd => dd.ID_DiaDiem);

				entity.Property(dd => dd.ID_DiaDiem)
					.ValueGeneratedOnAdd();
			});

			modelBuilder.Entity<Xe>(entity =>
			{
				entity.HasKey(x => x.BienSoXe);

				entity.HasOne(x => x.diaDiems)
					.WithMany(dd => dd.xes)
					.HasForeignKey(x => x.ID_DiaDiem);

				entity.HasOne(x => x.hangs)
					.WithMany(hx => hx.xes)
					.HasForeignKey(x => x.ID_HangXe);

				entity.HasOne(x => x.loais)
					.WithMany(lx => lx.xes)
					.HasForeignKey(x => x.ID_Loai);
			});

			modelBuilder.Entity<DatLichThueXe>(entity =>
			{
				entity.HasKey(dl => new { dl.ID_DatLich, dl.Email, dl.BienSoXe });

				entity.Property(dl => dl.ID_DatLich)
					.ValueGeneratedOnAdd();

				entity.HasOne(dl => dl.taiKhoan)
				  .WithMany(tk => tk.datLichThueXes)
				  .HasForeignKey(dl => dl.Email);

				entity.HasOne(dl => dl.Xe)
				  .WithMany(x => x.datLichThueXes)
				  .HasForeignKey(dl => dl.BienSoXe);
			});

			modelBuilder.Entity<HoaDon>(entity =>
			{
				entity.HasKey(hd => hd.Id_HoaDon);

				entity.Property(hd => hd.Id_HoaDon)
					.ValueGeneratedOnAdd();

				entity.HasOne(hd => hd.DatLichThue)
					.WithMany()
					.HasForeignKey(hd => new { hd.ID_DatLich, hd.Email, hd.BienSoXe });
			});
		}
	}
}
