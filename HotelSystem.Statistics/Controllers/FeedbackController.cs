using HotelSystem.Common.Controllers;
using HotelSystem.Common.Services;
using HotelSystem.Common.Services.Identity;
using HotelSystem.Statistics.Models.Feedback;
using HotelSystem.Statistics.Services.Feedback;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Statistics.Controllers
{
    public class FeedbackController : ApiController
    {
        private readonly IFeedbackService feedbackService;
        private readonly ICurrentUserService currentUser;

        public FeedbackController(IFeedbackService feedbackService, ICurrentUserService currentUser)
        {
            this.feedbackService = feedbackService;
            this.currentUser = currentUser;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Add(FeedbackInputModel input)
        {
            await feedbackService.AddFeedbackAsync(input.Score, input.Content, currentUser.UserId);
            return Result.Success;
        }

        [HttpGet]
        public async Task<ActionResult<TotalScoreOutputModel>> Score()
        {
            var model = new TotalScoreOutputModel
            {
                Score = await this.feedbackService.GetTotalScore(),
            };

            return model;
        }
    }
}
