using Core.Common;

namespace Core.Entities
{
    public class FlashCard : Entity
    {
        public FlashCard(Guid id) : base(id)
        {
        }

        public string Content { get; private set; }
        public string Meaning { get; private set; }

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
    }
}
