using System.ComponentModel.DataAnnotations;

namespace ItVisShop.Domain.ViewModels
{
	public class CreateReviewViewModel
	{
		public string? UserEmail { get; set; }
		public int ProductId { get; set; }
		[Required(ErrorMessage = "Введите комментарий")]
		public string ReviewText { get; set; }
		public int UserMark { get; set; }
	}
}
