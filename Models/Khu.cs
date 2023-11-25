using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLiKyTucXa.Models;

public partial class Khu
{
    [Required(ErrorMessage = "Khu vực không được để trống")]
    [DisplayName("Khu vực")]
    public string KhuVuc { get; set; } = null!;
    [Required(ErrorMessage = "Loại không được để trống")]
    [DisplayName("Loại")]
    public bool Loai { get; set; }
    [Required(ErrorMessage = "Vị trí không được để trống")]
    [DisplayName("Vị trí")]
    public string ViTri { get; set; } = null!;

    public virtual ICollection<Phong> Phongs { get; set; } = new List<Phong>();
}
