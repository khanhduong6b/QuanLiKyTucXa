using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLiKyTucXa.Models;

public partial class Phong
{
    [DisplayName("Mã phòng")]
    [Required(ErrorMessage = "Mã phòng không được để trống")]
    public int Mp { get; set; }

    [DisplayName("Số lượng sinh viên tối đa")]
    [Required(ErrorMessage = "Số lượng sinh viên tối đa không được để trống")]
    public int SoLuongSvToiDa { get; set; }

    [DisplayName("Số lượng sinh viên hiện tại")]
    [Required(ErrorMessage = "Số lượng sinh viên hiện tại không được để trống")]
    [DefaultValue(0)]
    public int SoLuongSvHienTai { get; set; }

    [DisplayName("Khu vực")]
    [Required(ErrorMessage = "Khu vực không được để trống")]
    public string KhuVuc { get; set; }

    public virtual Khu? KhuVucNavigation { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
    public virtual ICollection<GiuongNgu> GiuongNgus { get; set; } = new List<GiuongNgu>();
}

