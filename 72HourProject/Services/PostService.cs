using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _72HourProject.Services
{
    public class PostService
    {
        private readonly Guid _authorId;

        public PostService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Posts()
                {
                    Id = _authorId,
                    Title = model.Title,
                    Text = model.Text,

                };

            using (var ctx = new Models.ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new Models.ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.Id == _authorId)
                        .Select(
                                e =>
                                    new PostListItem
                                    {
                                        Id = e.PostId,
                                        Title = e.Title,
                                        Text = e.Text
                                    }
                         );
                return query.ToArray();
            }
        }
    }
}