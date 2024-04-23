using System.ComponentModel.DataAnnotations;

namespace DoAnCoSo.Validation
{
	public class ValidateTotalRentDaysAttribute	: ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var totalRentDays = (int)value;
			if (totalRentDays < 1 || totalRentDays > 14)
			{
				return new ValidationResult("Tổng ngày thuê phải từ 1 đến 14 ngày.");
			}

			return ValidationResult.Success;
		}
	}
}
