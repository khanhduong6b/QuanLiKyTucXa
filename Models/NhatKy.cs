using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLiKyTucXa.Models;

public partial class NhatKy
{
    [Required(ErrorMessage = "Mã sinh viên không được để trống")]
    [DisplayName("Mã sinh viên")]
    public string Mssv { get; set; } = null!;
    [Required(ErrorMessage = "Năm học không được để trống")]
    [DisplayName("Năm học")]
    public string NamHoc { get; set; } = null!;
    [Required(ErrorMessage = "Ngày thu không được để trống")]
    [DisplayName("Ngày thu")]
    public DateTime? NgayThu { get; set; }
    [Required(ErrorMessage = "Số biên lai không được để trống")]
    [DisplayName("Số biên lai")]
    public string? SoBienLai { get; set; }
    [Required(ErrorMessage = "Số tiền không được để trống")]
    [DisplayName("Số tiền")]
    public double? SoTien { get; set; }

    public virtual SinhVien MssvNavigation { get; set; } = null!;
}
