namespace RequestForConsense.BL.UserAuthentication
{
    public interface IUserRepository
    {
        User FindByEmail(string email);
        bool ValidateUser(string email, string password);
    }


}
