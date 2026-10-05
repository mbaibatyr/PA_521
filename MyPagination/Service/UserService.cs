using Dapper;
using Microsoft.Data.SqlClient;
using MyPagination.Abstract;
using MyPagination.Model;
using System.Data;

namespace MyPagination.Service
{
    public class UserService : IUser
    {
        IConfiguration config;
        public UserService(IConfiguration config)
        {
            this.config = config;
        }
        public async Task<PagedResult<User>> GetUsersAsync(int page, int pageSize)
        {
            using var db = new SqlConnection(config.GetConnectionString("db_sql_server"));
            var parameters = new DynamicParameters();

            parameters.Add("@PageNumber", page);
            parameters.Add("@PageSize", pageSize);

            var data = (await db.QueryAsync<User>(
                "GetUsers",
                parameters,
                commandType: CommandType.StoredProcedure
            )).ToList();

            var totalCount = (int?)data.FirstOrDefault()?.total_count ?? 0;

            return new PagedResult<User>
            {
                Items = data
                    .Select(x => new User
                    {
                        id = x.id,
                        last_name = x.last_name,
                        first_name = x.first_name,
                        date_birth = x.date_birth,
                        email = x.email,
                        created = x.created
                    })
                    .ToList(),

                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }
    }
}
