using AgileShop.DataAccess.Interfaces.Users;
using AgileShop.DataAccess.Utils;
using AgileShop.DataAccess.ViewModels.Users;
using AgileShop.Domain.Entities.Users;
using Dapper;
using static Dapper.SqlMapper;

namespace AgileShop.DataAccess.Repositories.Users;

public class UserRepository : BaseRepository, IUserRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from users";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.users(first_name, last_name, phone_number, phone_number_confirmed, passport_seria_number, is_male, birth_date, country, region, password_hash, salt, image_path, last_activity, identity_role, created_at, updated_at) " +
                $"VALUES (@FirstName, @LastName, @PhoneNumber, @PhoneNumberConfirmed, @PassportSeriaNumber, @IsMale, '{entity.BirthDate.Year}-{entity.BirthDate.Month}-{entity.BirthDate.Day}', @Country, @Region, @PasswordHash, @Salt, @ImagePath, @LastActivity, @IdentityRole, @CreatedAt, @UpdatedAt);";
            return await _connection.ExecuteAsync(query, entity);
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"delete from users where id = {id}";
            return await _connection.ExecuteAsync(query);
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<User?> GetByPhoneAsync(string phone)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM users where phone_number = @PhoneNumber";
            var data = await _connection.QuerySingleAsync<User>(query, new { PhoneNumber = phone });
            return data;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<UserViewModel?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<(int ItemsCount, IList<UserViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, User entity)
    {
        throw new NotImplementedException();
    }
}
