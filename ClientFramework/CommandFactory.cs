using System;
using System.Windows.Input;

namespace ClientFramework
{
    public static class CommandFactory
    {
        public static ICommand Create(Action<object> executeDelegate)
        {
            return new YetAnotherCommand(CanAlwaysExecute, executeDelegate);
        }

        public static IRaisableCommand Create(Action<object> executeDelegate, Predicate<object> canExecuteDelegate)
        {
            return new YetAnotherCommand(canExecuteDelegate, executeDelegate);
        }

        private static bool CanAlwaysExecute(object obj)
        {
            return true;
        }
    }
}
