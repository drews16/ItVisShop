using ItVisShop.Domain.Response;
using ItVisShop.Domain.ViewModels;

namespace ItVisShop.Service.Interfaces
{
	public interface IReviewService
	{
		Task<IBaseResponse<CreateReviewViewModel>> AddReview(CreateReviewViewModel model);
	}
}
