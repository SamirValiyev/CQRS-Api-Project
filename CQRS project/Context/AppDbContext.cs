using Microsoft.EntityFrameworkCore;

namespace CQRS_project.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)   
        {
            

        }
    }
}
