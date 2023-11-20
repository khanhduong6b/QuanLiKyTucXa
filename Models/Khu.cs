using System;
using System.Collections.Generic;

namespace QuanLiKyTucXa.Models;

public partial class Khu
{
    public string KhuVuc { get; set; } = null!;

    public bool Loai { get; set; }

    public string ViTri { get; set; } = null!;

    public virtual ICollection<Phong> Phongs { get; set; } = new List<Phong>();
}
