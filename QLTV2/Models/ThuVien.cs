using System.ComponentModel.DataAnnotations;

namespace QLTV2.Models
{
    public class ThuVien
    {
        [Key]
        public int MaThuVien { get; set; }
        public string TenThuVien { get; set; }
        public string DiaChi { get; set; }
    }
}
