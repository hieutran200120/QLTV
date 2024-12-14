namespace QLTV2.Models
{
    public class MuonSach
    {
        public int MaTuaSach { get; set; }
        public int MaThuVien { get; set; }
        public int SoTheDG { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime? NgayTra { get; set; }

        // Quan hệ với TuaSach
        public TuaSach TuaSach { get; set; }

        // Quan hệ với ThuVien
        public ThuVien ThuVien { get; set; }

        // Quan hệ với DocGia
        public DocGia DocGia { get; set; }
    }
}
