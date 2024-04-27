using DoAnCoSo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoAnCoSo.ViewModels
{
	public class UserViewModel
	{
		public TaiKhoan TaiKhoan { get; set; }

		public UserViewModel() 
		{
			TaiKhoan = new TaiKhoan();
		}
	}
}
