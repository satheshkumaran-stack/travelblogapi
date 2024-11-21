using Microsoft.EntityFrameworkCore;
using TravelBlogAPI.Models;

namespace TravelBlogAPI.Data
{
    public class AppDbContext(IConfiguration configuration) : DbContext
    {
        protected readonly IConfiguration Configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("ConnStr"));
        }

        public DbSet<UserModel> blogusermaster { get; set; }
        public DbSet<BlogTourPlacesList> blogtouristplaces { get; set; }
        public DbSet<BlogPlacesCommentsList> blogplacescomments { get; set; }
    }
}
