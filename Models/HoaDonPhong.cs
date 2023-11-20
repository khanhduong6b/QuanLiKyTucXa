using System;
using System.Collections.Generic;

namespace QuanLiKyTucXa.Models;

public partial class HoaDonPhong
{
    public string MaHoaDon { get; set; } = null!;

    public string Quy { get; set; } = null!;

    public double SoTien { get; set; }

    public int TrangThai { get; set; }

    public string Mssv { get; set; } = null!;

    public virtual SinhVien MssvNavigation { get; set; } = null!;
}
