using MySqlConnector;
using System.Data;


namespace RequestForConsense.BL.DatabaseAccess
{
    public class MySqlDatabaseAccessor : IDatabaseAccessor
    {
        private readonly string _connectionString;

        public MySqlDatabaseAccessor(string connectionString)
        {
            _connectionString = connectionString;
        }



        public int ExecuteSql(string sql, Dictionary<string, object> parameters)
        {
            using var connection = new MySqlConnection(_connectionString);
            using var command = new MySqlCommand(sql, connection);
            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value);
            }

            connection.Open();
            int affectedRows = command.ExecuteNonQuery();
            return affectedRows;
        }

        public DataTable LoadDataTable(string sql, Dictionary<string, object> parameters)
        {
            using var connection = new MySqlConnection(_connectionString);
            using var command = new MySqlCommand(sql, connection);
            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value);
            }

            using var adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public object LoadScalar(string sql, Dictionary<string, object> parameters)
        {
            using var connection = new MySqlConnection(_connectionString);
            using var command = new MySqlCommand(sql, connection);
            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value);
            }

            connection.Open();
            object result = command.ExecuteScalar();
            return result;
        }
    }


}
