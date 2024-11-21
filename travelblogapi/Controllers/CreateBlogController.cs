using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelBlogAPI.Models;
using TravelBlogAPI.Services;

namespace TravelBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogservice;
        public BlogController(IBlogService blogservice)
        {
            _blogservice = blogservice;
        }


        [HttpGet]
        [Route("gettouristplaces")]
        public IActionResult TouristPlaces()
        {
            List<BlogTourPlacesList> visitlist = _blogservice.GetTouristPlaces();

            return Ok(visitlist);
        }

        [HttpGet]
        [Route("getplacescomments")]
        public IActionResult TouristPlacesComments(string PlaceId)
        {
            List<BlogPlacesCommentsList> visitlist = _blogservice.GetPlacesComments(PlaceId);

            return Ok(visitlist);
        }

        [HttpPost]        
        [Route("newpostsave")]
        [Authorize]
        public IActionResult NewTouristPlace([FromForm] NewPostDetail file)
        {
            try
            {  
                Response res = _blogservice.SaveNewPost(file);

                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
