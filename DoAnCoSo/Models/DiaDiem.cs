using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCoSo.Models
{
	public class DiaDiem
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID_DiaDiem { get; set; }
		[Required(ErrorMessage = "Tên địa điểm là bắt buộc.")]
		public string Name_DiaDiem { get; set; }
		[Required(ErrorMessage = "Ẩn là bắt buộc.")]
		public int Hide { get; set; }
		public ICollection<Xe> xes { get; set; }

	}
}
