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
				return new ValidationResult("Ngày sinh phải bé hơn hiện tại 18 năm.");
			}
			return ValidationResult.Success;
		}
	}
}
