using System.Windows.Input;

namespace ClientFramework
{
    public interface IRaisableCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
