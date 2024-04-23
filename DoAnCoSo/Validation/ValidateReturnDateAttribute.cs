using System.ComponentModel.DataAnnotations;

namespace DoAnCoSo.Validation
{
	public class ValidateReturnDateAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var ngayTra = (DateTime)value;
			var model = (DoAnCoSo.Models.DatLichThueXe)validationContext.ObjectInstance;

			if (ngayTra <= model.NgayNhan)
			{
				return new ValidationResult("Ngày trả phải lớn hơn ngày nhận.");
			}

			return ValidationResult.Success;
		}
	}
}
