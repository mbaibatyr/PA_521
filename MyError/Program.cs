
using FluentValidation;
using MyError.Filter;
using MyError.Model;

namespace MyError
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<FluentValidationFilter>();

            builder.Services.AddControllers(options =>
            {
                options.Filters.AddService<FluentValidationFilter>();
            });

            builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddProblemDetails();
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


            var app = builder.Build();

            app.UseExceptionHandler();
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
