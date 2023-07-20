using Dapper;
using System.Data;
using System.Data.Common;

namespace AgileShop.DataAccess.Handlers;

public class DateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
{
    public override DateOnly Parse(object value)
    {
        if (value is not null)
        {
            string[] date = value.ToString()!.Split('-');
            int year = int.Parse(date[0]);
            int month = int.Parse(date[1]);
            int day = int.Parse(date[2]);
            DateOnly dateOnly = new DateOnly(year, month, day);
            return dateOnly;
        }
        else return new DateOnly();
    }

    public override void SetValue(IDbDataParameter parameter, DateOnly value)
    {
        parameter.Value = (object) ("" + value.Year + "-" + value.Month + "-" + value.Day);
    }
}
