using _72HourProject.Data;
using _72HourProject.Models;
using _72HourProject.Models.POCOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace _72HourProject.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public async Task<bool> CreateNote(ReplyCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (await ctx.Comments.FindAsync(model.CommentId) is null)
                {
                    return false;
                }

                var entity =
                    new ReplyData()
                    {
                        CommentId = model.CommentId,
                        Text = model.Text,
                        AuthorId = _userId
                    };

                ctx.Replies.Add(entity);
                return await ctx.SaveChangesAsync() > 0;
            }
        }


        public async Task<List<ReplyDetail>> GetReplyById(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var reply = await ctx.Replies.ToListAsync();

                if (reply is null)
                {
                    return null;
                }

                List<ReplyDetail> allReplysByCommentId = new List<ReplyDetail>();

                foreach (ReplyData replyX in reply)
                {
                    if (replyX.CommentId == commentId)
                    {
                        ReplyDetail replyY = new ReplyDetail
                        {
                            Id = replyX.Id,
                            CommentId = replyX.CommentId,
                            Text = replyX.Text,
                            AuthorId = replyX.AuthorId
                        };
                        allReplysByCommentId.Add(replyY);
                    }
                }

                return allReplysByCommentId;
            }
        }
    }
}