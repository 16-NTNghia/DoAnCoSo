using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoAnCoSo.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace DoAnCoSo.Models
{
	public class TaiKhoan
	{
		[Required(ErrorMessage = "Email là trường bắt buộc.")]
		[DataType(DataType.EmailAddress, ErrorMessage = "Địa chỉ email không hợp lệ.")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Mật khẩu là trường bắt buộc.")]
		[RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
			ErrorMessage = "Mật khẩu phải có ít nhất 1 ký tự hoa, 1 ký tự thường, 1 ký tự đặc biệt, 1 số, và ít nhất 8 ký tự.")]
		public string MatKhau { get; set;}
		[Required(ErrorMessage = "Họ là trường bắt buộc.")]
		[RegularExpression(@"^[^\d]+$", ErrorMessage = "Họ chỉ chứa ký tự, không có số.")]
		public string Ho { get; set; }
		[Required(ErrorMessage = "Tên là trường bắt buộc.")]
		[RegularExpression(@"^[^\d]+$", ErrorMessage = "Họ chỉ chứa ký tự, không có số.")]
		public string Ten { get; set; }
		[NgaySinhHopLe]
		public DateTime NgaySinh { get; set; }
		[Required(ErrorMessage = "Số căn cước công dân là trường bắt buộc.")]
		[RegularExpression(@"^\d{12}$", ErrorMessage = "Số căn cước công dân phải có đúng 12 ký tự số.")]
		public string CanCuocCongDan { get; set; }
		[NgayCapHopLe]
		public DateTime NgayCap { get; set; }
		[Required(ErrorMessage = "Số điện thoại là trường bắt buộc.")]
		[RegularExpression(@"^\d{10,11}$", ErrorMessage = "Số điện thoại phải có từ 10 đến 11 ký tự số.")]
		public string SoDienThoai { get; set; }
        public bool GioiTinh { get; set; }
        public string? AnhDaiDien {  get; set; }
		[Required(ErrorMessage = "Giấy phép lái xe là bắt buộc.")]
		[RegularExpression(@"^\d{12}$", ErrorMessage = "Giấy phép lái xe phải có 12 chữ số.")]
		public string GiayPhepLaiXe { get; set; }
		[Required(ErrorMessage = "Ẩn là bắt buộc.")]
		public int Hide { get; set; }
		[Required(ErrorMessage = "Chức vụ là bắt buộc.")]
		public int ID_ChucVu { get; set; }
		public ChucVu ChucVu { get; set; }

		public ICollection<Xe> xes { get; set; }
		public ICollection<DatLichThueXe> datLichThueXes { get; set; }
	}					 
}
