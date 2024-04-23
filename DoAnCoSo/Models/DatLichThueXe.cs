using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoAnCoSo.Validation;

namespace DoAnCoSo.Models
{
	public class DatLichThueXe
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID_DatLich { get; set; }
		[Required(ErrorMessage = "Email là trường bắt buộc.")]
		[DataType(DataType.EmailAddress, ErrorMessage = "Địa chỉ email không hợp lệ.")]
		public string Email { get; set; }
		public TaiKhoan taiKhoan { get; set; }
		[Required(ErrorMessage = "Biển số xe là bắt buộc.")]
		[RegularExpression(@"^[A-Z0-9-]*$", ErrorMessage = "Biển số xe không hợp lệ.")]
		public string BienSoXe { get; set; }
		public Xe Xe { get; set; }
		[Required(ErrorMessage = "Vui lòng nhập ngày nhận.")]
		[CompareToCurrentDate(ErrorMessage = "Ngày nhận phải lớn hơn hoặc bằng ngày hiện tại.")]
		public DateTime NgayNhan { get; set; }
		[Required(ErrorMessage = "Vui lòng nhập ngày trả.")]
		[ValidateReturnDate(ErrorMessage = "Ngày trả phải lớn hơn ngày nhận")]
		public DateTime NgayTra {  get; set; }
		[Required(ErrorMessage = "Ẩn là bắt buộc.")]
		public int Hide { get; set; }
		[ValidateTotalRentDays(ErrorMessage = "Tổng ngày thuê phải từ 1 đến 14 ngày.")]
		public int TongNgayThue {
			get
			{
				return (int)(NgayTra - NgayNhan).TotalDays;
			}
		}
		public ulong TongTien {
			get
			{
				// Kiểm tra xem Xe có tồn tại không
				if (Xe != null)
				{
					// Lấy giá thuê của Xe và tính tổng tiền
					return Xe.GiaThue * (ulong)TongNgayThue;
				}
				else
				{
					// Trả về 0 nếu không có Xe
					return 0;
				}
			}
		}
    }
}
