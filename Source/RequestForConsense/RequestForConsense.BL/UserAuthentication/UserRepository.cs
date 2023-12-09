using RequestForConsense.BL.DatabaseAccess;
using System.Data;

namespace RequestForConsense.BL.UserAuthentication
{

    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseAccessor _databaseAccessor;

        public UserRepository(IDatabaseAccessor databaseAccessor)
        {
            _databaseAccessor = databaseAccessor;
        }

        public User FindByEmail(string email)
        {
            // Implementation to retrieve user based on email
            // Assuming email is unique and using a dummy SQL query for demonstration
            string sql = "SELECT id, email, password FROM users WHERE email = @Email AND isActive = 1";
            DataTable result = _databaseAccessor.LoadDataTable(sql, new Dictionary<string, object> { { "@Email", email } });

            if (result.Rows.Count > 0)
            {
                // Create a new user record with the email and return it
                return new User(
                    result.Rows[0]["email"].ToString(),
                    (int)result.Rows[0]["id"],
                    result.Rows[0]["password"].ToString());
            }

            // If no active user found, return null
            return null;
        }

        public bool ValidateUser(string email, string password)
        {
            // Implementation for user validation
            // A dummy SQL query for demonstration
            string sql = "SELECT password FROM users WHERE email = @Email AND isActive = 1";
            DataTable result = _databaseAccessor.LoadDataTable(sql, new Dictionary<string, object> { { "@Email", email } });

            if (result.Rows.Count > 0)
            {
                // Retrieve hashed password from the database
                string hashedPassword = result.Rows[0]["password"].ToString();

                // Use BCrypt to verify the password
                return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }

            // If no active user found, or password verification fails, return false
            return false;
        }
        public User FindById(int id)
        {
            string sql = "SELECT id, email, password FROM users WHERE id = @Id AND isActive = 1";
            DataTable result = _databaseAccessor.LoadDataTable(sql, new Dictionary<string, object> { { "@Id", id } });

            if (result.Rows.Count > 0)
            {
                return new User(
                    result.Rows[0]["email"].ToString(),
                    (int)result.Rows[0]["id"],
                    result.Rows[0]["password"].ToString());
            }

            return null;
        }
    }
}
