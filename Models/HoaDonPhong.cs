using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLiKyTucXa.Models;

public partial class HoaDonPhong
{
    [Required(ErrorMessage = "Mã hóa đơn không được để trống")]
    [StringLength(10, ErrorMessage = "Mã hóa đơn không được quá 10 ký tự")]
    [DisplayName("Mã hóa đơn")]
    public string MaHoaDon { get; set; } = null!;
    [Required(ErrorMessage = "Quý không được để trống")]
    [DisplayName("Quý")]
    public string Quy { get; set; } = null!;
    [Required(ErrorMessage = "Số tiền không được để trống")]
    [DisplayName("Số tiền")]
    public double SoTien { get; set; }
    [Required(ErrorMessage = "Trạng thái không được để trống")]
    [DisplayName("Trạng thái")]
    public int TrangThai { get; set; }
    [Required(ErrorMessage = "Mã sinh viên không được để trống")]
    [StringLength(10, ErrorMessage = "Mã sinh viên không được quá 10 ký tự")]
    [DisplayName("Mã sinh viên")]
    public string Mssv { get; set; } = null!;

    public virtual SinhVien? MssvNavigation { get; set; } = null!;
}
