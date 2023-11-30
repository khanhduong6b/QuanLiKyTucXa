using System;
using System.Collections.Generic;

namespace QuanLiKyTucXa.Models;

public partial class SinhVien
{
    public string Mssv { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public bool GioiTinh { get; set; }

    public DateTime NgaySinh { get; set; }

    public string Lop { get; set; } = null!;

    public string Khoa { get; set; } = null!;

    public string? Sdt { get; set; }

    public int? Mp { get; set; }

    public int? SoGiuong { get; set; }
    public string MatKhau { get; set; }


    public virtual ICollection<GiuongNgu> GiuongNgus { get; set; } = new List<GiuongNgu>();

    public virtual ICollection<HoaDonPhong> HoaDonPhongs { get; set; } = new List<HoaDonPhong>();

    public virtual Phong? MpNavigation { get; set; }

    public virtual ICollection<PhieuDangKy> PhieuDangKies { get; set; } = new List<PhieuDangKy>();
}
