using System.ComponentModel.DataAnnotations;

namespace TravelBlogAPI.Models
{
    public class TokenModel
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
    public class RegisterModel
    {
        public string? Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email Id is required")]
        public string? EmailId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
    public class UserModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email Id is required")]
        public string? EmailId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public string? RefreshToken { get; set; }
        public string? RefreshTokenExpiryTime { get; set; }
        public string? CreatedDate { get; set; }
    }
    public class Response
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
    }
}
