using System.Data;


namespace RequestForConsense.BL.DatabaseAccess
{
    public interface IDatabaseAccessor
    {
        int ExecuteSql(string sql, Dictionary<string, object> parameters);
        DataTable LoadDataTable(string sql, Dictionary<string, object> parameters);
        object LoadScalar(string sql, Dictionary<string, object> parameters);
    }


}
