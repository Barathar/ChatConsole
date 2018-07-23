namespace Simulator.Data
{
    internal class UserCredentials
    {
        public string Name { get; private set; }
        public string Password { get; private set; }

        public UserCredentials(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
