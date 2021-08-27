using _72HourProject.Data;
using _72HourProject.Models;
using _72HourProject.Models.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace _72HourProject.Controllers._72hrControllers
{
    public class CommentController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //POST(Create) a Comment on a Post using a Foreign Key relationship (required)
        [HttpPost]
        public async Task<IHttpActionResult> CreateComment([FromBody] CommentData model)
        {
            if (model is null)
                return BadRequest(); 
            
            if (ModelState.IsValid)
            {
                _context.Comments.Add(model);
                int changeCount = await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }                                             

        //GET Comments By Post Id(required)
        [HttpGet]
        public async Task<IHttpActionResult> GetByPostId([FromBody] int postId)
        {
            CommentData comments = await _context.Comments.FindAsync(postId);
            if(comments != null)
            {
                return Ok(comments);
            }
            return NotFound();
        }

        //GET Comments By Author Id

        //PUT(Update) a Comment

        //DELETE a Comment

    }
}