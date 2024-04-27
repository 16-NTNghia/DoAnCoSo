using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnCoSo.Models
{
	public class Quyen
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID_Quyen { get; set; }
		[Required(ErrorMessage = "Tên quyền là bắt buộc.")]
		public string Name_Quyen { get; set; }
		[Required(ErrorMessage = "Ẩn là bắt buộc.")]
		public int Hide { get; set; }
		public ICollection<PhanQuyen>? PhanQuyens { get; set; }
	}
}
