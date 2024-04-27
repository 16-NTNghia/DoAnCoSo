using System.ComponentModel.DataAnnotations;
using DoAnCoSo.Models;

namespace DoAnCoSo.Validation
{
	public class NgayCapHopLeAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			DateTime ngayCap = (DateTime)value;
			TaiKhoan taiKhoan = (TaiKhoan)validationContext.ObjectInstance;

			if (ngayCap.Year - taiKhoan.NgaySinh.Year < 14)
			{
				return new ValidationResult("Ngày cấp căn cước không hợp lệ.");
			}

			if (ngayCap > DateTime.Now)
			{
				return new ValidationResult("Ngày cấp căn cước không hợp lệ.");
			}
			return ValidationResult.Success;
		}
	}
}
