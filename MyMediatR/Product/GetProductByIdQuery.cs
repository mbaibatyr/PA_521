using Dapper;
using MediatR;

namespace MyMediatR.Product
{
    public record ProductDto(int Id, string Name, decimal Price);
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto?>;

    public class GetProductByIdQueryHandler(IDbConnectionFactory db) : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            const string sql = "SELECT Id, Name, Price FROM Products WHERE Id = @Id;";
            using var connection = db.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<ProductDto>(sql, new { request.Id });
        }
    }

}
