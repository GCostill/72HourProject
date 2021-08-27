using _72HourProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _72HourProject.Services
{
    public class PostService
    {
        public readonly Guid _authorId;

        public PostService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreatePostData(PostData model)
        {
            var entity =
                new PostData()
                {
                    AuthorId = _authorId,
                    Title = model.Title,
                    Text = model.Text,

                };

            using (var ctx = new Models.ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<PostData> GetPosts()
        {
            using (var ctx = new Models.ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.AuthorId == _authorId)
                        .Select(
                                e =>
                                    new PostData
                                    {
                                        AuthorId = _authorId,
                                        Title = e.Title,
                                        Text = e.Text
                                    }
                         );
                return query.ToList();
            }
        }
    }
}