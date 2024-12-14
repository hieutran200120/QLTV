namespace QLTV2.Models
{
    public class CuonSach
    {
        public int MaTuaSach { get; set; }
        public int MaThuVien { get; set; }
        public int SoLuong { get; set; }

        // Quan hệ với TuaSach
        public TuaSach TuaSach { get; set; }

        // Quan hệ với ThuVien
        public ThuVien ThuVien { get; set; }
    }
}
