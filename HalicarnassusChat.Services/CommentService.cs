using HalicarnassusChat.Data;
using HalicarnassusChat.Models;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comment = HalicarnassusChat.Data.Comment;
using CommentList = HalicarnassusChat.Models.CommentList;

namespace HalicarnassusChat.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CreateComment model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                bool isValid = int.TryParse(model.PostId, out int id);
                if (!isValid)
                {
                    id = 0;
                }
                var entity =
                new Comment()
                {
                    Author = _userId,
                    Content = model.Content,
                    PostId = id,
                };
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentList> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.Author == _userId)
                        .Select(
                            e =>
                                new CommentList
                                {
                                    PostId = e.PostId,
                                    Contents = e.Content,
                                }
                        );

                return query.ToArray();


            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comments
                        .Single(e => e.CommentId == model.CommentId && e.Author == _userId);

                entity.Content = model.Content;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comments
                        .Single(e => e.PostId == commentId && e.Author == _userId);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
