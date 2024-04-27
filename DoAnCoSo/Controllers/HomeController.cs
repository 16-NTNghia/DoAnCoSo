using DoAnCoSo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAnCoSo.Controllers
{
	public class HomeController : Controller
	{
		private readonly QuanLyThueXeContext _db;

		public HomeController(QuanLyThueXeContext db)
		{
			_db = db;
		}

		public async Task<IActionResult> Index()
		{
			return View();
		}
	}
}
