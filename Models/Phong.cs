using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLiKyTucXa.Models;

public partial class Phong
{
    [Key]
    [Required(ErrorMessage = "Mã phòng không được để trống")]
    [DisplayName("Mã phòng")]
    public int Mp { get; set; }

    [Required(ErrorMessage = "Số lượng sinh viên tối đa không được để trống")]
    [DisplayName("Số lượng sinh viên tối đa")]
    public int SoLuongSvToiDa { get; set; }

    [Required(ErrorMessage = "Số lượng sinh viên hiện tại không được để trống")]
    [DisplayName("Số lượng sinh viên hiện tại")]
    public int SoLuongSvHienTai { get; set; }

    [Required(ErrorMessage = "Khu vực không được để trống")]
    [DisplayName("Khu vực")]
    public string KhuVuc { get; set; }

    public virtual Khu? KhuVucNavigation { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
    public virtual ICollection<GiuongNgu> GiuongNgus { get; set; } = new List<GiuongNgu>();
}

