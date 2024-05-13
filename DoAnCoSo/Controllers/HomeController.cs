using DoAnCoSo.Models;
using DoAnCoSo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
			List<SelectListItem> DiaDiems = new List<SelectListItem>();
			foreach (var item in _db.diaDiems.Where(dd => dd.Hide == 0))
			{
				DiaDiems.Add(new SelectListItem { Value = item.ID_DiaDiem.ToString(), Text = item.Name_DiaDiem });
			}
			ViewBag.DiaDiems = DiaDiems;
			var All_Xes = await _db.xes.Where(x => x.Hide == 0).ToListAsync();
			var viewModel = new HomeViewModel
			{
				xes = All_Xes
			};
			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> ThueXe(string bienSoXe)
		{
			List<SelectListItem> DiaDiems = new List<SelectListItem>();
			List<SelectListItem> HangXes = new List<SelectListItem>();
			List<SelectListItem> LoaiXes = new List<SelectListItem>();
			foreach (var item in _db.diaDiems.Where(dd => dd.Hide == 0))
			{
				DiaDiems.Add(new SelectListItem { Value = item.ID_DiaDiem.ToString(), Text = item.Name_DiaDiem });
			}
			foreach (var item in _db.hangXes.Where(dd => dd.Hide == 0))
			{
				HangXes.Add(new SelectListItem { Value = item.ID_HangXe.ToString(), Text = item.Name_HangXe });
			}
			foreach (var item in _db.loaiXes.Where(dd => dd.Hide == 0))
			{
				LoaiXes.Add(new SelectListItem { Value = item.ID_LoaiXe.ToString(), Text = item.Name_LoaiXe });
			}
			var XeThue = _db.xes.FirstOrDefault(x => x.BienSoXe == bienSoXe);
			var viewModel = new HomeViewModel
			{
				xeThue = XeThue,
			};
			return View(viewModel);
		}
		[HttpGet]
		public async Task<IActionResult> Find(HomeViewModel model)
		{

			return View();
		}
	}
}
