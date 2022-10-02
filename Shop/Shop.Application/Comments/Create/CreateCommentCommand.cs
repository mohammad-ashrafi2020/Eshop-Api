using Common.Application;
using Shop.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.Create
{
    public class CreateCommentCommand : IBaseCommand
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public string Text { get; set; }
        public string Disadvantages { get; set; }
        public string Advantages { get; set; }
        public UserRecommendedStatus UserRecommendedStatus { get; set; }
        public decimal Rate { get; set; } = 0;

    };
}