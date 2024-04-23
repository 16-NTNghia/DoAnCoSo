using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCoSo.Models
{
	public class HinhAnhXe
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID_HinhAnh { get; set; }
		[Required(ErrorMessage = "URL hình ảnh là bắt buộc.")]
		public string URL_HinhAnh { get; set; }
		[Required(ErrorMessage = "Ẩn là bắt buộc.")]
		public int Hide { get; set; }

		public string BienSoXe { get; set; }
		public Xe xe { get; set; }

	}
}
