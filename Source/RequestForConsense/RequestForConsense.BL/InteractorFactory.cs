using RequestForConsense.BL.ConfigurationManagement;
using RequestForConsense.BL.DatabaseAccess;
using RequestForConsense.BL.UserAuthentication;

namespace RequestForConsense.BL
{
    public static class InteractorFactory
    {
        private static string ConnectionString;

        public static void SetConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private static IDatabaseAccessor GetDatabaseAccessor()
        {
            IDatabaseAccessor databaseAccessor = new MySqlDatabaseAccessor(ConnectionString);
            return databaseAccessor;
        }

        public static UserAuthenticationInteractor UserAuthentication()
        {
            IUserRepository userRepository = new UserRepository(GetDatabaseAccessor());
            return new UserAuthenticationInteractor(userRepository);
        }
    }
}
