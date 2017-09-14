using System.Collections.Generic;
using System.Linq;

namespace ClientFramework
{
    public sealed class SaveResult
    {
        private SaveResult(bool succeeded, IEnumerable<SaveMessage> messages)
        {
            Succeeded = succeeded;
            messageList = messages.ToList();
        }

        public bool Succeeded { get; }

        public IEnumerable<SaveMessage> Messages => messageList;

        private ICollection<SaveMessage> messageList = new List<SaveMessage>();

        public static SaveResult CreateSucceeded()
        {
            return new SaveResult(true, Enumerable.Empty<SaveMessage>());
        }

        public static SaveResult CreateFailed(params SaveMessage[] message)
        {
            return new SaveResult(false, message);
        }

        public static SaveResult CreateFailed()
        {
            return new SaveResult(false, Enumerable.Empty<SaveMessage>());
        }

        public SaveResult AddMessage(string title, string message)
        {
            messageList.Add(SaveMessage.Create(title, message));

            return this;
        }
    }
}
