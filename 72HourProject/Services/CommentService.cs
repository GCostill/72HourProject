using _72HourProject.Data;
using _72HourProject.Models;
using _72HourProject.Models.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _72HourProject.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentData model)
        {
            var entity =
                new CommentData()
                {
                    AuthorId = _userId,
                    Text = model.Text,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public Comment GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Comments
                                .Single(e => e.Id == id && e.AuthorId == _userId);
                return new Comment
                {
                    Id = entity.Id,
                    Text = entity.Text,
                };

            }
        }
    }
}