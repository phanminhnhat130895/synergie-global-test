using Core.Common;

namespace Core.Entities
{
    public class User : Entity
    {
        public User(Guid id) : base(id)
        {
            DateCreated = DateTime.UtcNow;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }

        public List<FlashCard> FlashCards { get; private set; } = new List<FlashCard>();

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

        public User AddFlashCard(FlashCard flashCard)
        {
            FlashCards.Add(flashCard);
            return this;
        }

        public User SetSalt(string salt)
        {
            Salt = salt;
            return this;
        }
    }
}
