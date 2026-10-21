using Dapper;
using MediatR;
using Microsoft.Extensions.Options;

namespace MyMediatR.Product
{
    public record CreateProductCommand(string Name, decimal Price) : IRequest<int>;

    public class CreateProductHandler(
        IDbConnectionFactory db,
        ILogger<CreateProductHandler> logger,
        IOptions<ShopSettings> shopSettings) : IRequestHandler<CreateProductCommand, int>
    {
        private readonly ShopSettings _settings = shopSettings.Value;

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Используем конфигурацию
            if (request.Price > _settings.MaxPriceLimit)
            {
                logger.LogWarning("Попытка создать продукт {Name} с ценой {Price}, превышающей лимит магазина ({Limit})",
                    request.Name, request.Price, _settings.MaxPriceLimit);

                throw new InvalidOperationException("Цена превышает допустимый лимит!");
            }

            const string sql = "INSERT INTO Products (Name, Price) OUTPUT INSERTED.Id VALUES (@Name, @Price);";
            using var connection = db.CreateConnection();

            int id = await connection.ExecuteScalarAsync<int>(sql, request);

            // Используем логгер Serilog
            logger.LogInformation("В магазине '{Shop}' успешно создан продукт ID: {ProductId} с именем {Name}",
                _settings.ShopName, id, request.Name);

            return id;
        }
    }
}
