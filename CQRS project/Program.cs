
using CQRS_project.Context;
using CQRS_project.CQRS.Handlers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
          
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(typeof(Program));
            #region Services Registration
            //builder.Services.AddScoped<GetByIdQueryHandler>();
            //builder.Services.AddScoped<GetAllQueryHandler>();
            //builder.Services.AddScoped<CreateStudentCommandHandler>();
            //builder.Services.AddScoped<DeleteStudentCommandHandler>();
            //builder.Services.AddScoped<UpdateStudentCommandHandler>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
