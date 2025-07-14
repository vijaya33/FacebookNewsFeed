using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;



namespace FacebookNewsFeed_WebForms_UI.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }



        // Like a Post
        [System.Web.Mvc.HttpPost("like/{postId}")]
        public async Task<IActionResult> LikePost(string postId, [FromBody] Like like)
        {
            like.PostId = postId;  // Associate the like with the specific post
            like.DateCreated = DateTime.UtcNow;

            // Add the like to the database
            await _context.Likes.InsertOneAsync(like);

            return Ok(like);
        }

        // Get Likes for a Post
        [HttpGet("likes/{postId}")]
        public async Task<IActionResult> GetLikesForPost(string postId)
        {
            var likes = await _context.Likes.Find(l => l.PostId == postId).ToListAsync();
            return Ok(likes);
        }

    }
}