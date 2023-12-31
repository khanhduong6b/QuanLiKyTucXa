﻿using System;
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


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer("Server=localhost;Database=QLKTX;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
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
            entity.HasOne(d => d.MpNavigation).WithMany(p => p.GiuongNgus)
            .HasForeignKey(d => d.Mp)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_GiuongNgu_Phong");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon);

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHoaDon)
                .ValueGeneratedNever()
                .HasColumnName("MaHoaDon");
            entity.Property(e => e.ChiSoCuoi).HasColumnName("chiSoCuoi");
            entity.Property(e => e.ChiSoDau).HasColumnName("chiSoDau");
            entity.Property(e => e.GiaDien).HasColumnName("giaDien");
            entity.Property(e => e.GiaNuoc).HasColumnName("giaNuoc");
            entity.Property(e => e.Thang)
                .HasColumnType("date")
                .HasColumnName("thang");
            entity.Property(e => e.TrangThai).HasColumnName("trangThai");
            entity.Property(e => e.Mp).HasColumnName("maPhong");

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

            entity.HasOne(d => d.MssvNavigation)
                .WithMany(p => p.HoaDonPhongs)
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
            entity.Property(e => e.NgayVao)
                .HasColumnType("date")
                .HasColumnName("ngayVao");
            entity.Property(e => e.TinhTrang)
                .HasColumnName("tinhTrang");

            entity.HasOne(d => d.MssvNavigation).WithMany(p => p.PhieuDangKys)
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
            entity.Property(e => e.SoLuongSvHienTai).HasColumnName("soLuongSVHienTai");
            entity.Property(e => e.SoLuongSvToiDa).HasColumnName("soLuongSVToiDa");

            entity.HasMany(d => d.HoaDons) // Thêm đoạn này để chỉ ra mối quan hệ một-nhiều
                .WithOne(p => p.MpNavigation) // Ánh xạ ngược về Phòng
                .HasForeignKey(d => d.Mp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDon_Phong");

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
            entity.Property(e => e.TinhTrang)
                .HasColumnName("tinhTrang");
            entity.Property(e => e.SoGiuong).HasColumnName("soGiuong");
            entity.HasOne(d => d.MpNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.Mp)
                .HasConstraintName("FK_SinhVien_Phong");
            entity.HasOne(d => d.GiuongNguNavigation).WithOne(p => p.MssvNavigation)
            .HasForeignKey<GiuongNgu>(d => d.Mssv)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SinhVien_GiuongNgu");
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
