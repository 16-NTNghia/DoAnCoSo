using DoAnCoSo.Models;

namespace DoAnCoSo.ViewModels
{
	public class HomeViewModel
	{
		public List<Xe>? xes {  get; set; }
		public Xe xeThue { get; set; }
		public DiaDiem? DiaDiem { get; set; }
		public DateTime? NgayNhan {  get; set; }
		public DateTime? NgayTra {  get; set; }
	}
}
