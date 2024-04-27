using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCoSo.Models
{
	public class HangXe
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID_HangXe { get; set; }
		[Required(ErrorMessage = "Tên hãng xe là bắt buộc.")]
		public string Name_HangXe { get; set; }
		[Required(ErrorMessage = "Ẩn là bắt buộc.")]
		public int Hide { get; set; }
		public ICollection<Xe>? xes { get; set; }

	}
}
