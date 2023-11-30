using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLiKyTucXa.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhatKy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhatKy",
                columns: table => new
                {
                    mssv = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    namHoc = table.Column<string>(type: "char(9)", unicode: false, fixedLength: true, maxLength: 9, nullable: false),
                    ngayThu = table.Column<DateTime>(type: "date", nullable: true),
                    soBienLai = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true),
                    soTien = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatKy", x => x.mssv);
                    table.ForeignKey(
                        name: "FK_NhatKy_SinhVien",
                        column: x => x.mssv,
                        principalTable: "SinhVien",
                        principalColumn: "mssv");
                });
        }
    }
}
