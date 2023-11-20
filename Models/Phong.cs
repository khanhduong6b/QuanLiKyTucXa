using System;
using System.Collections.Generic;

namespace QuanLiKyTucXa.Models;

public partial class Phong
{
    public int Mp { get; set; }

    public int SoLuongSvtoiDa { get; set; }

    public int SoLuongSvhienTai { get; set; }

    public string KhuVuc { get; set; } = null!;

    public virtual HoaDon? HoaDon { get; set; }

    public virtual Khu KhuVucNavigation { get; set; } = null!;

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
