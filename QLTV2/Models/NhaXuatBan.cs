using System.ComponentModel.DataAnnotations;

namespace QLTV2.Models
{
    public class NhaXuatBan
    {
        [Key]
        public string TenNXB { get; set; }
        public string DiaChiNXB { get; set; }
        public string SDTNXB { get; set; }
        public ICollection<TuaSach> TuaSaches { get; set; }
    }
}
