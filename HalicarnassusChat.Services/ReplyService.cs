using HalicarnassusChat.Data;
using HalicarnassusChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalicarnassusChat.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    Content = model.Content
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.Author == _userId)
                        .Select(
                            e =>
                                new ReplyListItem
                                {
                                    ReplyId = e.ReplyId,
                                    Content = e.Content
                                }
                        );

                return query.ToArray();
            }
        }

        public ReplyDetail GetReplyByCommentId(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Replies
                        .Single(e => e.CommentId == commentId && e.Author == _userId);
                return
                    new ReplyDetail
                    {
                        Content = entity.Content
                    };
            }
        }

        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyId == model.ReplyId && e.Author == _userId);

                entity.ReplyId = model.ReplyId;
                entity.Content = model.Content;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteReply(int replyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyId == replyId && e.Author == _userId);

                ctx.Replies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
