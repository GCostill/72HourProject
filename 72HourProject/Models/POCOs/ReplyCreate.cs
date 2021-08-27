using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _72HourProject.Models.POCOs
{
    public class ReplyCreate
    {
        public int CommentId { get; set; }

        [MaxLength(8000)]
        public string Text { get; set; }
    }
}