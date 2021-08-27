using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _72HourProject.Models.POCOs
{
    public class ReplyDetail
    {
        public int Id { get; set; }

        public int CommentId { get; set; }

        public string Text { get; set; }

        public Guid AuthorId { get; set; }
    }
}