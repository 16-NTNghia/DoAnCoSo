using System.Globalization;
using System.Security.Claims;
using DoAnCoSo.Models;
using DoAnCoSo.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DoAnCoSo.Controllers
{
	public class UserController : Controller
	{
		private readonly QuanLyThueXeContext _db;

		public UserController(QuanLyThueXeContext db)
		{
			_db = db;
		}

		[HttpGet]
		public async Task<IActionResult> Register()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(UserViewModel user)
		{
			user.TaiKhoan.ID_ChucVu = 3;
			user.TaiKhoan.ChucVu = _db.ChucVus.FirstOrDefault(tk => tk.ID_ChucVu == user.TaiKhoan.ID_ChucVu);

			var viewModel = new UserViewModel
			{
				TaiKhoan = user.TaiKhoan,
			};

			if (ModelState.IsValid)
			{

				var existingUser = await _db.TaiKhoans.FirstOrDefaultAsync(u => u.Email == user.TaiKhoan.Email);
				if (existingUser != null)
				{
					ViewBag.ErrorMessage = "Tên đăng nhập đã tồn tại.";
					return View(viewModel);
				}
				user.TaiKhoan.MatKhau = BCrypt.Net.BCrypt.HashPassword(user.TaiKhoan.MatKhau);
				user.TaiKhoan.Hide = 0;
				_db.TaiKhoans.Add(user.TaiKhoan);
				await _db.SaveChangesAsync();
				TempData["SuccessMessage"] = "Đăng ký thành công";
				return RedirectToAction("Login", "User");
			}
			TempData["ErrorMessage"] = "Đăng ký không thành công";
			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> Login()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(UserViewModel user)
		{
			List<SelectListItem> ChucVus = new List<SelectListItem>();
			foreach (var item in _db.ChucVus.Where(dd => dd.Hide == 0))
			{
				ChucVus.Add(new SelectListItem { Value = item.ID_ChucVu.ToString(), Text = item.Name_ChucVu });
			}
			var viewModel = new UserViewModel
			{
				TaiKhoan = user.TaiKhoan,
			};
			if (user.TaiKhoan != null)
			{
				var login = await _db.TaiKhoans.FirstOrDefaultAsync(u => u.Email == user.TaiKhoan.Email);
				if (login != null && BCrypt.Net.BCrypt.Verify(user.TaiKhoan.MatKhau, login.MatKhau))
				{
					var claims = new List<Claim>
					{
						new Claim(ClaimTypes.Email, login.Email),
						new Claim(ClaimTypes.Role, login.ChucVu.Name_ChucVu),
						new Claim(ClaimTypes.Name, login.Ten),
						new Claim("ImageUrl", login.AnhDaiDien)
					};
					var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
					TempData["SuccessMessage"] = "Đăng nhập thành công";
					return RedirectToAction("Index", "Home");
				}
				else
				{
					TempData["ErrorMessage"] = "Tên đăng nhập hoặc mật khẩu không đúng.";
					return View(viewModel);
				}
			}
			TempData["ErrorMessage"] = "Tên đăng nhập hoặc mật khẩu không đúng.";
			return View(viewModel);
		}
	}
}
