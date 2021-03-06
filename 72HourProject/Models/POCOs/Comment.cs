using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _72HourProject.Models.POCOs
{
    public class Comment
    {
        //this is what the user sees
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual List<Reply> Replies { get; set; }
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}