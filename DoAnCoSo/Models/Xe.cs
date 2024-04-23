using System.ComponentModel.DataAnnotations;

namespace DoAnCoSo.Models
{
	public class Xe
	{
		[Required(ErrorMessage = "Biển số xe là bắt buộc.")]
		[RegularExpression(@"^[A-Z0-9-]*$", ErrorMessage = "Biển số xe không hợp lệ.")]
		public string BienSoXe { get; set; }
		[Required(ErrorMessage = "Tên xe là bắt buộc.")]
		public string TenXe { get; set; }
		[Required(ErrorMessage = "Email là bắt buộc.")]
		public string Email { get; set; }
		public TaiKhoan email { get; set; }
		[Required(ErrorMessage = "Loại xe là bắt buộc.")]
		public int ID_Loai { get; set; }
		public LoaiXe loais { get; set; }
		[Required(ErrorMessage = "Hãng xe là bắt buộc.")]
		public int ID_HangXe { get; set; }
		public HangXe hangs { get; set; }
		[Required(ErrorMessage = "Địa điểm là bắt buộc.")]
		public int ID_DiaDiem { get; set; }
		public DiaDiem diaDiems { get; set; }
		[Required(ErrorMessage = "Giá thuê là bắt buộc.")]
		public ulong GiaThue { get; set; }
		public bool? TrangThai { get; set; }
		public string? MoTa { get; set; }
		[Required(ErrorMessage = "hình ảnh xe là bắt buộc.")]
		public string AnhXe { get; set; }
		[Required(ErrorMessage = "Ẩn là bắt buộc.")]
		public int Hide {  get; set; }

		public ICollection<HinhAnhXe> hinhAnhXes { get; set; }
		public ICollection<DatLichThueXe> datLichThueXes { get; set; }
	}
}
