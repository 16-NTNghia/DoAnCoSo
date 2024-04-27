using System.ComponentModel.DataAnnotations;

namespace DoAnCoSo.Validation
{
	public class NgaySinhHopLeAttribute: ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			DateTime ngaySinh = (DateTime)value;
			if (DateTime.Today.Year - ngaySinh.Year < 18)
			{
				return new ValidationResult("Phải hơn 18 tuổi.");
			}
			return ValidationResult.Success;
		}
	}
}
