using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.UserAgg;

namespace Shop.Domain.CommentAgg
{
    public class Comment : AggregateRoot
    {
        private Comment()
        {
            
        }
        public long UserId { get; private set; }
        public long ProductId { get; private set; }
        public string Text { get; private set; }
        public CommentStatus Status { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public decimal Rate { get; private set; } = 0;
        public string Disadvantages { get; private set; }
        public string Advantages { get; private set; }
        public UserRecommendedStatus UserRecommendedStatus { get; private set; }
        public Comment(long userId, long productId, string text, decimal rate,
            UserRecommendedStatus userRecommended, string advantages = "", string disadvantages = "")
        {
            NullOrEmptyDomainDataException.CheckString(text, nameof(text));

            UserId = userId;
            ProductId = productId;
            Text = text;
            Advantages = advantages;
            Disadvantages = disadvantages;
            Rate = rate;
            Status = CommentStatus.Pending;
            UserRecommendedStatus = userRecommended;
        }

        public void Edit(string text)
        {
            NullOrEmptyDomainDataException.CheckString(text, nameof(text));

            Text = text;
            UpdateDate = DateTime.Now;
        }

        public void ChangeStatus(CommentStatus status)
        {
            Status = status;
            UpdateDate = DateTime.Now;
        }
    }

    public enum CommentStatus
    {
        Pending,
        Accepted,
        Rejected
    }

    public enum UserRecommendedStatus
    {
        پیشنهاد_میکنم,
        پیشنهاد_نمی_کنم,
        مطمئن_نیستم
    }
}