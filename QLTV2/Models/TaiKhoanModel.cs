using System.ComponentModel.DataAnnotations;

namespace QLTV2.Models
{
    public class TaiKhoanModel

    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Tên đăng nhập không được để trống!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        public string SDT { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email của bạn !")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ !")]
        public string Email { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "Vui lòng nhập mật khẩu của bạn !")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
