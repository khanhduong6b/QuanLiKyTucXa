using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiKyTucXa.Models
{
    public class AdminAccount
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string TaiKhoan { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string MatKhau { get; set; }
    }
}
