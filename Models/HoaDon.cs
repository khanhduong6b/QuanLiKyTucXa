using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLiKyTucXa.Models;

public partial class HoaDon
{
    [Required(ErrorMessage = "Mã hoá đơn không được để trống")]
    [DisplayName("Mã hoá đơn")]
    public int MaHoaDon { get; set; }
    [Required(ErrorMessage = "Tháng không được để trống")]
    [DisplayName("Tháng thu")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/yyyy}")]
    public DateTime Thang { get; set; }
    [Required(ErrorMessage ="Chỉ số đầu không được để trống")]
    [DisplayName("Chỉ số đầu của đồng hồ điện")]
    public int ChiSoDau { get; set; }
    [Required(ErrorMessage = "Chỉ số cuối không được để trống")]
    [DisplayName("Chỉ số cuối của đồng hồ điện")]
    public int ChiSoCuoi { get; set; }
    [Required(ErrorMessage = "Giá điện được để trống")]
    [DisplayName("Giá điện")]
    public int GiaDien { get; set; }
    [Required(ErrorMessage = "Giá nước không được để trống")]
    [DisplayName("Giá nước")]
    public int GiaNuoc { get; set; }
    [Required(ErrorMessage = "Trạng thái không được để trống")]
    [DisplayName("Trạng thái")]
    public int TrangThai { get; set; }
    [Required(ErrorMessage = "Mã phòng không được để trống")]
    [DisplayName("Mã phòng")]
    public int Mp { get; set; }
    public virtual Phong? MpNavigation { get; set; } = null!;
}
