using System;
using System.Collections.Generic;

namespace QuanLiKyTucXa.Models;

public partial class GiuongNgu
{
    public int SoGiuong { get; set; }

    public int Mp { get; set; }

    public string? Mssv { get; set; }

    public virtual SinhVien? MssvNavigation { get; set; }
}
