using System.ComponentModel.DataAnnotations;

namespace QLTV2.Models
{
    public class TuaSach
    {
        [Key]
        public int TuaSachID { get; set; }
        public string TenTuaSach { get; set; }
        public string TenNXB { get; set; }
        public NhaXuatBan NhaXuatBan { get; set; }
    }
}
