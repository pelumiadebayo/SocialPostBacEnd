using SocialPostBackEnd.Model.Response;
using SocialPostBackEnd.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SocialPostBackEnd.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController: Controller
    {
        private readonly IServices _services;

        public HomeController(IServices services)
        {
            _services = services;
        }

        [HttpPost("get-posts")]
        public IActionResult GetPost(int user_id, int[] post_ids)
        {
            return Ok(_services.Get_posts(user_id, post_ids));
        }

        [HttpPost("merge-posts")]
        public IActionResult MergePost(List<List<Post>> listOfPosts)
        {
            return Ok(_services.Merge_posts(listOfPosts));
        }
    }
}
