using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCoSo.Models
{
	public class LoaiXe
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID_LoaiXe { get; set; }
		[Required(ErrorMessage = "Tên loại xe là bắt buộc.")]
		public string Name_LoaiXe { get; set; }
		[Required(ErrorMessage = "Ẩn là bắt buộc.")]
		public int Hide { get; set; }
		public ICollection<Xe>? xes { get; set; }

	}
}
