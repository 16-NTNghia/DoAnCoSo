using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCoSo.Models
{
	public class ChucVu
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID_ChucVu { get; set; }
		[Required(ErrorMessage = "Tên chức vụ là bắt buộc.")]
		public string Name_ChucVu { get; set; }
		[Required(ErrorMessage = "Ẩn là bắt buộc.")]
		public int Hide { get; set; }
		public ICollection<PhanQuyen> PhanQuyens { get; set; }
		public ICollection<TaiKhoan> TaiKhoans { get; set; }

	}
}
