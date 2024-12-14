namespace QLTV2.Models
{
    public class SachTacGia
    {
        public int TuaSachID { get; set; }
        public string TenTacGia { get; set; }

        // Quan hệ với TuaSach
        public TuaSach TuaSach { get; set; }
    }
}
