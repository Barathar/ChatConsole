using Simulator.Data;

namespace Simulator.Messages
{
    internal class LoginUser
    {
        public UserCredentials Credentials { get; private set; }

        public LoginUser(UserCredentials credentials)
        {
            Credentials = credentials;
        }
    }
}
