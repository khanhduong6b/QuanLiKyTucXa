using System;
using System.Collections.Generic;

namespace QuanLiKyTucXa.Models;

public partial class HoaDon
{
    public int Mp { get; set; }

    public int Thang { get; set; }

    public int ChiSoDau { get; set; }

    public int ChiSoCuoi { get; set; }

    public int GiaDien { get; set; }

    public int GiaNuoc { get; set; }

    public int TrangThai { get; set; }

    public virtual Phong MpNavigation { get; set; } = null!;
}
