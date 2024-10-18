using Core.Common;

namespace Core.Entities
{
    public class User : Entity
    {
        public User(Guid id) : base(id)
        {
        }

        public string Email { get; private set; }
        public string Password { get; private set; }

        public User SetEmail(string email)
        {
            Email = email;
            return this;
        }

        public User SetPassword(string password)
        {
            Password = password;
            return this;
        }
    }
}
