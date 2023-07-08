using Npgsql;

namespace AgileShop.DataAccess.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connection;
	public BaseRepository()
	{
		Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
		this._connection = new NpgsqlConnection("Host=localhost; Port=5432; Database=agile-shop-db; User Id=postgres; Password=785214;");
	}
}
