namespace ClientFramework
{
    public sealed class SaveMessage
    {
        private SaveMessage(string title, string message)
        {
            Title = title;
            Message = message;
        }

        public string Title { get; }

        public string Message { get; }

        public static SaveMessage Create(string title, string message)
        {
            return new SaveMessage(title, message);
        }
    }
}
