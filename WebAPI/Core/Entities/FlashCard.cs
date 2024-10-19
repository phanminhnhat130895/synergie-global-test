using Core.Common;

namespace Core.Entities
{
    public class FlashCard : Entity
    {
        public FlashCard(Guid id) : base(id)
        {
        }

        public Guid UserId { get; private set; }
        public string Content { get; private set; }
        public string Meaning { get; private set; }

        public User User { get; private set; }

        public FlashCard SetContent(string content)
        {
            Content = content;
            return this;
        }

        public FlashCard SetMeaning(string meaning)
        {
            Meaning = meaning;
            return this;
        }

        public FlashCard SetUserId(Guid userId)
        {
            UserId = userId;
            return this;
        }
    }
}
