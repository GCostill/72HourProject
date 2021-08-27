using _72HourProject.Data;
using _72HourProject.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace _72HourProject.Controllers._72hrControllers
{
    [Authorize]
    public class PostController : ApiController
    {

        private Services.PostService CreatePostService()
        {
            var authorId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(authorId);
            return postService;
        }

        public IHttpActionResult GetAll()
        {
            PostService postService = CreatePostService();
            var posts = postService.GetPosts();
            return Ok(posts);
        }

        public IHttpActionResult Post(PostData post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePostData(post))
                return InternalServerError();

            return Ok();
        }
    }
}