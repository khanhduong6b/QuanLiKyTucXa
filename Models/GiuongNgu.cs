using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLiKyTucXa.Models;

public partial class GiuongNgu
{
    [Required(ErrorMessage = "Mã giường không được để trống")]
    [DisplayName("Mã giường")]
    public int SoGiuong { get; set; }
    [Required(ErrorMessage = "Mã phòng không được để trống")]
    [DisplayName("Mã phòng")]
    public int Mp { get; set; }
    [DisplayName("MSSV")]
    public string? Mssv { get; set; }

    public virtual SinhVien? MssvNavigation { get; set; }
}
