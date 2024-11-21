using TravelBlogAPI.Models;

namespace TravelBlogAPI.Services
{
    public interface IUserDetails
    {
        UserModel UserAuthenticate(string emailid, string password);
        void UpdateUser(UserModel user);
        UserModel VerifyUser(string emailid);
        string NewUser(UserModel user);
    }
}
