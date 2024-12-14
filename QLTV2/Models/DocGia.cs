using System.ComponentModel.DataAnnotations;

namespace QLTV2.Models
{
    public class DocGia
    {
        [Key]
        public int SoTheDG { get; set; }
        public string TenDG { get; set; }
        public string DiaChiDG { get; set; }
        public string SDTDG { get; set; }

    }
}
