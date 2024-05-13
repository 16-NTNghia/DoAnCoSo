using DoAnCoSo.Models;
using DoAnCoSo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoAnCoSo.Controllers
{
	public class QuanLyXeChoThueController : Controller
	{
		private readonly QuanLyThueXeContext _db;
		private readonly IWebHostEnvironment _hostingEnvironment;

		public QuanLyXeChoThueController(QuanLyThueXeContext db, IWebHostEnvironment hostingEnvironment)
		{
			_db = db;
			_hostingEnvironment = hostingEnvironment;
		}

		public async Task<IActionResult> Index()
		{
			var xeList = await _db.xes.Where(x => x.Email == "a@gmail.com").ToListAsync();
			var viewModel = new XeViewModel
			{
				XeList = xeList,
			};
			return View(viewModel);
		}
		[HttpGet]
		public async Task<IActionResult> Create()
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
			ViewBag.diaDiems = DiaDiems;
			ViewBag.hangXes = HangXes;
			ViewBag.loaiXes = LoaiXes;
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(XeViewModel xeModel, IFormFile HinhAnhXe)
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
			ViewBag.diaDiems = DiaDiems;
			ViewBag.hangXes = HangXes;
			ViewBag.loaiXes = LoaiXes;
			xeModel.Xe.Email = "a@gmail.com";

			var viewModel = new XeViewModel
			{
				Xe = xeModel.Xe,
			};


			if (ModelState.IsValid)
			{
				if (HinhAnhXe != null)
				{
					xeModel.Xe.AnhXe = HinhAnhXe.FileName;
					// Tạo đường dẫn cho thư mục chứa ảnh
					string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images", "xe", xeModel.Xe.BienSoXe);

					// Kiểm tra xem thư mục đã tồn tại chưa, nếu không thì tạo mới
					if (!Directory.Exists(uploadFolder))
					{
						Directory.CreateDirectory(uploadFolder);
					}

					// Tạo đường dẫn cho tệp tin ảnh
					string filePath = Path.Combine(uploadFolder, HinhAnhXe.FileName);

					// Lưu tệp tin ảnh vào thư mục đã tạo
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await HinhAnhXe.CopyToAsync(stream);
					}
				}
				_db.xes.Add(xeModel.Xe);
				await _db.SaveChangesAsync();
				TempData["SuccessMessage"] = "Đã đăng xe, đợi kiểm duyệt";
				return RedirectToAction("Index","QuanLyXeChoThue");
			}
			TempData["ErrorMessage"] = "Thông tin không hợp lệ";
			return View(viewModel);
		}

		public async Task<IActionResult> Display(string bienSoXe)
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
			ViewBag.diaDiems = DiaDiems;
			ViewBag.hangXes = HangXes;
			ViewBag.loaiXes = LoaiXes;
			var xe = await _db.xes.FirstOrDefaultAsync(x => x.BienSoXe == bienSoXe);
			var viewModel = new XeViewModel
			{
				Xe = xe,
			};
			return View(viewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Display(XeViewModel xeView, IFormFile HinhAnhXe, IFormFileCollection otherFiles)
		{
			ModelState.Remove("HinhAnhXe");
			ModelState.Remove("otherFiles");
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
			ViewBag.diaDiems = DiaDiems;
			ViewBag.hangXes = HangXes;
			ViewBag.loaiXes = LoaiXes;
			var xeUpdate = await _db.xes.FirstOrDefaultAsync(x => x.BienSoXe == xeView.Xe.BienSoXe);
			var viewModel = new XeViewModel
			{
				Xe = xeUpdate,
			};

			

			if (ModelState.IsValid)
			{
				/*if (HinhAnhXe != null)
				{
					xeUpdate.AnhXe = HinhAnhXe.FileName;
					// Tạo đường dẫn cho thư mục chứa ảnh
					string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images", "xe", xeUpdate.BienSoXe);

					// Kiểm tra xem thư mục đã tồn tại chưa, nếu không thì tạo mới
					if (!Directory.Exists(uploadFolder))
					{
						Directory.CreateDirectory(uploadFolder);
					}

					// Tạo đường dẫn cho tệp tin ảnh
					string filePath = Path.Combine(uploadFolder, HinhAnhXe.FileName);

					// Lưu tệp tin ảnh vào thư mục đã tạo
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await HinhAnhXe.CopyToAsync(stream);
					}
				}*/
				xeUpdate = xeView.Xe;
				await _db.SaveChangesAsync();
				TempData["SuccessMessage"] = "Đã đăng xe, đợi kiểm duyệt";
				return RedirectToAction("Index", "QuanLyXeChoThue");
			}
			TempData["ErrorMessage"] = "Thông tin không hợp lệ";
			return View(viewModel);
		}
	}
}
