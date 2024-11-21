using TravelBlogAPI.Data;
using TravelBlogAPI.Models;

namespace TravelBlogAPI.Services
{
    public class UserDetails : IUserDetails
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        public UserDetails(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        public UserModel UserAuthenticate(string emailid, string password)
        {
            return _context.blogusermaster.Where(p => p.EmailId == emailid && p.Password == password).FirstOrDefault();
        }

        public void UpdateUser(UserModel user)
        {
            var user_val = _context.blogusermaster.FirstOrDefault(e => e.Id == user.Id);
            if (user_val != null)
            {
                user_val.RefreshToken = user.RefreshToken;
                user_val.RefreshTokenExpiryTime = user.RefreshTokenExpiryTime;
            }
            _context.blogusermaster.Update(user);
            _context.SaveChanges();
        }

        public UserModel VerifyUser(string username)
        {
            return _context.blogusermaster.Where(p => p.EmailId == username).FirstOrDefault();
        }

        public string NewUser(UserModel user)
        {
            _context.blogusermaster.Add(user);
            var _val = _context.SaveChanges();
            return _val.ToString();
        }
    }
}
