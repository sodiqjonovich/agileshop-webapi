using AgileShop.DataAccess.Handlers;
using Dapper;
using Npgsql;

namespace AgileShop.DataAccess.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connection;
    public BaseRepository()
    {
        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new NpgsqlConnection("Host=agileshop-database-host; Port=5432; Database=agileshop-db; User Id=postgres_admin; Password=AAaa@@11;");
    }
}
