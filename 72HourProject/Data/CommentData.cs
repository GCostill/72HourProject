using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _72HourProject.Data
{
    public class CommentData
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Guid AuthorId { get; set; }
        public virtual List<Reply> Replies { get; set; }
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}