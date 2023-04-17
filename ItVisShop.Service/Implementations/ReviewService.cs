using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using ItVisShop.Domain.Response;
using ItVisShop.Domain.ViewModels;
using ItVisShop.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItVisShop.Service.Implementations
{
	public class ReviewService : IReviewService
	{
		private readonly IBaseRepository<Review> _reviewRepository;
		private readonly IBaseRepository<User> _userRepository;

		public ReviewService(IBaseRepository<Review> reviewRepository, IBaseRepository<User> userRepositoy)
		{
			_reviewRepository = reviewRepository;
			_userRepository = userRepositoy;
		}

		public async Task<IBaseResponse<CreateReviewViewModel>> AddReview(CreateReviewViewModel model)
		{
			try
			{
				var user = await _userRepository.GetAll().FirstOrDefaultAsync(u => u.Email == model.UserEmail);

				await _reviewRepository.Create(new Review()
				{
					ProfileId = user.Profile.ProfileId,
					ProductId = model.ProductId,
					ReviewText = model.ReviewText,
					UserMark = model.UserMark
				});

				return new BaseResponse<CreateReviewViewModel>()
				{
					StatusCode = Domain.Enum.StatusCode.Ok
				};
			}
			catch(Exception ex)
			{
				return new BaseResponse<CreateReviewViewModel>()
				{ 
					Description = $"{AddReview} : {ex.Message}",
					StatusCode = Domain.Enum.StatusCode.InternalServerError
				};
			}
		}
	}
}
