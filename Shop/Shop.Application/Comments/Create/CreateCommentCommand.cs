using Common.Application;
using Shop.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.Create
{
    public record CreateCommentCommand(string Text, long UserId, long ProductId,
        string Disadvantages, string Advantages, UserRecommendedStatus UserRecommendedStatus, decimal Rate = 0) : IBaseCommand;
}