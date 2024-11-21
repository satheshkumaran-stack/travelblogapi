namespace TravelBlogAPI.Models
{
    public class BlogTourPlacesList
    {
        public int? Id { get; set; }
        public string? Place { get; set; }
        public string? Description { get; set; }
        public string? FileName { get; set; }
        public byte[]? FileData { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public int? CommentsCount { get; set; }
    }
    public class BlogPlacesCommentsList
    {
        public int? Id { get; set; }
        public int? PlaceId { get; set; }
        public string? Comments { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
    public class NewPostDetail
    {
        public string? PlaceName { get; set; }
        public string? Description { get; set; }
        public string? FileName { get; set; }
        public IFormFile? FormFile { get; set; }
        public byte[]? FileData { get; set; }
        public string? CreatedBy { get; set; }
    }
}
