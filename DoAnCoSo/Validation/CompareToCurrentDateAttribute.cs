using System.ComponentModel.DataAnnotations;

namespace DoAnCoSo.Validation
{
	public class CompareToCurrentDateAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			DateTime inputValue = (DateTime)value;
			return inputValue.Date >= DateTime.Today;
		}
	}
}
