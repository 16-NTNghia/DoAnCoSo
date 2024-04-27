using System.ComponentModel.DataAnnotations;

namespace DoAnCoSo.Validation
{
	public class KhongChuaUnicodeAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				string text = value.ToString();
				foreach (char item in text)
				{
					if (char.IsLetter(item))
					{
						if (item < 65 || item > 122 || item == ' ')
						{
							return new ValidationResult("Mật khẩu không được chứa ký tự Unicode.");
						}
					}
				}
			}
			return ValidationResult.Success;
		}
	}
}
