
using Asp.Versioning;
using System.Reflection;

namespace MySwagger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0); // Версия по умолчанию
                options.AssumeDefaultVersionWhenUnspecified = true; // Если клиент не указал версию, дать v1.0
                options.ReportApiVersions = true; // Добавляет заголовки ответа о поддерживаемых версиях (api-supported-versions)
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV"; // Формат имени группы для Swagger (например, v1, v2)
                options.SubstituteApiVersionInUrl = true; // Подставляет версию в URL автоматически
            });

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1",
                    Description = "Документация для первой версии API",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Иван Иванов",
                        Email = "ivanov@example.com",
                        Url = new Uri("https://t.me/your_username")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });


                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "My API",
                    Version = "v2",
                    Description = "Документация для второй версии API",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Иван Иванов",
                        Email = "ivanov@example.com"
                    }
                });               
              
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });



            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    options.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");
                    options.DefaultModelsExpandDepth(-1);
                });
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
