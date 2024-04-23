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

			if (ngayCap <= taiKhoan.NgaySinh.AddYears(14))
			{
				return new ValidationResult("Ngày cấp căn cước phải lớn hơn ngày sinh 14 năm.");
			}
			return ValidationResult.Success;
		}
	}
}
