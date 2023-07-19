using AgileShop.DataAccess.Common.Interfaces;
using AgileShop.DataAccess.ViewModels.Users;
using AgileShop.Domain.Entities.Users;

namespace AgileShop.DataAccess.Interfaces.Users;

public interface IUserRepository : IRepository<User, UserViewModel>, 
    IGetAll<UserViewModel>, ISearchable<UserViewModel>
{
    public Task<User?> GetByPhoneAsync(string phone);
}
