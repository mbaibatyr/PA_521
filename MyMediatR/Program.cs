
using Microsoft.AspNetCore.RateLimiting;
using Serilog;

namespace MyMediatR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();


            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
            Log.Information("Запуск приложения...");
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog();
            builder.Services.Configure<ShopSettings>(builder.Configuration.GetSection("ShopSettings"));

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:3000") // Адрес твоего фронтенда
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddRateLimiter(options =>
            {
                options.AddFixedWindowLimiter("fixed", opt =>
                {
                    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
                    opt.PermitLimit = 5; // Не более 5 запросов
                    opt.Window = TimeSpan.FromSeconds(10); // За 10 секунд
                    opt.QueueLimit = 0; // Без очереди
                });
            });
            var app = builder.Build();
            app.UseRateLimiter();
            app.UseCors("AllowFrontend");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
