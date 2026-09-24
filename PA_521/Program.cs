
using Microsoft.Extensions.DependencyInjection;
using PA_521.Abstract;
using PA_521.Model;
using PA_521.Service;

namespace PA_521
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            builder.Services.AddScoped<IStudent, WorkService>();
            builder.Services.AddScoped<ICity, CityService>();

            builder.Services.AddControllers();
            
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
