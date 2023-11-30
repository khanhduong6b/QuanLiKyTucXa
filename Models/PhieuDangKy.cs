using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLiKyTucXa.Models;

public partial class PhieuDangKy
{
    [Required(ErrorMessage = "Mã hồ sơ không được để trống")]
    [StringLength(10, ErrorMessage = "Mã hồ sơ không được quá 10 ký tự")]
    [DisplayName("Mã hồ sơ")]
    public string MaHoSo { get; set; } = null!;
    [Required(ErrorMessage = "Mã sinh viên không được để trống")]
    [StringLength(10, ErrorMessage = "Mã sinh viên không được quá 10 ký tự")]
    [DisplayName("Mã sinh viên")]
    public string Mssv { get; set; } = null!;
    [DisplayName("Tình trạng")]
    public string? TinhTrang { get; set; }

    public virtual SinhVien MssvNavigation { get; set; } = null!;
}
