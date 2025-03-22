using CQRS_project.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS_project.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)   
        {
            

        }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student{Name="John",Surname="Doe",Age=20,Id=1},
                new Student{Name="Jane",Surname="Doe",Age=21,Id=2},
                new Student{Name="Jack",Surname="Smith",Age=22,Id=3}
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
