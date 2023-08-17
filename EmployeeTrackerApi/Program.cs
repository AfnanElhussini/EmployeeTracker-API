using EmployeeTrackerApi.Data;
using EmployeeTrackerApi.Helpers;
using EmployeeTrackerApi.Services.Classes;
using EmployeeTrackerApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTrackerApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors();

           builder.Services.AddDbContext<EmployeeDbContext>(options =>
           {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

          builder.Services.AddAutoMapper(typeof(MappingProfile));
          builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
          builder.Services.AddScoped<IAdressReprositry, AdressReprositry>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(x=>x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}