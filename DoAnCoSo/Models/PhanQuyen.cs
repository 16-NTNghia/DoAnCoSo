using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnCoSo.Models
{
	public class PhanQuyen
	{
		[Required(ErrorMessage = "Quyền là bắt buộc.")]
		public int Id_Quyen { get; set; }
		public Quyen Quyen { get; set; }
		[Required(ErrorMessage = "Chức vụ là bắt buộc.")]
		public int Id_ChucVu { get; set; }
		public ChucVu ChucVu { get; set; }
	}
}
