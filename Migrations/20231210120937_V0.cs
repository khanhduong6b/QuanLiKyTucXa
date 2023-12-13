using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLiKyTucXa.Migrations
{
    /// <inheritdoc />
    public partial class V0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoan = table.Column<string>(type: "varchar(30)", nullable: false),
                    MatKhau = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Khu",
                columns: table => new
                {
                    khuVuc = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    loai = table.Column<bool>(type: "bit", nullable: false),
                    viTri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khu", x => x.khuVuc);
                });

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    mp = table.Column<int>(type: "int", nullable: false),
                    soLuongSVToiDa = table.Column<int>(type: "int", nullable: false),
                    soLuongSVHienTai = table.Column<int>(type: "int", nullable: false),
                    khuVuc = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.mp);
                    table.ForeignKey(
                        name: "FK_Phong_Khu",
                        column: x => x.khuVuc,
                        principalTable: "Khu",
                        principalColumn: "khuVuc");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MaHoaDon = table.Column<int>(type: "int", nullable: false),
                    thang = table.Column<DateTime>(type: "date", nullable: false),
                    chiSoDau = table.Column<int>(type: "int", nullable: false),
                    chiSoCuoi = table.Column<int>(type: "int", nullable: false),
                    giaDien = table.Column<int>(type: "int", nullable: false),
                    giaNuoc = table.Column<int>(type: "int", nullable: false),
                    trangThai = table.Column<int>(type: "int", nullable: false),
                    maPhong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.MaHoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDon_Phong",
                        column: x => x.maPhong,
                        principalTable: "Phong",
                        principalColumn: "mp");
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    mssv = table.Column<string>(type: "varchar(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    hoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    gioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    ngaySinh = table.Column<DateTime>(type: "date", nullable: false),
                    lop = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    khoa = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: false),
                    sdt = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: true),
                    mp = table.Column<int>(type: "int", nullable: true),
                    soGiuong = table.Column<int>(type: "int", nullable: true),
                    tinhTrang = table.Column<bool>(type: "bit", nullable: false),
                    MatKhau = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.mssv);
                    table.ForeignKey(
                        name: "FK_SinhVien_Phong",
                        column: x => x.mp,
                        principalTable: "Phong",
                        principalColumn: "mp");
                });

            migrationBuilder.CreateTable(
                name: "GiuongNgu",
                columns: table => new
                {
                    soGiuong = table.Column<int>(type: "int", nullable: false),
                    mp = table.Column<int>(type: "int", nullable: false),
                    mssv = table.Column<string>(type: "varchar(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiuongNgu", x => x.soGiuong);
                    table.ForeignKey(
                        name: "FK_GiuongNgu_Phong",
                        column: x => x.mp,
                        principalTable: "Phong",
                        principalColumn: "mp");
                    table.ForeignKey(
                        name: "FK_SinhVien_GiuongNgu",
                        column: x => x.mssv,
                        principalTable: "SinhVien",
                        principalColumn: "mssv");
                });

            migrationBuilder.CreateTable(
                name: "HoaDonPhong",
                columns: table => new
                {
                    maHoaDon = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    quy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    soTien = table.Column<double>(type: "float", nullable: false),
                    trangThai = table.Column<int>(type: "int", nullable: false),
                    mssv = table.Column<string>(type: "varchar(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonPhong", x => x.maHoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDonPhong_SinhVien",
                        column: x => x.mssv,
                        principalTable: "SinhVien",
                        principalColumn: "mssv");
                });

            migrationBuilder.CreateTable(
                name: "PhieuDangKy",
                columns: table => new
                {
                    maHoSo = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    mssv = table.Column<string>(type: "varchar(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    ngayVao = table.Column<DateTime>(type: "date", nullable: false),
                    tinhTrang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuDangKy", x => x.maHoSo);
                    table.ForeignKey(
                        name: "FK_PhieuDangKy_SinhVien",
                        column: x => x.mssv,
                        principalTable: "SinhVien",
                        principalColumn: "mssv");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminAccounts_TaiKhoan",
                table: "AdminAccounts",
                column: "TaiKhoan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiuongNgu_mp",
                table: "GiuongNgu",
                column: "mp");

            migrationBuilder.CreateIndex(
                name: "IX_GiuongNgu_mssv",
                table: "GiuongNgu",
                column: "mssv",
                unique: true,
                filter: "[mssv] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_maPhong",
                table: "HoaDon",
                column: "maPhong");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonPhong_mssv",
                table: "HoaDonPhong",
                column: "mssv");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuDangKy_mssv",
                table: "PhieuDangKy",
                column: "mssv");

            migrationBuilder.CreateIndex(
                name: "IX_Phong_khuVuc",
                table: "Phong",
                column: "khuVuc");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_mp",
                table: "SinhVien",
                column: "mp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminAccounts");

            migrationBuilder.DropTable(
                name: "GiuongNgu");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "HoaDonPhong");

            migrationBuilder.DropTable(
                name: "PhieuDangKy");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "Phong");

            migrationBuilder.DropTable(
                name: "Khu");
        }
    }
}
