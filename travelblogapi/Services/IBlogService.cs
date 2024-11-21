using TravelBlogAPI.Models;

namespace TravelBlogAPI.Services
{
    public interface IBlogService
    {
        List<BlogTourPlacesList> GetTouristPlaces();
        List<BlogPlacesCommentsList> GetPlacesComments(string placeId);
        Response SaveNewPost(NewPostDetail detail);
    }
}
