using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.EntityFrameworkCore;

namespace QuanLiKyTucXa.Models;

public partial class QlktxContext : DbContext
{
    public QlktxContext()
    {
    }

    public QlktxContext(DbContextOptions<QlktxContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GiuongNgu> GiuongNgus { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HoaDonPhong> HoaDonPhongs { get; set; }

    public virtual DbSet<Khu> Khus { get; set; }

    public virtual DbSet<PhieuDangKy> PhieuDangKies { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }
    public virtual DbSet<AdminAccount> AdminAccounts { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GiuongNgu>(entity =>
        {
            entity.HasKey(e => e.SoGiuong);

            entity.ToTable("GiuongNgu");

            entity.Property(e => e.SoGiuong)
                .ValueGeneratedNever()
                .HasColumnName("soGiuong");
            entity.Property(e => e.Mp).HasColumnName("mp");
            entity.Property(e => e.Mssv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mssv");

            entity.HasOne(d => d.MssvNavigation).WithMany(p => p.GiuongNgus)
                .HasForeignKey(d => d.Mssv)
                .HasConstraintName("FK_GiuongNgu_SinhVien");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.Mp);

            entity.ToTable("HoaDon");

            entity.Property(e => e.Mp)
                .ValueGeneratedNever()
                .HasColumnName("mp");
            entity.Property(e => e.ChiSoCuoi).HasColumnName("chiSoCuoi");
            entity.Property(e => e.ChiSoDau).HasColumnName("chiSoDau");
            entity.Property(e => e.GiaDien).HasColumnName("giaDien");
            entity.Property(e => e.GiaNuoc).HasColumnName("giaNuoc");
            entity.Property(e => e.Thang).HasColumnName("thang");
            entity.Property(e => e.TrangThai).HasColumnName("trangThai");

            entity.HasOne(d => d.MpNavigation).WithOne(p => p.HoaDon)
                .HasForeignKey<HoaDon>(d => d.Mp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDon_Phong");
        });

        modelBuilder.Entity<HoaDonPhong>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon);

            entity.ToTable("HoaDonPhong");

            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maHoaDon");
            entity.Property(e => e.Mssv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mssv");
            entity.Property(e => e.Quy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("quy");
            entity.Property(e => e.SoTien).HasColumnName("soTien");
            entity.Property(e => e.TrangThai).HasColumnName("trangThai");

            entity.HasOne(d => d.MssvNavigation).WithMany(p => p.HoaDonPhongs)
                .HasForeignKey(d => d.Mssv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDonPhong_SinhVien");
        });

        modelBuilder.Entity<Khu>(entity =>
        {
            entity.HasKey(e => e.KhuVuc);

            entity.ToTable("Khu");

            entity.Property(e => e.KhuVuc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("khuVuc");
            entity.Property(e => e.Loai).HasColumnName("loai");
            entity.Property(e => e.ViTri)
                .HasMaxLength(50)
                .HasColumnName("viTri");
        });

        modelBuilder.Entity<PhieuDangKy>(entity =>
        {
            entity.HasKey(e => e.MaHoSo);

            entity.ToTable("PhieuDangKy");

            entity.Property(e => e.MaHoSo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maHoSo");
            entity.Property(e => e.Mssv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mssv");
            entity.Property(e => e.TinhTrang)
                .HasMaxLength(50)
                .HasColumnName("tinhTrang");

            entity.HasOne(d => d.MssvNavigation).WithMany(p => p.PhieuDangKies)
                .HasForeignKey(d => d.Mssv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhieuDangKy_SinhVien");
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.Mp);

            entity.ToTable("Phong");

            entity.Property(e => e.Mp)
                .ValueGeneratedNever()
                .HasColumnName("mp");
            entity.Property(e => e.KhuVuc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("khuVuc");
            entity.Property(e => e.SoLuongSvhienTai).HasColumnName("soLuongSVHienTai");
            entity.Property(e => e.SoLuongSvtoiDa).HasColumnName("soLuongSVToiDa");

            entity.HasOne(d => d.KhuVucNavigation).WithMany(p => p.Phongs)
                .HasForeignKey(d => d.KhuVuc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phong_Khu");
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.Mssv);

            entity.ToTable("SinhVien");

            entity.Property(e => e.Mssv)
                .HasColumnType("varchar(10)")
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mssv");
            entity.Property(e => e.GioiTinh).HasColumnName("gioiTinh");
            entity.Property(e => e.HoTen)
                .HasMaxLength(50)
                .HasColumnName("hoTen");
            entity.Property(e => e.Khoa)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("khoa");
            entity.Property(e => e.Lop)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lop");
            entity.Property(e => e.Mp).HasColumnName("mp");
            entity.Property(e => e.NgaySinh)
                .HasColumnType("date")
                .HasColumnName("ngaySinh");
            entity.Property(e => e.Sdt)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("sdt");
            entity.Property(e => e.SoGiuong).HasColumnName("soGiuong");

            entity.HasOne(d => d.MpNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.Mp)
                .HasConstraintName("FK_SinhVien_Phong");
        });

        modelBuilder.Entity<AdminAccount>(e =>
        {
            e.HasIndex(p => p.TaiKhoan).IsUnique();
            e.Property(p => p.TaiKhoan).HasColumnType("varchar(30)");
            
            e.Property(e => e.MatKhau).HasColumnType("varchar(30)");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
