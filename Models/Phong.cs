using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLiKyTucXa.Models;

public partial class Phong
{
    [Required(ErrorMessage = "Mã phòng không được để trống")]
    [DisplayName("Mã phòng")]
    public int Mp { get; set; }
    [Required(ErrorMessage = "Số lượng sinh viên tối đa không được để trống")]
    [DisplayName("Số lượng sinh viên tối đa")]
    public int SoLuongSvtoiDa { get; set; }
    public int SoLuongSvhienTai { get; set; }

    public string KhuVuc { get; set; } = null!;

    public virtual HoaDon? HoaDon { get; set; }

    public virtual Khu KhuVucNavigation { get; set; } = null!;

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
