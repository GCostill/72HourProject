using _72HourProject.Models;
using _72HourProject.Models.POCOs;
using _72HourProject.Services;
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
        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            return replyService;
        }

        public IHttpActionResult Post(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyService();

            if (!service.CreateNote(reply).Result)
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult GetByCommentId(int commentId)
        {

            ReplyService replyService = CreateReplyService();
            var reply = replyService.GetReplyById(commentId);

            if (reply.Result is null)
            {
                return BadRequest("No replys exist in the database!");
            }

            if (reply.Result.Count == 0)
            {
                return BadRequest("No replys exist in the database!");
            }

            return Ok(reply.Result);
        }

    }
}