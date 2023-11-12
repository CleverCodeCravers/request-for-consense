using RequestForConsense.BL.Common;

namespace RequestForConsense.BL.UserAuthentication
{


    public class UserAuthenticationInteractor
    {
        private readonly IUserRepository _userRepository;

        public UserAuthenticationInteractor(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Result<User> Login(string email, string password)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return Result<User>.Failure("Email and password cannot be empty.");
            }

            // Check if user exists
            var user = _userRepository.FindByEmail(email);
            if (user == null)
            {
                return Result<User>.Failure("User does not exist.");
            }

            // Validate credentials
            bool isValidUser = _userRepository.ValidateUser(email, password);
            if (!isValidUser)
            {
                return Result<User>.Failure("Invalid email or password.");
            }

            // Return success result with user
            return Result<User>.Success(user);
        }
    }


}
