﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiKyTucXa.Models;

public partial class SinhVien
{
    [Required(ErrorMessage = "Mã sinh viên không được để trống")]
    [StringLength(10, ErrorMessage = "Mã sinh viên không được quá 10 ký tự")]
    [DisplayName("Mã sinh viên")]
    public string Mssv { get; set; } = null!;
    [Required(ErrorMessage = "Họ tên không được để trống")]
    [DisplayName("Họ tên")]
    public string HoTen { get; set; } = null!;
    [DisplayName("Giới tính")]
    public bool GioiTinh { get; set; }
    [Required(ErrorMessage = "Ngày sinh không được để trống")]
    [DisplayName("Ngày sinh")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime NgaySinh { get; set; }
    [Required(ErrorMessage = "Lớp không được để trống")]
    [DisplayName("Lớp")]
    public string Lop { get; set; } = null!;
    [Required(ErrorMessage = "Khoa không được để trống")]
    [DisplayName("Khoa")]
    public string Khoa { get; set; } = null!;
    [DisplayName("Số điện thoại")]
    public string? Sdt { get; set; }
    [DisplayName("Mã phòng")]
    public int? Mp { get; set; }
    [DisplayName("Số giường")]
    public int? SoGiuong { get; set; }
    [DisplayName("Tình trạng ở")]
    [DefaultValue(false)]
    public bool TinhTrang { get; set; }
    [DisplayName("Mật khẩu")]
    [Column(TypeName = "varchar(30)")]
    public string? MatKhau { get; set; }


    public virtual GiuongNgu? GiuongNguNavigation { get; set; }

    public virtual ICollection<HoaDonPhong> HoaDonPhongs { get; set; } = new List<HoaDonPhong>();

    public virtual Phong? MpNavigation { get; set; }

    public virtual ICollection<PhieuDangKy> PhieuDangKys { get; set; } = new List<PhieuDangKy>();
}
