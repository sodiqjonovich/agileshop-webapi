using AgileShop.Domain.Enums;
using Dapper;
using System.Data;

namespace AgileShop.DataAccess.Handlers;

public class IdentityRoleTypeHandler : SqlMapper.TypeHandler<IdentityRole>
{
    public override IdentityRole Parse(object value)
    {
        if (Enum.TryParse<IdentityRole>(value.ToString(), out IdentityRole role))
            return role;
        else return IdentityRole.User;
    }

    public override void SetValue(IDbDataParameter parameter, IdentityRole value)
    {
        parameter.Value = value.ToString();
    }
}