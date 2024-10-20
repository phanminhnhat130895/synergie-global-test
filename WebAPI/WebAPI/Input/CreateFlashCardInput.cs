namespace WebAPI.Input
{
    public class CreateFlashCardInput
    {
        public string Content { get; }
        public string Meaning { get; }

        public CreateFlashCardInput(string content, string meaning)
        {
            Content = content;
            Meaning = meaning;
        }
    }
}
