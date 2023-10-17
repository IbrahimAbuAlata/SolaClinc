using Microsoft.EntityFrameworkCore;
using SolaClinc.Models;
using SolaClinc.Models.ViewModels;

namespace SolaClinc.Data
{
	public class AppDbContext:DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }
        public DbSet<Service> services { get; set; }
        public DbSet<Feedback> feedbacks { get; set; }    
        public DbSet<User> users { get; set; }
        public DbSet<User2> users2 { get; set; }
        public DbSet<Role> roles { get; set; }


    }
}
