using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLiKyTucXa.Models;

public class PhieuDangKy
{
    [DisplayName("Mã hồ sơ")]
    [Required(ErrorMessage = "Mã hồ sơ không được để trống")]
    [StringLength(10, ErrorMessage = "Mã hồ sơ không được quá 10 ký tự")]
    public string MaHoSo { get; set; }
    [Required(ErrorMessage = "Mã sinh viên không được để trống")]
    [StringLength(10, ErrorMessage = "Mã sinh viên không được quá 10 ký tự")]
    [DisplayName("Mã sinh viên")]
    public string Mssv { get; set; }

    [Required(ErrorMessage = "Ngày vào ở không được để trống")]
    [DisplayName("Ngày vào ở")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime NgayVao { get; set; }
    [DisplayName("Tình trạng")]
    [Required(ErrorMessage = "Tình trạng không được để trống")]
    public int TinhTrang { get; set; }

    public virtual SinhVien? MssvNavigation { get; set; }
}
