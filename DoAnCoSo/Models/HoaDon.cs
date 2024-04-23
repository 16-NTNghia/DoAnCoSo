using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCoSo.Models
{
	public class HoaDon
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id_HoaDon { get; set; }
		public DateTime NgayLap { get { return DateTime.Now; } }

		[Required(ErrorMessage = "mã đặt lịch là trường bắt buộc.")]
		public int ID_DatLich { get; set; }
		[Required(ErrorMessage = "Email là trường bắt buộc.")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Biển số xe là trường bắt buộc.")]
		public string BienSoXe { get; set; }

		public DatLichThueXe DatLichThue { get; set; }
	}
}
