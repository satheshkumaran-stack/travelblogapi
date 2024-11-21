using Microsoft.EntityFrameworkCore;
using TravelBlogAPI.Data;
using TravelBlogAPI.Models;

namespace TravelBlogAPI.Services
{
    public class BlogService : IBlogService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        public BlogService(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        public List<BlogTourPlacesList> GetTouristPlaces()
        {
            try
            {
                var places = _context.blogtouristplaces.ToList();
                places.ForEach(pl =>
                {
                    var user = _context.blogusermaster.ToList().Where(x => x.Id == int.Parse(pl.CreatedBy)).FirstOrDefault();
                    pl.CreatedBy = user?.Name;

                    var placesComments = _context.blogplacescomments.ToList().Where(x => x.PlaceId == pl.Id).Count();
                    pl.CommentsCount = placesComments;
                });
                //byte[] byteData = System.IO.File.ReadAllBytes(imgPath);
                return places;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BlogPlacesCommentsList> GetPlacesComments(string id)
        {            
            try
            {
                var placesComments = _context.blogplacescomments.Where(x => x.PlaceId == int.Parse(id)).ToList();
                placesComments.ForEach(pl =>
                {
                    var user = _context.blogusermaster.ToList().Where(x => x.Id == int.Parse(pl.CreatedBy)).FirstOrDefault();
                    pl.CreatedBy = user?.Name;
                });
                return placesComments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Response SaveNewPost(NewPostDetail detail)
        {
            Response response = new Response(); 
            BlogTourPlacesList vs = new BlogTourPlacesList();
            try
            {
                using (var stream = new MemoryStream())
                {
                    detail.FormFile?.CopyTo(stream);
                    detail.FileData = stream.ToArray();
                }

                vs.Place = detail.PlaceName;
                vs.Description = detail.Description;
                vs.FileName = detail.FileName;
                vs.FileData = detail.FileData;
                vs.CommentsCount = 0;
                vs.CreatedDate = DateTime.Now.ToString("D");
                vs.CreatedBy = detail.CreatedBy;


                _context.blogtouristplaces.Add(vs);
                var _val = _context.SaveChanges();

                if (_val.Equals("1"))
                {
                    response.Status = "Success";
                    response.Message = "Post created successfully!";
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
