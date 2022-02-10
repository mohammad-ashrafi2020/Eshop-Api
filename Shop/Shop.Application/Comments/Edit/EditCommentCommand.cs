using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.Edit
{
    public record EditCommentCommand(long CommentId, string Text, long UserId) : IBaseCommand;
}