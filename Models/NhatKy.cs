using System;
using System.Collections.Generic;

namespace QuanLiKyTucXa.Models;

public partial class NhatKy
{
    public string Mssv { get; set; } = null!;

    public string NamHoc { get; set; } = null!;

    public DateTime? NgayThu { get; set; }

    public string? SoBienLai { get; set; }

    public double? SoTien { get; set; }

    public virtual SinhVien MssvNavigation { get; set; } = null!;
}
