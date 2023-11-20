using System;
using System.Collections.Generic;

namespace QuanLiKyTucXa.Models;

public partial class PhieuDangKy
{
    public string MaHoSo { get; set; } = null!;

    public string Mssv { get; set; } = null!;

    public string? TinhTrang { get; set; }

    public virtual SinhVien MssvNavigation { get; set; } = null!;
}
