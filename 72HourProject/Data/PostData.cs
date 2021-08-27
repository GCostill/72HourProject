using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _72HourProject.Data
{
    public class PostData
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage ="Please Enter at least 2 characters.")]
        [MaxLength(25, ErrorMessage ="There are too many characters in this field.")]
        public string Title { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please Enter at least 2 characters.")]
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field.")]
        public string Text { get; set; }

        [Required]
        public virtual List<Models.POCOs.Comment> Comments { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

    }
}