using System;

namespace ClientFramework
{
    public sealed class YetAnotherCommand : IRaisableCommand
    {
        private readonly Predicate<object> canExecute;

        private readonly Action<object> execute;

        public YetAnotherCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }        
    }
}
