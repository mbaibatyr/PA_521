using MyPagination.Model;

namespace MyPagination.Abstract
{
    public interface IUser
    {
        public Task<PagedResult<User>> GetUsersAsync(int page, int pageSize);
    }
}
