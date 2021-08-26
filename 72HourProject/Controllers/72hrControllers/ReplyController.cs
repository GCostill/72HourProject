using _72HourProject.Models;
using _72HourProject.Models.POCOs;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace _72HourProject.Controllers._72hrControllers
{
    public class ReplyController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //Post
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Reply reply)
        {
            if (reply is null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _context.Comments.FindAsync(reply.CommentId) is null)
            {
                return BadRequest("Comment doesnt exist");
            }

            var replyEntity = new Reply
            {
                CommentId = reply.CommentId,
                Text = reply.Text,
                AuthorId = reply.AuthorId
            };

            _context.Replys.Add(replyEntity);

            if (await _context.SaveChangesAsync() > 0)
            {
                return Ok($"Reply Id: {replyEntity.Id} was successfully posted to Comment Id: {replyEntity.CommentId} using Auther Id: {replyEntity.AuthorId}.");
            }

            return InternalServerError();
        }

        // GET: Reply By commentId
        [HttpGet]
        public async Task<IHttpActionResult> GetByCommentId([FromUri] int commentId)
        {
            var reply = await _context.Replys.ToListAsync();

            if (reply is null)
            {
                return BadRequest("No replys exist in the database!");
            }

            List<Reply> allReplysByCommentId = new List<Reply>();

            foreach(Reply replyX in reply)
            {
                if(replyX.CommentId == commentId)
                {
                    allReplysByCommentId.Add(replyX);
                }
            }

            if(allReplysByCommentId.Count == 0)
            {
                return NotFound();
            }

            return Ok(allReplysByCommentId);
            
        }

        //Get Reply By authorId
        [HttpGet]
        public async Task<IHttpActionResult> GetByAuthorId([FromBody] Guid AuthorIdAsString)
        {
            var reply = await _context.Replys.ToListAsync();

            if (reply is null)
            {
                return BadRequest("No replys exist in the database!");
            }

            List<Reply> allReplysByAuthorId = new List<Reply>();

            foreach (Reply replyX in reply)
            {
                if (replyX.AuthorId == AuthorIdAsString)
                {
                    allReplysByAuthorId.Add(replyX);
                }
            }

            if (allReplysByAuthorId.Count == 0)
            {
                return NotFound();
            }

            return Ok(allReplysByAuthorId);

        }

        //Put

        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] Reply newReplyData, [FromUri] int id)
        {
            if (newReplyData is null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reply = await _context.Replys.FindAsync(id);

            if (reply is null)
            {
                return NotFound();
            }

            reply.CommentId = newReplyData.CommentId;
            reply.Text = newReplyData.Text;
            reply.AuthorId = newReplyData.AuthorId;

            if (await _context.SaveChangesAsync() > 0)
            {
                return Ok($"Reply ID: {reply.Id} has been updated with the following {reply.Text}");
            }

            return InternalServerError();
        }

        //Delete

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var reply = await _context.Replys.FindAsync(id);

            if (reply != null)
            {
                _context.Replys.Remove(reply);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok($"Repl ID: {id} has been removed");
                }
            }

            return InternalServerError();
        }
    }
}